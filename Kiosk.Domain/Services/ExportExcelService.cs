using CS.Common.Common;
using CS.VM.Models;
using CS.VM.PatientModels;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using TEK.Core.Service.Interfaces;

namespace TEK.Payment.Domain.Services
{
    public class ExportExcelService : IExportExcelService
    {
        private readonly int NUMBER_IGNORE_ROW = 16;

        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExportExcelService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ExportResponse ExportPatientRoom(List<PatientsInRoomViewModel> patientsInRoom)
        {
            var webRoot = "wwwroot/";
            var tempPath = @"templates/Tekmedi.STT_NhanBenh_Phong_.xlsx";

            FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
            if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

            var fileName = "Tekmedi.STT_NhanBenh_Phong_" + patientsInRoom[0].DepartmentCode + ".xlsx";
            var exportFolder = Path.Combine(webRoot, "export");

            if (!Directory.Exists(exportFolder))
                Directory.CreateDirectory(exportFolder);

            var filePath = @"export/" + fileName;
            var fullPath = Path.Combine(webRoot, filePath);

            FileInfo file = new FileInfo(fullPath);

            if (file.Exists)
            {
                file.Delete();
                tempFile.CopyTo(fullPath);
            }
            else
                tempFile.CopyTo(fullPath);

            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];

                var resposne = patientsInRoom;
                if (resposne.Count > 0)
                {
                    var row = NUMBER_IGNORE_ROW;
                    detailSheet.InsertRow(row + 2, resposne.Count - 2, row + 1);
                    foreach (var item in resposne)
                    {
                        detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
                        detailSheet.Cells["C" + row].Value = item.PatientCode;
                        detailSheet.Cells["D" + row].Value = item.FullName;
                        detailSheet.Cells["E" + row].Value = item.Number;
                        detailSheet.Cells["F" + row].Value = item.Birthday.HasValue ? item.Birthday.Value.ToString("dd/MM/yyyy") : "";
                        detailSheet.Cells["G" + row].Value = (int)item.Gender == 1 ? "Nam" : "Nữ";
                        detailSheet.Cells["H" + row].Value = (int)item.Type == 1 ? "Ưu tiên" : "Thường";
                        detailSheet.Cells["I" + row].Value = item.CreatedDate.HasValue ? item.CreatedDate.Value.ToString("dd/MM/yyyy HH:mm:ss") : "";
                        row++;
                    }

                    detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

                    var indexAddress = row + 1; // Next one rows
                    detailSheet.Cells["K" + indexAddress].Value = "BV.Chợ Rẫy, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                }
                package.Save();
            }

            return new ExportResponse
            {
                FilePath = filePath,
                FileName = fileName
            };
        }

        public ExportResponse ExportReception(List<ReceptionReportViewModel> receptionReports)
        {
            var webRoot = "wwwroot/";
            var tempPath = @"templates/Tekmedi.TiepNhanBenh_FromDate_ToDate.xlsx";

            FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
            if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

            var fromDate = receptionReports[0].CreatedDate?.ToString("yyyy-MM-dd");
            var toDate = receptionReports[0].CreatedDate?.ToString("yyyy-MM-dd");

            var fileName = "Tekmedi.TiepNhanBenh_" + fromDate + "_" + toDate + ".xlsx";
            var exportFolder = Path.Combine(webRoot, "export");

            if (!Directory.Exists(exportFolder))
                Directory.CreateDirectory(exportFolder);

            var filePath = @"export/" + fileName;
            var fullPath = Path.Combine(webRoot, filePath);

            FileInfo file = new FileInfo(fullPath);

            if (file.Exists)
            {
                file.Delete();
                tempFile.CopyTo(fullPath);
            }
            else
                tempFile.CopyTo(fullPath);

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];

