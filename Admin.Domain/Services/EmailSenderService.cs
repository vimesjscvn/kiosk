using AutoMapper;
using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using CS.VM.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TEK.Core.Helpers;
using TEK.Core.Service.Interfaces;
using TEK.Core.Settings;
using TEK.Core.UoW;
using TEK.Email.Interfaces;

namespace Admin.API.Domain.Services
{
    public class EmailSenderService : IEmailSender
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IOrderNumberService _orderNumberService;

        private readonly IMapper _mapper;

        private readonly HospitalSettings _hospitalSettings;
        public EmailSenderService(IUnitOfWork unitOfWork,
            IOrderNumberService orderNumberService,
            IMapper mapper,
            HospitalSettings hospitalSettings)
        {
            _unitOfWork = unitOfWork;
            _orderNumberService = orderNumberService;
            _mapper = mapper;
            _hospitalSettings = hospitalSettings;
        }

        public async Task<bool> SendMailWithType(EmailSenderRequest mailRequest)
        {
            mailRequest.PatientCode = HospitalHelper.BuildPatientCode(mailRequest.PatientCode, _hospitalSettings.Hospital.HospitalCode);

            var employee = await _unitOfWork.GetRepository<SysUser>().FindAsync(x => x.Id == mailRequest.EmployeeId);
            if (employee == null)
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);

