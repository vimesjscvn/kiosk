using CS.VM.Models;
using CS.VM.PatientModels;
using CS.VM.Requests;
using CS.VM.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using TEK.Core.Service.Interfaces;

namespace Admin.API.Domain.Services
{
    public class ExportExcelService : IExportExcelService
    {
        /// <summary>
        /// The number ignore row
        /// </summary>
        private readonly int NUMBER_IGNORE_ROW = 16;
        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportExcelService"/> class.
        /// </summary>
        public ExportExcelService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ExportResponse ExportBalance(ICollection<PatientInfoViewModel> patients, ExportRequest exportRequest)
        {
            throw new NotImplementedException();
        }

        public ExportResponse ExportDepartmentService(List<DepartmentServiceViewModel> departmentServices)
        {
            throw new NotImplementedException();
        }

        public ExportResponse ExportOcrSetting(List<OcrSettingViewModel> ocrSettings)
        {
            throw new NotImplementedException();
        }

        public ExportResponse ExportPatient(ICollection<PatientInfoViewModel> patients)
        {
            throw new NotImplementedException();
        }

        public ExportResponse ExportPatientRoom(List<PatientsInRoomViewModel> patientsInRoom)
        {
            throw new NotImplementedException();
        }

        public ExportResponse ExportReception(List<ReceptionReportViewModel> receptionReports)
        {
            throw new NotImplementedException();
        }

        public string GetFileImportError(List<ImportDepartmentServiceModel> datas)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// Exports the patient room.
        ///// </summary>
        ///// <param name="patientsInRoom">The patients in room.</param>
        ///// <returns></returns>
        ///// <exception cref="Exception">Không tìm thấy file template</exception>
        //public ExportResponse ExportPatientRoom(List<PatientsInRoomViewModel> patientsInRoom)
        //{
        //    if (patientsInRoom.Count == 0) throw new Exception(ErrorMessages.NotFoundDataToExport);

        //    var webRoot = "wwwroot/";
        //    var tempPath = @"templates/Tekmedi.STT_NhanBenh_PhongKham.xlsx";
        //    FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
        //    if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

        //    var fileName = "Tekmedi.STT_NhanBenh_PhongKham.xlsx";
        //    var exportFolder = Path.Combine(webRoot, "export");

        //    if (!Directory.Exists(exportFolder))
        //        Directory.CreateDirectory(exportFolder);

        //    var filePath = @"export/" + fileName;
        //    var fullPath = Path.Combine(webRoot, filePath);

        //    FileInfo file = new FileInfo(fullPath);

        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        tempFile.CopyTo(fullPath);
        //    }
        //    else
        //        tempFile.CopyTo(fullPath);

        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;

        //    using (var package = new ExcelPackage(file))
        //    {
        //        ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];
        //        var resposne = patientsInRoom;
        //        if (resposne.Count > 0)
        //        {
        //            var row = NUMBER_IGNORE_ROW;
        //            var index = 1;
        //            foreach (var item in resposne)
        //            {
        //                if (row > 17)
        //                    detailSheet.InsertRow(row, 1, 16);
        //                detailSheet.Cells["B" + row].Value = index;
        //                detailSheet.Cells["C" + row].Value = item.CreatedDate.ToString(DateTimeFormatConstants.YYYYMMDDHHMMSS);
        //                detailSheet.Cells["D" + row].Value = item.FullName;
        //                detailSheet.Cells["E" + row].Value = item.PatientCode;
        //                detailSheet.Cells["F" + row].Value = item.PhoneNumber;
        //                detailSheet.Cells["G" + row].Value = item.BirthdayYearOnly ? item.Birthday.ToString(DateTimeFormatConstants.YYYY) : item.Birthday.ToString(DateTimeFormatConstants.DDMMYYYY);
        //                detailSheet.Cells["H" + row].Value = item.Gender == Gender.Male ? GenderConstants.Male : GenderConstants.Female;
        //                detailSheet.Cells["I" + row].Value = item.ProvinceName;
        //                detailSheet.Cells["J" + row].Value = item.DistrictName;
        //                detailSheet.Cells["K" + row].Value = item.WardName;
        //                detailSheet.Cells["L" + row].Value = item.Street;
        //                detailSheet.Cells["M" + row].Value = CS.Common.Helpers.CommonUtils.GetEnumMemberValue<PatientType>(item.Type);
        //                detailSheet.Cells["N" + row].Value = item.Number;
        //                detailSheet.Cells["O" + row].Value = item.RegisteredDate.ToString(DateTimeFormatConstants.YYYYMMDDHHMMSS);
        //                detailSheet.Cells["P" + row].Value = !string.IsNullOrEmpty(item.DepartmentName) ? $"{item.DepartmentName} - {item.DepartmentCode}" : item.DepartmentCode;
        //                row++;
        //                index++;
        //            }