                var resposne = receptionReports;
                if (resposne.Count > 0)
                {
                    var row = NUMBER_IGNORE_ROW;
                    detailSheet.InsertRow(row + 2, resposne.Count - 2, row + 1);
                    foreach (var item in resposne)
                    {
                        detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
                        detailSheet.Cells["C" + row].Value = item.PatientCode;
                        detailSheet.Cells["D" + row].Value = item.FullName;
                        detailSheet.Cells["E" + row].Value = item.Birthday.HasValue ? item.Birthday.Value.ToString("dd/MM/yyyy") : string.Empty;
                        detailSheet.Cells["F" + row].Value = item.Gender == Gender.Male ? "Nam" : "Nữ";
                        detailSheet.Cells["G" + row].Value = item.RegisteredCode;
                        detailSheet.Cells["H" + row].Value = item.CreatedDate.HasValue ? item.CreatedDate.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty;
                        detailSheet.Cells["I" + row].Value = item.RegisteredDate.ToString("dd/MM/yyyy HH:mm");
                        detailSheet.Cells["J" + row].Value = GetNameByStatus(item.Status);
                        detailSheet.Cells["K" + row].Value = item.IsFinished == true ? "Đã hoàn thành" : "Chưa hoàn thành";
                        row++;
                    }

                    detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

                    var indexAddress = row + 1; // Next one rows
                    detailSheet.Cells["K" + indexAddress].Value = "BV.Chợ Rẫy, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                }
                package.Save();
            }