            var patient = await _unitOfWork.GetRepository<Patient>().GetAll().FirstOrDefaultAsync(x => x.Code == mailRequest.PatientCode);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            if (mailRequest.EmailType == EmailType.Reception && mailRequest.ReceptionId.HasValue)
            {
                var reception = await _unitOfWork.GetRepository<Reception>().GetAsyncById(mailRequest.ReceptionId.Value);
                if (reception == null)
                    throw new Exception(ErrorMessages.NotFoundReceptionNumber);
                return await SendMailCompleteReception(employee, reception, mailRequest.Reason, patient);
            }
            else if (mailRequest.EmailType == EmailType.QueueNumber)
            {
                var extendValue = await _unitOfWork.GetRepository<ListValueExtend>().FindAsync(x => x.Code == mailRequest.DepartmentCode);
                if (extendValue == null)
                    throw new Exception(ErrorMessages.NotFoundExtendValue);
                return await SendMailCreateQueueNumber(employee, extendValue, mailRequest.Reason, patient);
            }
            else throw new Exception(ErrorMessages.InvalidMailType);
        }
        public async Task<bool> VerifyCodeWithType(VerifyCodeRequest verifyRequest)
        {
            verifyRequest.PatientCode = StringUtils.MapValidPatientCode(verifyRequest.PatientCode);

            var employee = await _unitOfWork.GetRepository<SysUser>().FindAsync(x => x.Id == verifyRequest.EmployeeId);
            if (employee == null)
                throw new Exception(ErrorMessages.NotFoundEmployeeCode);

            var patient = await _unitOfWork.GetRepository<Patient>().FindAsync(x => x.Code == verifyRequest.PatientCode);
            if (patient == null)
                throw new Exception(ErrorMessages.NotFoundPatientCode);

            bool isCompare = CompareCode(verifyRequest.VerifyCode, 10);

            if (isCompare)
            {
                if (verifyRequest.EmailType == EmailType.Reception)
                {
                    return true;
                }
                else if (verifyRequest.EmailType == EmailType.QueueNumber)
                {
                    await _orderNumberService.AddQueueNumber(verifyRequest.DepartmentCode, employee, patient);
                    var history = new History
                    {
                        Reason = verifyRequest.Reason,
                        HistoryId = Guid.Empty,
                        Type = HistoryType.QueueNumber,
                        CreatedBy = employee.FullName,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = employee.FullName,
                        UpdatedDate = DateTime.Now,
                        EmployeeId = employee.Id,
                        Employee = employee
                    };
                    _unitOfWork.GetRepository<History>().Add(history);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                else if (verifyRequest.EmailType == EmailType.SyncTransaction)
                {
                    var history = new History
                    {
                        Reason = verifyRequest.Reason,
                        HistoryId = Guid.Empty,
                        Type = HistoryType.SyncTransaction,
                        CreatedBy = employee.FullName,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = employee.FullName,
                        UpdatedDate = DateTime.Now,
                        EmployeeId = employee.Id,
                        Employee = employee
                    };
                    _unitOfWork.GetRepository<History>().Add(history);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                else if (verifyRequest.EmailType == EmailType.CancelTransaction)
                {
                    var history = new History
                    {
                        Reason = verifyRequest.Reason,
                        HistoryId = Guid.Empty,
                        Type = HistoryType.CancelTransaction,
                        CreatedBy = employee.FullName,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = employee.FullName,
                        UpdatedDate = DateTime.Now,
                        EmployeeId = employee.Id,
                        Employee = employee
                    };
                    _unitOfWork.GetRepository<History>().Add(history);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                else throw new Exception(ErrorMessages.InvalidMailType);
            }
            throw new Exception(ErrorMessages.VerifyCodeFaild);
        }
        private async Task<bool> SendMailCompleteReception(SysUser sysUser, Reception reception, string reason, Patient patient)
        {
            EmailSender emailModel = new EmailSender();
            EmailSetting emailSetting = await _unitOfWork.GetRepository<EmailSetting>().GetAll().FirstOrDefaultAsync(x => x.EmailType == EmailType.Reception);

            if (emailSetting == null)
            {
                emailSetting = await _unitOfWork.GetRepository<EmailSetting>().GetAll().FirstOrDefaultAsync();
            }

            emailModel = _mapper.Map<EmailSender>(emailSetting);

            string code = GenerateCode(patient.Code, emailSetting.TimeExpired);
            var tempPath = @"wwwroot/templates/CreateCompleteReceptionTemplate.html";
            string htmlBody = File.ReadAllText(tempPath);
            emailModel.Body = string.Format(htmlBody,
                sysUser.FullName,
                reception.RegisteredCode,
                reception.RegisteredDate,
                patient.Code,
                patient.LastName,
                patient.FirstName,
                reason, code, sysUser.FullName);

            return await SentMail(emailModel);
        }
        private async Task<bool> SendMailCreateQueueNumber(SysUser sysUser, ListValueExtend valueExtend, string reason, Patient patient)
        {
            EmailSender emailModel = new EmailSender();
            EmailSetting emailSetting = await _unitOfWork.GetRepository<EmailSetting>().GetAll().FirstOrDefaultAsync(x => x.EmailType == EmailType.QueueNumber);

            if (emailSetting == null)
            {
                emailSetting = await _unitOfWork.GetRepository<EmailSetting>().GetAll().FirstOrDefaultAsync();
            }

            emailModel = _mapper.Map<EmailSender>(emailSetting);
            string code = GenerateCode(patient.Code, emailSetting.TimeExpired);
            var tempPath = @"wwwroot/templates/CreateQueueNumberTemplate.html";
            string htmlBody = File.ReadAllText(tempPath);
            emailModel.Body = string.Format(htmlBody,
                sysUser.FullName,
                valueExtend.Description,
                patient.Code,
                patient.LastName,
                patient.FirstName,
                reason, code, sysUser.FullName);

            return await SentMail(emailModel);
        }

        private async Task<bool> SentMail(EmailSender emailModel)
        {
            try
            {
                MailMessage message = new MailMessage
                {
                    From = new MailAddress(emailModel.FromMail),
                    Subject = emailModel.Subject,
                    IsBodyHtml = true,
                    Body = emailModel.Body
                };
                message.To.Add(new MailAddress(emailModel.ToMail));

                SmtpClient smtp = new SmtpClient
                {
                    Port = emailModel.Port,
                    Host = emailModel.Host,
                    EnableSsl = true,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(emailModel.FromMail, emailModel.FromMailPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                await smtp.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string GenerateCode(string patientCode, int timeExpired)
        {
            patientCode = patientCode.Substring(7, 8);
            return patientCode + GetDateTimeNow(timeExpired);
        }

        public static bool CompareCode(string code, int timeExpired)
        {
            int.TryParse(code.Substring(8), out int codeCompare);
            int.TryParse(DateTime.Now.AddMinutes(-timeExpired).ToString("MMddHHmmss"), out int now);
            if (now > codeCompare)
                return false;
            return true;
        }

        public static int GetDateTimeNow(int timeExpired)
        {
            var date = DateTime.Now.AddMinutes(timeExpired);
            int.TryParse(date.ToString("MMddHHmmss"), out int now);
            return now;
        }

    }
}