        //            detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

        //            var indexAddress = row + 3; // Next one rows
        //            detailSheet.Cells["M" + indexAddress].Value = "Bệnh viện K, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //        }
        //        package.Save();
        //    }

        //    return new ExportResponse
        //    {
        //        FilePath = filePath,
        //        FileName = fileName
        //    };
        //}

        ///// <summary>
        ///// Exports the reception.
        ///// </summary>
        ///// <param name="receptionReports">The reception reports.</param>
        ///// <returns></returns>
        ///// <exception cref="Exception">Không tìm thấy file template</exception>
        //public ExportResponse ExportReception(List<ReceptionReportViewModel> receptionReports, ReceptionRequest receptionRequest)
        //{
        //    if (receptionReports.Count == 0) throw new Exception(ErrorMessages.NotFoundDataToExport);

        //    var webRoot = "wwwroot/";
        //    var tempPath = @"templates/Tekmedi.TiepNhanBenh_FromDate_ToDate.xlsx";

        //    FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
        //    if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

        //    var fromDate = receptionRequest.StartDate.Date.ToString("yyyy-MM-dd");
        //    var toDate = receptionRequest.EndDate.Date.ToString("yyyy-MM-dd");

        //    var fileName = "Tekmedi.TiepNhanBenh_" + fromDate + "_" + toDate + ".xlsx";
        //    var exportFolder = Path.Combine(webRoot, "export");

        //    if (!Directory.Exists(exportFolder))
        //        Directory.CreateDirectory(exportFolder);

        //    var filePath = @"export/" + fileName;
        //    var fullPath = Path.Combine(webRoot, filePath);

        //    FileInfo file = new FileInfo(fullPath);

        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        tempFile.CopyTo(fullPath);
        //    }
        //    else
        //        tempFile.CopyTo(fullPath);

        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //    using (var package = new ExcelPackage(file))
        //    {
        //        ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];
        //        detailSheet.Cells["B13"].Value = "Từ ngày: " + fromDate + " đến " + toDate;
        //        var resposne = receptionReports;
        //        if (resposne.Count > 0)
        //        {
        //            var row = NUMBER_IGNORE_ROW;
        //            detailSheet.InsertRow(row + 2, resposne.Count - 2, row + 1);
        //            foreach (var item in resposne)
        //            {
        //                detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
        //                detailSheet.Cells["C" + row].Value = item.PatientCode;
        //                detailSheet.Cells["D" + row].Value = item.FullName;
        //                detailSheet.Cells["E" + row].Value = item.BirthdayYearOnly ? item.Birthday.Value.ToString("yyyy") : item.Birthday.Value.ToString("dd/MM/yyyy");
        //                detailSheet.Cells["F" + row].Value = item.Gender == Gender.Male ? "Nam" : "Nữ";
        //                detailSheet.Cells["G" + row].Value = item.RegisteredCode;
        //                detailSheet.Cells["H" + row].Value = item.RegisteredDate.ToString("dd/MM/yyyy");
        //                detailSheet.Cells["I" + row].Value = item.CreatedDate.Value.ToString("dd/MM/yyyy HH:mm");
        //                detailSheet.Cells["J" + row].Value = GetNameByStatus(item.Status);
        //                detailSheet.Cells["K" + row].Value = item.IsFinished == true ? "Đã hoàn thành" : "Chưa hoàn thành";
        //                row++;
        //            }

        //            detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

        //            var indexAddress = row + 1; // Next one rows
        //            detailSheet.Cells["I" + indexAddress].Value = "Bệnh viện K, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

        //            var indexSign = indexAddress + 2; // Next one rows
        //            detailSheet.Cells["I" + indexSign].Value = receptionRequest.EmployeeName != null ? receptionRequest.EmployeeName : "";
        //        }
        //        package.Save();
        //    }