            return new ExportResponse
            {
                FilePath = filePath,
                FileName = fileName
            };
        }

        public ExportResponse ExportPatient(ICollection<PatientInfoViewModel> patients)
        {
            var webRoot = "wwwroot/";
            var fileName = "Tekmedi.DanhSachBenhNhan.xlsx";
            var tempPath = @"templates/" + fileName;
            FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
            if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

            var exportFolder = Path.Combine(webRoot, "export");
            if (!Directory.Exists(exportFolder))
            {
                Directory.CreateDirectory(exportFolder);
            }

            var filePath = @"export/" + fileName;
            var fullPath = Path.Combine(webRoot, filePath);

            FileInfo file = new FileInfo(fullPath);

            if (file.Exists)
            {
                file.Delete();
                tempFile.CopyTo(fullPath);
            }
            else
            {
                tempFile.CopyTo(fullPath);
            }

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];

                if (patients.Count() != 0)
                {
                    var row = NUMBER_IGNORE_ROW;

                    detailSheet.InsertRow(row + 2, patients.Count() - 2, row + 1); // Have two temp rows

                    foreach (var i in patients)
                    {
                        detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
                        detailSheet.Cells["C" + row].Value = i.TekmediCardNumber;
                        detailSheet.Cells["D" + row].Value = i.TekmediId;
                        detailSheet.Cells["E" + row].Value = i.Code;
                        detailSheet.Cells["F" + row].Value = i.FullName;
                        detailSheet.Cells["G" + row].Value = i.Gender;
                        detailSheet.Cells["H" + row].Value = i.Birthday.HasValue ? i.Birthday.Value.ToString("dd/MM/yyyy") : string.Empty;
                        detailSheet.Cells["I" + row].Value = i.ProvinceName;
                        detailSheet.Cells["J" + row].Value = i.DistrictName;
                        detailSheet.Cells["K" + row].Value = i.WardName;
                        detailSheet.Cells["L" + row].Value = i.IdentityCardNumber;
                        detailSheet.Cells["M" + row].Value = i.IdentityCardNumberIssuedDate;
                        detailSheet.Cells["N" + row].Value = i.IdentityCardNumberIssuedPlace;
                        detailSheet.Cells["O" + row].Value = i.Phone;
                        detailSheet.Cells["S" + row].Value = i.HealthInsuranceNumber;
                        detailSheet.Cells["T" + row].Value = i.HealthInsuranceFirstPlaceCode;
                        detailSheet.Cells["U" + row].Value = i.HealthInsuranceFirstPlace;
                        detailSheet.Cells["V" + row].Value = i.HealthInsuranceIssuedDate;
                        detailSheet.Cells["W" + row].Value = i.HealthInsuranceExpiredDate;

                        row++;
                    }

                    detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

                    var indexAddress = row + 1; // Next one rows
                    detailSheet.Cells["T" + indexAddress].Value = "BV.Chợ Rẫy, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    var indexSign = row + 6; // Next six rows
                    //detailSheet.Cells["T" + indexSign].Value = exportRequest.EmployeeName;
                }

                package.Save();
            }

            return new ExportResponse
            {
                FilePath = filePath,
                FileName = fileName
            };
        }

        public ExportResponse ExportBalance(ICollection<PatientInfoViewModel> patients, ExportRequest exportRequest)
        {
            var webRoot = "wwwroot/";
            var tempPath = @"templates/Tekmedi.BC.SoDu_FromDate_ToDate.xlsx";
            FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
            if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

            var fromDate = exportRequest.StartDate.ToString("yyyy-MM-dd");
            var toDate = exportRequest.EndDate.ToString("yyyy-MM-dd");
            var fileName = "Tekmedi.BC.SoDu_" + fromDate + "_" + toDate + ".xlsx";

            var exportFolder = Path.Combine(webRoot, "export");
            if (!Directory.Exists(exportFolder))
            {
                Directory.CreateDirectory(exportFolder);
            }

            var filePath = @"export/" + fileName;
            var fullPath = Path.Combine(webRoot, filePath);

            FileInfo file = new FileInfo(fullPath);

            if (file.Exists)
            {
                file.Delete();
                tempFile.CopyTo(fullPath);
            }
            else
            {
                tempFile.CopyTo(fullPath);
            }

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];
                detailSheet.Cells["B13"].Value = "Từ ngày: " + fromDate + " đến " + toDate;

                if (patients.Count() != 0)
                {
                    var row = NUMBER_IGNORE_ROW;

                    detailSheet.InsertRow(row + 2, patients.Count() - 2, row + 1); // Have two temp rows

                    foreach (var i in patients)
                    {
                        detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
                        detailSheet.Cells["C" + row].Value = i.TekmediCardNumber;
                        detailSheet.Cells["D" + row].Value = i.TekmediId;
                        detailSheet.Cells["E" + row].Value = i.Code;
                        detailSheet.Cells["F" + row].Value = i.FullName;
                        detailSheet.Cells["G" + row].Value = i.Gender;
                        detailSheet.Cells["H" + row].Value = i.Birthday.HasValue ? i.Birthday.Value.ToString("dd/MM/yyyy") : string.Empty;
                        detailSheet.Cells["I" + row].Value = i.IdentityCardNumber;
                        detailSheet.Cells["J" + row].Value = i.Phone;
                        row++;
                    }

                    detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

                    var indexAddress = row + 1; // Next one rows
                    detailSheet.Cells["J" + indexAddress].Value = "BV.Chợ Rẫy, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    var indexSign = row + 6; // Next six rows
                    detailSheet.Cells["J" + indexSign].Value = exportRequest.EmployeeName;
                }

                package.Save();

                return new ExportResponse
                {
                    FilePath = filePath,
                    FileName = fileName
                };
            }
        }

        private string GetNameByStatus(ReceptionStatus receptionStatus)
        {
            return "";
        }

        /// <summary>
        /// Exports the department service.
        /// </summary>
        /// <param name="departmentServices">The department services.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Không tìm thấy file template</exception>
        public ExportResponse ExportDepartmentService(List<DepartmentServiceViewModel> departmentServices)
        {
            var webRoot = "wwwroot/";
            var tempPath = @"templates/Tekmedi.DanhSachPhongKhamDichVu.xlsx";
            FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
            if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

            var fileName = "Tekmedi.DanhSachPhongKhamDichVu.xlsx";

            var exportFolder = Path.Combine(webRoot, "export");
            if (!Directory.Exists(exportFolder))
            {
                Directory.CreateDirectory(exportFolder);
            }

            var filePath = @"export/" + fileName;
            var fullPath = Path.Combine(webRoot, filePath);

            FileInfo file = new FileInfo(fullPath);

            if (file.Exists)
            {
                file.Delete();
                tempFile.CopyTo(fullPath);
            }
            else
            {
                tempFile.CopyTo(fullPath);
            }

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];

                if (departmentServices.Count() != 0)
                {
                    var row = NUMBER_IGNORE_ROW;

                    detailSheet.InsertRow(row + 2, departmentServices.Count() - 2, row + 1); // Have two temp rows

                    foreach (var i in departmentServices)
                    {
                        var usageTypeName = UsageTypeConstants.Normal;
                        if (i.UsageType == UsageType.Service) usageTypeName = UsageTypeConstants.Service;
                        else if (i.UsageType == UsageType.Male) usageTypeName = UsageTypeConstants.Male;
                        else if (i.UsageType == UsageType.Female) usageTypeName = UsageTypeConstants.Female;
                        else usageTypeName = UsageTypeConstants.LDLK;
                        var type = CreatedTypeConstants.Website;
                        if (i.Type == CreatedType.Sync) type = CreatedTypeConstants.Sync;
                        else if (i.Type == CreatedType.ImportExcel) type = CreatedTypeConstants.Excel;

                        detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
                        detailSheet.Cells["C" + row].Value = i.DepartmentCode;
                        detailSheet.Cells["D" + row].Value = i.DepartmentName;
                        detailSheet.Cells["E" + row].Value = i.GroupDeptCode;
                        detailSheet.Cells["F" + row].Value = i.GroupDeptName;
                        detailSheet.Cells["G" + row].Value = i.ExaminationCode;
                        detailSheet.Cells["H" + row].Value = i.ExaminationName;
                        detailSheet.Cells["I" + row].Value = i.ServiceCode;
                        detailSheet.Cells["J" + row].Value = i.ServiceName;
                        detailSheet.Cells["K" + row].Value = usageTypeName;
                        detailSheet.Cells["L" + row].Value = type;
                        detailSheet.Cells["M" + row].Value = i.CreatedDate.ToString("dd/MM/yyyy");
                        row++;
                    }

                    detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

                    var indexAddress = row + 1; // Next one rows
                    detailSheet.Cells["J" + indexAddress].Value = "Bệnh viện K, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    var indexSign = row + 6; // Next six rows
                }

                package.Save();

                return new ExportResponse
                {
                    FilePath = filePath,
                    FileName = fileName
                };
            }
        }

        public string GetFileImportError(List<ImportDepartmentServiceModel> datas)
        {
            var webRoot = "wwwroot/";
            var tempPath = @"templates/Tekmedi.ImportError.xlsx";

            int NUMBER_IGNORE_ROW = 2;
            FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
            if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

            var fileName = "Tekmedi.ImportError.xlsx";
            var exportFolder = Path.Combine(webRoot, "export");

            if (!Directory.Exists(exportFolder))
                Directory.CreateDirectory(exportFolder);

            var filePath = @"export/" + fileName;
            var fullPath = Path.Combine(webRoot, filePath);

            FileInfo file = new FileInfo(fullPath);

            if (file.Exists)
            {
                file.Delete();
                tempFile.CopyTo(fullPath);
            }
            else
                tempFile.CopyTo(fullPath);

            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet detailSheet = package.Workbook.Worksheets[0];

                if (datas.Count > 0)
                {
                    var row = NUMBER_IGNORE_ROW;
                    detailSheet.InsertRow(row + 2, datas.Count - 2, row + 1);
                    foreach (var item in datas)
                    {
                        if (!item.Status)
                        {
                            detailSheet.Cells[row, 1, row, 13].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            detailSheet.Cells[row, 1, row, 13].Style.Fill.BackgroundColor.SetColor(Color.LightGoldenrodYellow);
                        }
                        detailSheet.Cells["A" + row].Value = row - NUMBER_IGNORE_ROW + 1;
                        detailSheet.Cells["B" + row].Value = item.ServiceCode ?? "";
                        detailSheet.Cells["C" + row].Value = item.ServiceName ?? "";
                        detailSheet.Cells["D" + row].Value = item.GroupDeptCode ?? "";
                        detailSheet.Cells["E" + row].Value = item.GroupDeptName ?? "";
                        detailSheet.Cells["F" + row].Value = item.DepartmentCode ?? "";
                        detailSheet.Cells["G" + row].Value = item.DepartmentName ?? "";
                        detailSheet.Cells["H" + row].Value = item.ExaminationCode ?? "";
                        detailSheet.Cells["I" + row].Value = item.ExaminationName ?? "";
                        detailSheet.Cells["J" + row].Value = item.UsageType;
                        detailSheet.Cells["K" + row].Value = item.Status;
                        detailSheet.Cells["L" + row].Value = string.Join(", ", item.Message);
                        detailSheet.Cells["M" + row].Value = string.Join(", ", item.Note);
                        row++;
                    }
                    detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();
                }
                package.Save();
            }
            var scheme = _httpContextAccessor.HttpContext.Request.Scheme;
            var host = _httpContextAccessor.HttpContext.Request.Host;
            var pathBase = _httpContextAccessor.HttpContext.Request.PathBase;
            return $"{scheme}://{host}{pathBase}/{filePath}";
        }

        public ExportResponse ExportOcrSetting(List<OcrSettingViewModel> ocrSettings)
        {
            var webRoot = "wwwroot/";
            var tempPath = @"templates/Tekmedi.CaiDatOCR.xlsx";
            FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
            if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

            var fileName = "Tekmedi.CaiDatOCR.xlsx";

            var exportFolder = Path.Combine(webRoot, "export");
            if (!Directory.Exists(exportFolder))
            {
                Directory.CreateDirectory(exportFolder);
            }

            var filePath = @"export/" + fileName;
            var fullPath = Path.Combine(webRoot, filePath);

            FileInfo file = new FileInfo(fullPath);

            if (file.Exists)
            {
                file.Delete();
                tempFile.CopyTo(fullPath);
            }
            else
            {
                tempFile.CopyTo(fullPath);
            }

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];

                if (ocrSettings.Count() != 0)
                {
                    var row = NUMBER_IGNORE_ROW;

                    detailSheet.InsertRow(row + 2, ocrSettings.Count() - 2, row + 1); // Have two temp rows

                    foreach (var i in ocrSettings)
                    {
                        var typeName = "";
                        if (i.Type == OcrType.VNPT) typeName = OcrTypeConstants.VNPT;
                        else if (i.Type == OcrType.FPT) typeName = OcrTypeConstants.FPT;
                        else if (i.Type == OcrType.GOOGLE) typeName = OcrTypeConstants.GOOGLE;

                        detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
                        detailSheet.Cells["C" + row].Value = i.Description;
                        detailSheet.Cells["D" + row].Value = typeName;
                        detailSheet.Cells["E" + row].Value = !string.IsNullOrEmpty(i.Value.AccessToken) ? i.Value.AccessToken : "";
                        detailSheet.Cells["F" + row].Value = !string.IsNullOrEmpty(i.Value.ApiKey) ? i.Value.ApiKey : "";
                        detailSheet.Cells["G" + row].Value = !string.IsNullOrEmpty(i.Value.TokenId) ? i.Value.TokenId : "";
                        detailSheet.Cells["H" + row].Value = !string.IsNullOrEmpty(i.Value.TokenKey) ? i.Value.TokenKey : "";
                        detailSheet.Cells["I" + row].Value = i.CreatedDate.ToString("dd/MM/yyyy");
                        row++;
                    }

                    detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

                    var indexAddress = row + 1; // Next one rows
                    detailSheet.Cells["J" + indexAddress].Value = "Bệnh viện K, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    var indexSign = row + 6; // Next six rows
                }

                package.Save();

                return new ExportResponse
                {
                    FilePath = filePath,
                    FileName = fileName
                };
            }
        }
    }
}
