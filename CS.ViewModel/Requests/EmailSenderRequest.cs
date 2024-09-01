using System;
using CS.Common.Common;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class BaseEmailSender
    {
        [JsonRequired] public EmailType EmailType { get; set; }

        [JsonRequired] public string PatientCode { get; set; }

        [JsonRequired] public string Reason { get; set; }

        [JsonRequired] public Guid EmployeeId { get; set; }

        public Guid? TransactionId { get; set; }
        public Guid? ReceptionId { get; set; }
        public string DepartmentCode { get; set; }
    }

    public class EmailSenderRequest : BaseEmailSender
    {
    }

    public class VerifyCodeRequest : BaseEmailSender
    {
        [JsonRequired] public string VerifyCode { get; set; }
    }

    public class EmailSender
    {
        public string FromMail { get; set; }
        public string FromMailPassword { get; set; }
        public string ToMail { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}