        //    return new ExportResponse
        //    {
        //        FilePath = filePath,
        //        FileName = fileName
        //    };
        //}

        ///// <summary>
        ///// Exports the patient.
        ///// </summary>
        ///// <param name="patients">The patients.</param>
        ///// <returns></returns>
        ///// <exception cref="Exception">Không tìm thấy file template</exception>
        //public ExportResponse ExportPatient(ICollection<PatientInfoViewModel> patients, ExportRequest request)
        //{
        //    if (patients.Count == 0) throw new Exception(ErrorMessages.NotFoundDataToExport);

        //    var webRoot = "wwwroot/";
        //    var fileName = "Tekmedi.DanhSachBenhNhan.xlsx";
        //    var tempPath = @"templates/" + fileName;
        //    FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
        //    if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

        //    var exportFolder = Path.Combine(webRoot, "export");
        //    if (!Directory.Exists(exportFolder))
        //    {
        //        Directory.CreateDirectory(exportFolder);
        //    }

        //    var filePath = @"export/" + fileName;
        //    var fullPath = Path.Combine(webRoot, filePath);

        //    FileInfo file = new FileInfo(fullPath);

        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        tempFile.CopyTo(fullPath);
        //    }
        //    else
        //    {
        //        tempFile.CopyTo(fullPath);
        //    }

        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //    using (var package = new ExcelPackage(file))
        //    {
        //        ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];

        //        if (patients.Count() != 0)
        //        {
        //            var row = NUMBER_IGNORE_ROW;

        //            detailSheet.InsertRow(row + 2, patients.Count() - 2, row + 1); // Have two temp rows

        //            foreach (var i in patients)
        //            {
        //                detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
        //                detailSheet.Cells["C" + row].Value = i.TekmediCardNumber;
        //                detailSheet.Cells["D" + row].Value = i.Code;
        //                detailSheet.Cells["E" + row].Value = i.FullName;
        //                detailSheet.Cells["F" + row].Value = i.Gender == Gender.Male ? "Nam" : "Nữ";
        //                detailSheet.Cells["G" + row].Value = i.BirthdayYearOnly ? i.Birthday.Value.ToString("yyyy") : i.Birthday.Value.ToString("dd/MM/yyyy");
        //                detailSheet.Cells["H" + row].Value = i.ProvinceName;
        //                detailSheet.Cells["I" + row].Value = i.DistrictName;
        //                detailSheet.Cells["J" + row].Value = i.WardName;
        //                detailSheet.Cells["K" + row].Value = i.IdentityCardNumber;
        //                detailSheet.Cells["L" + row].Value = i.IdentityCardNumberIssuedDate;
        //                detailSheet.Cells["M" + row].Value = i.IdentityCardNumberIssuedPlace;
        //                detailSheet.Cells["N" + row].Value = i.Phone;
        //                detailSheet.Cells["O" + row].Value = i.TopUpAmount;
        //                detailSheet.Cells["P" + row].Value = i.HoldAmount;
        //                detailSheet.Cells["Q" + row].Value = i.FinallyAmount;
        //                detailSheet.Cells["R" + row].Value = i.Balance;
        //                detailSheet.Cells["S" + row].Value = i.HealthInsuranceNumber;
        //                detailSheet.Cells["T" + row].Value = i.HealthInsuranceFirstPlaceCode;
        //                detailSheet.Cells["U" + row].Value = i.HealthInsuranceFirstPlace;
        //                detailSheet.Cells["V" + row].Value = i.HealthInsuranceIssuedDate;
        //                detailSheet.Cells["W" + row].Value = i.HealthInsuranceExpiredDate;

        //                row++;
        //            }

        //            var indexAddress = row + 2; // Next two rows
        //            detailSheet.Cells["T" + indexAddress].Value = "Bệnh viện K, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

        //            var indexSign = row + 4; // Next four rows
        //            detailSheet.Cells["T" + indexSign].Value = request.EmployeeName;
        //            detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();
        //        }

        //        package.Save();
        //    }

        //    return new ExportResponse
        //    {
        //        FilePath = filePath,
        //        FileName = fileName
        //    };
        //}

