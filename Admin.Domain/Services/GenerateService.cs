using CS.Common.Common;
using CS.Common.Helpers;
using CS.EF.Models;
using Microsoft.AspNetCore.Http;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using TEK.Core.Service.Interfaces;

namespace Admin.API.Domain.Services
{
    public class GenerateService : IGenerateService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GenerateService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateTempPatient(GenerateTempPatientModel generateTempPatient)
        {
            var imageWidth = 640;
            var imageHeight = 960;
            string fileName = Guid.NewGuid().ToString();
            string path = GetPathResources();

            Bitmap bitmap = new Bitmap(path);
            Bitmap bmp = new Bitmap(imageWidth, imageHeight);
            Graphics graphic = Graphics.FromImage(bmp);
            graphic.Clear(Color.White);

            Font regular = new Font(FontFamily.GenericSansSerif, 23.0f, FontStyle.Regular);
            Font bold = new Font(FontFamily.GenericSansSerif, 23.0f, FontStyle.Bold);

            var titleX = 170;
            var titleY = 20;

            graphic.DrawImage(bitmap, new Rectangle(20, 0, 130, 110));
            graphic.DrawString("EYE HOSPITAL", new Font(FontFamily.GenericSansSerif, 22.0f, FontStyle.Bold), Brushes.Black, titleX, titleY);
            graphic.DrawString("BỆNH VIỆN MẮT", bold, Brushes.Black, titleX, titleY + 40);
            graphic.DrawString("SỐ THỨ TỰ NHẬN BỆNH", new Font(FontFamily.GenericSansSerif, 28.0f, FontStyle.Bold), Brushes.Black, 80, titleY + 120);

            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            string ngay = DateTime.Now.ToString("dddd, dd MMMM yyyy", cul.DateTimeFormat);
            string thoigian = DateTime.Now.ToString("HH:mm", cul.DateTimeFormat);
            string s = thoigian + "," + ngay;
            graphic.DrawString(s, new Font(FontFamily.GenericSansSerif, 18.0f, FontStyle.Regular), Brushes.Black, 110, titleY + 170);

            var startX = 50;
            var startY = 220;
            var offSet = 60;

            //qrCode
            var pathQr = GenerateQRCode(generateTempPatient.QrCode, fileName);
            Bitmap bitmapQr = new Bitmap(pathQr);
            graphic.DrawImage(bitmapQr, new Rectangle(startX + 150, startY, 250, 240));
            graphic.DrawString(generateTempPatient.PatientCode, new Font(FontFamily.GenericSansSerif, 18.0f, FontStyle.Regular), Brushes.Black, startX + 190, startY + 230);
            startY += 240;

            //startY += /*10*/;
            //graphic.DrawString("Mã số BN: ", regular, Brushes.Black, startX, startY);
            //graphic.DrawString(patient.Code, bold, Brushes.Black, startX + 100, startY);
            // Name
            startY += offSet;
            float x = startX + 100;
            float y = startY;
            float width = 180;
            float height = 50;
            RectangleF drawRect = new RectangleF(x, y, width, height);
            SizeF stringSize = new SizeF();
            graphic.DrawString("Nhân viên: ", regular, Brushes.Black, startX, startY);
            graphic.DrawString(Constants.Systems.CreatedBy, bold, Brushes.Black, startX + 150, startY);

            startY += offSet;
            graphic.DrawString("Tên BN: ", regular, Brushes.Black, startX, startY);
            graphic.DrawString(StringUtils.TruncatePatientName($"{generateTempPatient.LastName} {generateTempPatient.FirstName}".Trim()), bold, Brushes.Black, startX + 150, startY);
            if (stringSize.Width > 180) startY += 10;
            startY += offSet;
            graphic.DrawString("Giới tính: ", regular, Brushes.Black, startX, startY);
            graphic.DrawString(GetStringByGender(generateTempPatient.Gender), bold, Brushes.Black, startX + 150, startY);
            graphic.DrawString("Năm sinh: ", regular, Brushes.Black, startX + 270, startY);
            graphic.DrawString(generateTempPatient.YearOfBirth, bold, Brushes.Black, startX + 420, startY);
            startY += offSet;
            graphic.DrawString("Số thứ tự: ", regular, Brushes.Black, startX, startY);
            graphic.DrawString(generateTempPatient.QueueNumber, new Font(FontFamily.GenericSansSerif, 80.0f, FontStyle.Bold), Brushes.Black, startX + 130, startY);

            string priorityCode = GetPriorityByType(generateTempPatient.PatientType);

            if (!string.IsNullOrEmpty(priorityCode))
            {
                startY += 150;
                graphic.DrawRectangle(new Pen(Brushes.Black, 3), new Rectangle(startX + 130, startY - 5, 240, 50));
                graphic.DrawString($"ƯU TIÊN {priorityCode}", new Font(FontFamily.GenericSansSerif, 30.0f, FontStyle.Bold), Brushes.Black, startX + 130, startY);
                startY -= 150;
            }
            graphic.DrawString("Bệnh nhân vui lòng giữ phiếu qua đăng ký phòng khám", new Font(FontFamily.GenericSansSerif, 18.0f, FontStyle.Regular), Brushes.Black, 18, startY + 230);

            fileName += ".png";
            bmp.Save($"wwwroot/images/{fileName}", ImageFormat.Png);
            return GetPathFileName(fileName);
        }

        #region Private Functions
        private string GenerateQRCode(string value, string guid)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            string webRootPath = $"wwwroot/images/QrCode_{guid}.png";
            qrCodeImage.Save(webRootPath, ImageFormat.Png);
            return Directory.GetCurrentDirectory() + "/" + webRootPath;
        }
        private string GetPriorityByType(PatientType patientType)
        {
            if (patientType == PatientType.Priority6) return HealthcareHelper.CODE06;
            else if (patientType == PatientType.Priority80) return HealthcareHelper.CODE80;
            else if (patientType == PatientType.PriorityBN) return HealthcareHelper.CODEBN;
            else if (patientType == PatientType.PriorityCode) return HealthcareHelper.CODECC;
            else if (patientType == PatientType.PriorityCT) return HealthcareHelper.CODECT;
            else if (patientType == PatientType.PriorityGT) return HealthcareHelper.CODEGT;
            else if (patientType == PatientType.PriorityKT) return HealthcareHelper.CODEKT;
            else return string.Empty;
        }
        private string GetPathFileName(string fileName)
        {
            return $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/images/{fileName}";
        }
        private string GetPathResources()
        {
            return Directory.GetCurrentDirectory() + "/wwwroot/images/Resources/benhvienmattphcm-none.png";
        }
        private string GetStringByGender(Gender gender)
        {
            return (int)gender == 1 ? "Nam" : "Nữ";
        }

        public string GeneratRegisterHospital(QueueNumber queueNumber, TempPatient tempPatient, ListValue hospital)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