        ///// <summary>
        ///// Exports the balance.
        ///// </summary>
        ///// <param name="patients">The patients.</param>
        ///// <param name="exportRequest">The export request.</param>
        ///// <returns></returns>
        ///// <exception cref="Exception">Không tìm thấy file template</exception>
        //public ExportResponse ExportBalance(ICollection<PatientInfoViewModel> patients, ExportRequest exportRequest)
        //{
        //    if (patients.Count == 0) throw new Exception(ErrorMessages.NotFoundDataToExport);

        //    var webRoot = "wwwroot/";
        //    var tempPath = @"templates/Tekmedi.BC.SoDu_FromDate_ToDate.xlsx";
        //    FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
        //    if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

        //    var fromDate = exportRequest.StartDate.ToString("yyyy-MM-dd");
        //    var toDate = exportRequest.EndDate.ToString("yyyy-MM-dd");
        //    var fileName = "Tekmedi.BC.SoDu_" + fromDate + "_" + toDate + ".xlsx";

        //    var exportFolder = Path.Combine(webRoot, "export");
        //    if (!Directory.Exists(exportFolder))
        //    {
        //        Directory.CreateDirectory(exportFolder);
        //    }

        //    var filePath = @"export/" + fileName;
        //    var fullPath = Path.Combine(webRoot, filePath);

        //    FileInfo file = new FileInfo(fullPath);

        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        tempFile.CopyTo(fullPath);
        //    }
        //    else
        //    {
        //        tempFile.CopyTo(fullPath);
        //    }

        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //    using (var package = new ExcelPackage(file))
        //    {
        //        ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];
        //        detailSheet.Cells["B13"].Value = "Từ ngày: " + fromDate + " đến " + toDate;

        //        if (patients.Count() != 0)
        //        {
        //            var row = NUMBER_IGNORE_ROW;

        //            detailSheet.InsertRow(row + 2, patients.Count() - 2, row + 1); // Have two temp rows

        //            foreach (var i in patients)
        //            {
        //                detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
        //                detailSheet.Cells["C" + row].Value = i.TekmediCardNumber;
        //                detailSheet.Cells["D" + row].Value = i.Code;
        //                detailSheet.Cells["E" + row].Value = i.FullName;
        //                detailSheet.Cells["F" + row].Value = i.Gender;
        //                detailSheet.Cells["G" + row].Value = i.BirthdayYearOnly ? i.Birthday.ToString("yyyy") : i.Birthday.ToString("dd/MM/yyyy");
        //                detailSheet.Cells["H" + row].Value = i.IdentityCardNumber;
        //                detailSheet.Cells["I" + row].Value = i.Phone;
        //                detailSheet.Cells["J" + row].Value = i.TopUpAmount;
        //                detailSheet.Cells["K" + row].Value = i.PaymentAmount;
        //                detailSheet.Cells["L" + row].Value = i.Balance;

        //                row++;
        //            }

        //            detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

        //            var indexAddress = row + 2; // Next two rows
        //            detailSheet.Cells["J" + indexAddress].Value = "Bệnh viện K, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

        //            var indexSign = row + 4; // Next four rows
        //            detailSheet.Cells["J" + indexSign].Value = exportRequest.EmployeeName;
        //        }

        //        package.Save();

        //        return new ExportResponse
        //        {
        //            FilePath = filePath,
        //            FileName = fileName
        //        };
        //    }
        //}

        ///// <summary>
        ///// Exports the department service.
        ///// </summary>
        ///// <param name="departmentServices">The department services.</param>
        ///// <returns></returns>
        ///// <exception cref="Exception">Không tìm thấy file template</exception>
        //public ExportResponse ExportDepartmentService(List<DepartmentServiceViewModel> departmentServices)
        //{
        //    if (departmentServices.Count == 0) throw new Exception(ErrorMessages.NotFoundDataToExport);

        //    var webRoot = "wwwroot/";
        //    var tempPath = @"templates/Tekmedi.DanhSachPhongKhamDichVu.xlsx";
        //    FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
        //    if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

        //    var fileName = "Tekmedi.DanhSachPhongKhamDichVu.xlsx";

        //    var exportFolder = Path.Combine(webRoot, "export");
        //    if (!Directory.Exists(exportFolder))
        //    {
        //        Directory.CreateDirectory(exportFolder);
        //    }

        //    var filePath = @"export/" + fileName;
        //    var fullPath = Path.Combine(webRoot, filePath);

        //    FileInfo file = new FileInfo(fullPath);

        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        tempFile.CopyTo(fullPath);
        //    }
        //    else
        //    {
        //        tempFile.CopyTo(fullPath);
        //    }

        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //    using (var package = new ExcelPackage(file))
        //    {
        //        ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];

        //        if (departmentServices.Count() != 0)
        //        {
        //            var row = NUMBER_IGNORE_ROW;

        //            detailSheet.InsertRow(row + 2, departmentServices.Count() - 2, row + 1); // Have two temp rows

        //            foreach (var i in departmentServices)
        //            {
        //                var usageTypeName = UsageTypeConstants.Normal;
        //                if (i.UsageType == UsageType.Service) usageTypeName = UsageTypeConstants.Service;
        //                else if (i.UsageType == UsageType.Male) usageTypeName = UsageTypeConstants.Male;
        //                else if (i.UsageType == UsageType.Female) usageTypeName = UsageTypeConstants.Female;
        //                else usageTypeName = UsageTypeConstants.LDLK;
        //                var type = CreatedTypeConstants.Website;
        //                if (i.Type == CreatedType.Sync) type = CreatedTypeConstants.Sync;
        //                else if (i.Type == CreatedType.ImportExcel) type = CreatedTypeConstants.Excel;

        //                detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
        //                detailSheet.Cells["C" + row].Value = i.DepartmentCode;
        //                detailSheet.Cells["D" + row].Value = i.DepartmentName;
        //                detailSheet.Cells["E" + row].Value = i.RoomCode;
        //                detailSheet.Cells["F" + row].Value = i.RoomName;
        //                detailSheet.Cells["G" + row].Value = i.ExaminationCode;
        //                detailSheet.Cells["H" + row].Value = i.ExaminationName;
        //                detailSheet.Cells["I" + row].Value = i.ServiceCode;
        //                detailSheet.Cells["J" + row].Value = i.ServiceName;
        //                detailSheet.Cells["K" + row].Value = usageTypeName;
        //                detailSheet.Cells["L" + row].Value = type;
        //                detailSheet.Cells["M" + row].Value = i.CreatedDate.ToString("dd/MM/yyyy");
        //                row++;
        //            }

        //            detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

        //            var indexAddress = row + 1; // Next one rows
        //            detailSheet.Cells["J" + indexAddress].Value = "Bệnh viện K, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

        //            var indexSign = row + 6; // Next six rows
        //        }

        //        package.Save();

        //        return new ExportResponse
        //        {
        //            FilePath = filePath,
        //            FileName = fileName
        //        };
        //    }
        //}

        //public string GetFileImportError(List<ImportDepartmentServiceModel> datas)
        //{
        //    var webRoot = "wwwroot/";
        //    var tempPath = @"templates/Tekmedi.ImportError.xlsx";

        //    int NUMBER_IGNORE_ROW = 2;
        //    FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
        //    if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

        //    var fileName = "Tekmedi.ImportError.xlsx";
        //    var exportFolder = Path.Combine(webRoot, "export");

        //    if (!Directory.Exists(exportFolder))
        //        Directory.CreateDirectory(exportFolder);

        //    var filePath = @"export/" + fileName;
        //    var fullPath = Path.Combine(webRoot, filePath);

        //    FileInfo file = new FileInfo(fullPath);

        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        tempFile.CopyTo(fullPath);
        //    }
        //    else
        //        tempFile.CopyTo(fullPath);

        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;

        //    using (var package = new ExcelPackage(file))
        //    {
        //        ExcelWorksheet detailSheet = package.Workbook.Worksheets[0];

        //        if (datas.Count > 0)
        //        {
        //            var row = NUMBER_IGNORE_ROW;
        //            detailSheet.InsertRow(row + 2, datas.Count - 2, row + 1);
        //            foreach (var item in datas)
        //            {
        //                if (!item.Status)
        //                {
        //                    detailSheet.Cells[row, 1, row, 13].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //                    detailSheet.Cells[row, 1, row, 13].Style.Fill.BackgroundColor.SetColor(Color.LightGoldenrodYellow);
        //                }
        //                detailSheet.Cells["A" + row].Value = row - NUMBER_IGNORE_ROW + 1;
        //                detailSheet.Cells["B" + row].Value = item.ServiceCode ?? "";
        //                detailSheet.Cells["C" + row].Value = item.ServiceName ?? "";
        //                detailSheet.Cells["D" + row].Value = item.DepartmentCode ?? "";
        //                detailSheet.Cells["E" + row].Value = item.DepartmentName ?? "";
        //                detailSheet.Cells["F" + row].Value = item.ExaminationCode ?? "";
        //                detailSheet.Cells["G" + row].Value = item.ExaminationName ?? "";
        //                detailSheet.Cells["H" + row].Value = item.Status;
        //                detailSheet.Cells["I" + row].Value = string.Join(", ", item.Message);
        //                detailSheet.Cells["J" + row].Value = string.Join(", ", item.Note);
        //                row++;
        //            }
        //            detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();
        //        }
        //        package.Save();
        //    }
        //    var scheme = _httpContextAccessor.HttpContext.Request.Scheme;
        //    var host = _httpContextAccessor.HttpContext.Request.Host;
        //    var pathBase = _httpContextAccessor.HttpContext.Request.PathBase;
        //    return $"{scheme}://{host}{pathBase}/{filePath}";
        //}

        //public ExportResponse ExportOcrSetting(List<OcrSettingViewModel> ocrSettings)
        //{
        //    if (ocrSettings.Count == 0) throw new Exception(ErrorMessages.NotFoundDataToExport);

        //    var webRoot = "wwwroot/";
        //    var tempPath = @"templates/Tekmedi.CaiDatOCR.xlsx";
        //    FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
        //    if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

        //    var fileName = "Tekmedi.CaiDatOCR.xlsx";

        //    var exportFolder = Path.Combine(webRoot, "export");
        //    if (!Directory.Exists(exportFolder))
        //    {
        //        Directory.CreateDirectory(exportFolder);
        //    }

        //    var filePath = @"export/" + fileName;
        //    var fullPath = Path.Combine(webRoot, filePath);

        //    FileInfo file = new FileInfo(fullPath);

        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        tempFile.CopyTo(fullPath);
        //    }
        //    else
        //    {
        //        tempFile.CopyTo(fullPath);
        //    }

        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //    using (var package = new ExcelPackage(file))
        //    {
        //        ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];

        //        if (ocrSettings.Count() != 0)
        //        {
        //            var row = NUMBER_IGNORE_ROW;

        //            detailSheet.InsertRow(row + 2, ocrSettings.Count() - 2, row + 1); // Have two temp rows

        //            foreach (var i in ocrSettings)
        //            {
        //                var typeName = "";
        //                if (i.Type == OcrType.VNPT) typeName = OcrTypeConstants.VNPT;
        //                else if (i.Type == OcrType.FPT) typeName = OcrTypeConstants.FPT;
        //                else if (i.Type == OcrType.GOOGLE) typeName = OcrTypeConstants.GOOGLE;

        //                detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
        //                detailSheet.Cells["C" + row].Value = i.Description;
        //                detailSheet.Cells["D" + row].Value = typeName;
        //                detailSheet.Cells["E" + row].Value = !string.IsNullOrEmpty(i.Value.AccessToken) ? i.Value.AccessToken : "";
        //                detailSheet.Cells["F" + row].Value = !string.IsNullOrEmpty(i.Value.ApiKey) ? i.Value.ApiKey : "";
        //                detailSheet.Cells["G" + row].Value = !string.IsNullOrEmpty(i.Value.TokenId) ? i.Value.TokenId : "";
        //                detailSheet.Cells["H" + row].Value = !string.IsNullOrEmpty(i.Value.TokenKey) ? i.Value.TokenKey : "";
        //                detailSheet.Cells["I" + row].Value = i.CreatedDate.ToString("dd/MM/yyyy");
        //                row++;
        //            }

        //            detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

        //            var indexAddress = row + 1; // Next one rows
        //            detailSheet.Cells["J" + indexAddress].Value = "Bệnh viện K, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

        //            var indexSign = row + 6; // Next six rows
        //        }

        //        package.Save();

        //        return new ExportResponse
        //        {
        //            FilePath = filePath,
        //            FileName = fileName
        //        };
        //    }
        //}

        ///// <summary>
        ///// Gets the name by status.
        ///// </summary>
        ///// <param name="receptionStatus">The reception status.</param>
        ///// <returns></returns>
        //private string GetNameByStatus(ReceptionStatus receptionStatus)
        //{
        //    return "";
        //}

        ///// <summary>
        ///// Export Endoscopic Patient Room
        ///// </summary>
        ///// <param name="patientsInRoom"></param>
        ///// <returns></returns>
        //public ExportResponse ExportEndoscopicPatientRoom(List<PatientsInRoomEndoscopicViewModel> patientsInRoom)
        //{
        //    var webRoot = "wwwroot/";
        //    var tempPath = @"templates/Tekmedi.STT_NhanBenh_PhongKhamNoiSoi.xlsx";

        //    FileInfo tempFile = new FileInfo(Path.Combine(webRoot, tempPath));
        //    if (!tempFile.Exists) throw new Exception("Không tìm thấy file template");

        //    var fileName = "Tekmedi.STT_NhanBenh_PhongKhamNoiSoi.xlsx";
        //    var exportFolder = Path.Combine(webRoot, "export");

        //    if (!Directory.Exists(exportFolder))
        //        Directory.CreateDirectory(exportFolder);

        //    var filePath = @"export/" + fileName;
        //    var fullPath = Path.Combine(webRoot, filePath);

        //    FileInfo file = new FileInfo(fullPath);

        //    if (file.Exists)
        //    {
        //        file.Delete();
        //        tempFile.CopyTo(fullPath);
        //    }
        //    else
        //        tempFile.CopyTo(fullPath);

        //    ExcelPackage.LicenseContext = LicenseContext.Commercial;

        //    using (var package = new ExcelPackage(file))
        //    {
        //        ExcelWorksheet detailSheet = package.Workbook.Worksheets["Chi Tiết"];

        //        var resposne = patientsInRoom;
        //        if (resposne.Count > 0)
        //        {
        //            var row = NUMBER_IGNORE_ROW;
        //            detailSheet.InsertRow(row + 2, resposne.Count - 2, row + 1);
        //            foreach (var item in resposne)
        //            {
        //                detailSheet.Cells["B" + row].Value = row - NUMBER_IGNORE_ROW + 1;
        //                detailSheet.Cells["C" + row].Value = item.CreatedDate.ToString(DateTimeFormatConstants.DDMMYYYY);
        //                detailSheet.Cells["D" + row].Value = item.FullName;
        //                detailSheet.Cells["E" + row].Value = item.PhoneNumber;
        //                detailSheet.Cells["F" + row].Value = item.Birthday?.ToString(DateTimeFormatConstants.DDMMYYYY);
        //                detailSheet.Cells["G" + row].Value = item.Gender == Gender.Male ? GenderConstants.Male : GenderConstants.Female;
        //                detailSheet.Cells["H" + row].Value = item.ProvinceName;
        //                detailSheet.Cells["I" + row].Value = item.DistrictName;
        //                detailSheet.Cells["J" + row].Value = item.WardName;
        //                detailSheet.Cells["K" + row].Value = item.Street;
        //                detailSheet.Cells["L" + row].Value = item.Number;
        //                detailSheet.Cells["M" + row].Value = item.RegisteredDate.ToString(DateTimeFormatConstants.DDMMYYYY);
        //                detailSheet.Cells["N" + row].Value = !string.IsNullOrEmpty(item.DepartmentVirtualName) ? $"{item.DepartmentVirtualName} - {item.DepartmentVirtualCode}" : item.DepartmentVirtualCode;
        //                detailSheet.Cells["O" + row].Value = !string.IsNullOrEmpty(item.DepartmentName) ? $"{item.DepartmentName} - {item.DepartmentCode}" : item.DepartmentCode;
        //                row++;
        //            }

        //            detailSheet.Cells[detailSheet.Dimension.Address].AutoFitColumns();

        //            var indexAddress = row + 1; // Next one rows
        //            detailSheet.Cells["K" + indexAddress].Value = "Bệnh viện K, Ngày " + DateTime.Now.ToString("dd") + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
        //        }
        //        package.Save();
        //    }

        //    return new ExportResponse
        //    {
        //        FilePath = filePath,
        //        FileName = fileName
        //    };
        //}
    }
}
