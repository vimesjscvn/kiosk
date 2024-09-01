using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Core.Service.Interfaces;
using CS.Common.Common;
using CS.VM.Models;
using CS.VM.PatientModels;
using CS.VM.Requests;

namespace Core.Service.Implements
{
    public class TemplateGenerator : ITemplateGenerator
    {
        public string GeneratorAdminHistoryCardHtml(string webRoot,
            List<StatisticalViewModel> data, ExportRequest exportRequest
        )
        {
            var sb = new StringBuilder();

            var dataGroupByEmloyee = data.GroupBy(i => new { i.EmployeeId, i.EmployeeName },
                (key, g) => new
                    { key.EmployeeId, key.EmployeeName, Historys = g.ToList() });
            ;
            var dataGroupByPaymentType = data.GroupBy(x => x.Manipulation).ToList();
            var base64Image = "";
            var numberGroup = dataGroupByEmloyee.Count();
            decimal? totalRecharged = data.Where(x => x.Manipulation == Constants.ManipulationContent.Recharged)
                .Sum(x => x.Price);
            decimal? totalReturn = data.Where(x => x.Manipulation == Constants.ManipulationContent.Return)
                .Sum(x => x.Price);
            decimal? totalCardFee = data.Where(x => x.Manipulation == Constants.ManipulationContent.CardFee)
                .Sum(x => x.Price);
            var totalForHospital = totalRecharged - totalReturn - totalCardFee;
            using (var image = Image.FromFile(Path.Combine(webRoot, @"templates/tekmedi.png")))
            {
                using (var m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    var imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    var base64String = Convert.ToBase64String(imageBytes);
                    base64Image = base64String;
                }
            }

            sb.Append(@"<style> html, body { height: initial!important; overflow: initial!important; }");
            sb.Append(@"table, td, th {border: 1px solid black;}");
            sb.Append(@"table {text-align: center;width: 100%;border-collapse: collapse;margin-bottom : 40px}");
            sb.Append(
                @".tag-td {font-size: 12px;padding : 4px;text-align: center;background-color: red!important;color: white!important;}");
            sb.Append(
                @".tag-td-data {font-size: 8px;text-align: center;background-color: white!important;color: black!important;}");
            sb.Append(@".tag-td-data-date {padding : 10px;}");
            sb.Append(
                @".tag-td-title {font-size: 15px;text-align: left;background-color: white!important;color: black!important; font-weight: bold;}");
            sb.Append(
                @".sign {font-size: 12px;padding : 5px;text-align: center;background-color: white!important;color: black!important;");
            sb.Append(@"</style>");

            sb.Append(@"<header>");
            sb.Append(@"<div style='display:flex;'>");
            sb.AppendFormat(@"<img src=data:image/png;base64,{0} width =113 height = 83 hspace=51 vspace =13>",
                base64Image);
            sb.Append(
                @"<div width=113 height=83 hspace=51 vspace=13> <p> TEKMEDI JSC </p><p> The Sun Avenue SAV8 - 22.08, Số 28, Đường Mai Chí Thọ, Phường An Phú, Quận 2, Thành phố Hồ Chí Minh </p>");
            sb.Append(
                @"<p> www.tekmedi.com &nbsp&nbsp &nbsp   service @tekmedi.com &nbsp &nbsp &nbsp(028) 3 930 1439 </p></div></div></br></br>");
            sb.Append(@"<div style='text-align:center;'>");
            sb.Append(@"<b> THỐNG KÊ CHI TIẾT GHI - NẠP - MẤT - TRẢ THẺ </b>");
            sb.Append(@"</div><div style='text-align:left;'><b> Thông tin giao dịch </b></div></br><div>");
            sb.AppendFormat(@"<b> Từ ngày: {0} đến ngày {1}</b>",
                exportRequest.StartDate.ToString("dd-MM-yyyy"),
                exportRequest.EndDate.ToString("dd-MM-yyyy"));
            sb.Append(@"</header>");
            sb.AppendFormat(@"<table '>");
            sb.Append(@"<tr>");
            sb.Append(@"<td class='tag-td' rowspan='2' colspan='2'>Nhân viên giao dịch</td>");
            sb.Append(@"<td class='tag-td' colspan='2'>Thống kê ghi thẻ</td>");
            sb.Append(@"<td class='tag-td' colspan='2'>Thống kê nạp tiền vào thẻ(*)</td>");
            sb.Append(@"<td class='tag-td' colspan='2'>Thống kê trả thẻ</td>");
            sb.Append(@"<td class='tag-td' colspan='2'>Thống kê mất thẻ</td>");
            sb.Append(@"</tr>");

            sb.Append(@"<tr>");
            sb.Append(@"<td class='tag-td' >Số lần ghi thẻ</td>");
            sb.Append(@"<td class='tag-td' >Tổng số tiền</td>");
            sb.Append(@"<td class='tag-td' >Số lần nạp tiền</td>");
            sb.Append(@"<td class='tag-td' >Tổng số tiền</td>");
            sb.Append(@"<td class='tag-td' >Số lần trả thẻ</td>");
            sb.Append(@"<td class='tag-td' >Tổng số tiền</td>");
            sb.Append(@"<td class='tag-td' >Số lần mất thẻ</td>");
            sb.Append(@"<td class='tag-td' >Tổng số tiền</td>");
            sb.Append(@"</tr>");


            for (var i = 0; i < numberGroup; i++)
            {
                var item = dataGroupByEmloyee.ElementAt(i);
                sb.Append(@"<tr>");
                sb.AppendFormat(@"<td class='tag-td-data' colspan='2' >{0}</td>", item.EmployeeName);
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                    item.Historys.Count(h => h.Manipulation == Constants.ManipulationContent.Register));
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                    item.Historys.Where(h => h.Manipulation == Constants.ManipulationContent.Register)
                        .Select(h => h.Price).Sum().ToString("#,##0"));
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                    item.Historys.Count(h => h.Manipulation == Constants.ManipulationContent.Recharged));
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                    item.Historys.Where(h => h.Manipulation == Constants.ManipulationContent.Recharged)
                        .Select(h => h.Price).Sum().ToString("#,##0"));
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                    item.Historys.Count(h => h.Manipulation == Constants.ManipulationContent.Return));
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                    item.Historys.Where(h => h.Manipulation == Constants.ManipulationContent.Return)
                        .Select(h => h.Price).Sum().ToString("#,##0"));
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                    item.Historys.Count(h => h.Manipulation == Constants.ManipulationContent.CardFee));
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                    item.Historys.Where(h => h.Manipulation == Constants.ManipulationContent.CardFee)
                        .Select(h => h.Price).Sum().ToString("#,##0"));
                sb.Append(@"</tr>");
            }

            sb.Append(@"</table>");

            sb.Append(@"<div style='float: left;text-align: left;margin-top: -10px;'>");
            sb.Append(@"<div style='display: inline-block;font-size: 15px; font-weight: bold;'>");
            sb.Append(@"<span >Tổng tiền nộp phòng tài chính :</span>");
            sb.AppendFormat(@"<span> {0} VNĐ</span>", totalForHospital.Value.ToString("#,##0"));
            sb.Append(@"</div>");
            sb.Append(@"</br>");
            sb.Append(@"<div style='display: inline-block;font-size: 15px; font-weight: bold;'>");
            sb.Append(@"<span>Tổng tiền nộp Tekmedi :</span>");
            sb.AppendFormat(@"<span> {0} VNĐ</span>", totalCardFee.Value.ToString("#,##0"));
            sb.Append(@"</div>");
            sb.Append(@"</div>");


            sb.Append(@"<table>");
            sb.Append(@"<tr>");
            sb.Append(@"<td class='tag-td'>Stt</td>");
            sb.Append(@"<td class='tag-td'>Mã thẻ BN</td>");
            sb.Append(@"<td class='tag-td'>Mã bệnh nhân</td>");
            sb.Append(@"<td class='tag-td'>Tên bệnh nhân</td>");
            sb.Append(@"<td class='tag-td'>Ngày giờ</td>");
            sb.Append(@"<td class='tag-td'>Loại hình</td>");
            sb.Append(@"<td class='tag-td'>Số tiền</td>");
            sb.Append(@"</tr>");

            for (var j = 0; j < dataGroupByPaymentType.Count(); j++)
            {
                var item = dataGroupByPaymentType.ElementAt(j);
                sb.AppendFormat(@"<tr><td colspan='6' class='tag-td-title'>{0}</td>",
                    item.Key == "Phí phát thẻ mới" ? "Mất thẻ".ToUpper() : item.Key.ToUpper());
                sb.AppendFormat(@"<td>{0}</td></tr>", item.Sum(x => x.Price).ToString("#,##0"));
                var index = 0;
                foreach (var dataInItem in item)
                {
                    sb.Append(@"<tr>");
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", index + 1);
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.TekmediCardNumber);
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.Code);
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.Name);
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.Time.ToString("dd-MM-yyyy"));
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.PaymentType);
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.Price.ToString("#,##0"));
                    sb.Append(@"</tr>");
                    index++;
                }
            }

            sb.Append(@"</table>");
            sb.Append(@"<div style='float: right;text-align: center;padding :10px;'>");
            sb.AppendFormat(@"<span style='margin-bottom : 15px;display:block'>{0}</span>", exportRequest.EmployeeName);
            sb.Append(@"</br>");
            sb.AppendFormat(@"<span>Bệnh viện K, ngày {0} tháng {1} năm {2}</span>", DateTime.Now.Day,
                DateTime.Now.Month, DateTime.Now.Year);
            sb.Append(@"</div>");
            return sb.ToString();
        }


        public string GeneratorHistoryCardByEmployeeHtml(string webRoot,
            List<StatisticalViewModel> data, ExportRequest exportRequest
        )
        {
            var sb = new StringBuilder();
            var base64Image = "";
            var dataGroupByPaymentType = data.GroupBy(x => x.Manipulation).ToList();
            decimal? totalRecharged = data.Where(x => x.Manipulation == Constants.ManipulationContent.Recharged)
                .Sum(x => x.Price);
            decimal? totalReturn = data.Where(x => x.Manipulation == Constants.ManipulationContent.Return)
                .Sum(x => x.Price);
            decimal? totalCardFee = data.Where(x => x.Manipulation == Constants.ManipulationContent.CardFee)
                .Sum(x => x.Price);
            var totalForHospital = totalRecharged - totalReturn - totalCardFee;
            using (var image = Image.FromFile(Path.Combine(webRoot, @"templates/tekmedi.png")))
            {
                using (var m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    var imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    var base64String = Convert.ToBase64String(imageBytes);
                    base64Image = base64String;
                }
            }

            sb.Append(@"<style> html, body { height: initial!important; overflow: initial!important; }");
            sb.Append(@"table, td, th {border: 1px solid black;}");
            sb.Append(@"table {text-align: center;width: 100%;border-collapse: collapse;margin-bottom : 40px}");
            sb.Append(
                @".tag-td {font-size: 12px;padding : 4px;text-align: center;background-color: red!important;color: white!important;");
            sb.Append(
                @".tag-td-data {font-size: 8px;text-align: center;background-color: white!important;color: black!important;");
            sb.Append(@".tag-td-data-date {padding : 10px;");
            sb.Append(
                @".sign {font-size: 12px;padding : 5px;text-align: center;background-color: white!important;color: black!important;");
            sb.Append(@"</style>");

            sb.Append(@"<header>");
            sb.Append(@"<div style='display:flex;'>");
            sb.AppendFormat(@"<img src=data:image/png;base64,{0} width =113 height = 83 hspace=51 vspace =13>",
                base64Image);
            sb.Append(
                @"<div width=113 height=83 hspace=51 vspace=13> <p> TEKMEDI JSC </p><p> The Sun Avenue SAV8 - 22.08, Số 28, Đường Mai Chí Thọ, Phường An Phú, Quận 2, Thành phố Hồ Chí Minh </p>");
            sb.Append(
                @"<p> www.tekmedi.com &nbsp&nbsp &nbsp   service @tekmedi.com &nbsp &nbsp &nbsp(028) 3 930 1439 </p></div></div></br></br>");
            sb.Append(@"<div style='text-align:center;'>");
            sb.Append(@"<b> THỐNG KÊ CHI TIẾT GHI - NẠP - MẤT - TRẢ THẺ </b>");
            sb.Append(@"</div><div style='text-align:left;'><b> Thông tin giao dịch </b></div></br><div>");
            sb.AppendFormat(@"<b> Từ ngày: {0} đến ngày {1}</b>",
                exportRequest.StartDate.ToString("dd-MM-yyyy"),
                exportRequest.EndDate.ToString("dd-MM-yyyy"));
            sb.Append(@"</header>");
            sb.AppendFormat(@"<table '>");
            sb.Append(@"<tr>");
            sb.Append(@"<td class='tag-td' rowspan='2' colspan='2'>Nhân viên giao dịch</td>");
            sb.Append(@"<td class='tag-td' colspan='2'>Thống kê ghi thẻ</td>");
            sb.Append(@"<td class='tag-td' colspan='2'>Thống kê nạp tiền vào thẻ(*)</td>");
            sb.Append(@"<td class='tag-td' colspan='2'>Thống kê trả thẻ</td>");
            sb.Append(@"<td class='tag-td' colspan='2'>Thống kê mất thẻ phát mới</td>");
            sb.Append(@"</tr>");

            sb.Append(@"<tr>");
            sb.Append(@"<td class='tag-td' >Số lần ghi thẻ</td>");
            sb.Append(@"<td class='tag-td' >Tổng số tiền ghi thẻ</td>");
            sb.Append(@"<td class='tag-td' >Số lần nạp tiền</td>");
            sb.Append(@"<td class='tag-td' >Tổng số tiền nạp</td>");
            sb.Append(@"<td class='tag-td' >Số lần trả thẻ</td>");
            sb.Append(@"<td class='tag-td' >Tổng số tiền trả thẻ</td>");
            sb.Append(@"<td class='tag-td' >Số lần mất thẻ phát mới</td>");
            sb.Append(@"<td class='tag-td' >Tổng số tiền mất thẻ phát mới</td>");
            sb.Append(@"</tr>");


            sb.Append(@"<tr>");
            sb.AppendFormat(@"<td class='tag-td-data' colspan='2' >{0}</td>", exportRequest.EmployeeName);
            sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                data.Count(h => h.Manipulation == Constants.ManipulationContent.Register));
            sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                data.Where(h => h.Manipulation == Constants.ManipulationContent.Register).Select(h => h.Price).Sum()
                    .ToString("#,##0"));
            sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                data.Count(h => h.Manipulation == Constants.ManipulationContent.Recharged));
            sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                data.Where(h => h.Manipulation == Constants.ManipulationContent.Recharged).Select(h => h.Price).Sum()
                    .ToString("#,##0"));
            sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                data.Count(h => h.Manipulation == Constants.ManipulationContent.Return));
            sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                data.Where(h => h.Manipulation == Constants.ManipulationContent.Return).Select(h => h.Price).Sum()
                    .ToString("#,##0"));
            sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                data.Count(h => h.Manipulation == Constants.ManipulationContent.CardFee));
            sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                data.Where(h => h.Manipulation == Constants.ManipulationContent.CardFee).Select(h => h.Price).Sum()
                    .ToString("#,##0"));
            sb.Append(@"</tr>");
            sb.Append(@"</table>");

            sb.Append(@"<div style='float: left;text-align: left;margin-top: -10px;'>");
            sb.Append(@"<div style='display: inline-block;font-size: 15px; font-weight: bold;'>");
            sb.Append(@"<span >Tổng tiền nộp phòng tài chính :</span>");
            sb.AppendFormat(@"<span> {0} VNĐ</span>", totalForHospital.Value.ToString("#,##0"));
            sb.Append(@"</div>");
            sb.Append(@"</br>");
            sb.Append(@"<div style='display: inline-block;font-size: 15px; font-weight: bold;'>");
            sb.Append(@"<span>Tổng tiền nộp Tekmedi :</span>");
            sb.AppendFormat(@"<span> {0} VNĐ</span>", totalCardFee.Value.ToString("#,##0"));
            sb.Append(@"</div>");
            sb.Append(@"</div>");


            sb.Append(@"<table>");
            sb.Append(@"<tr>");
            sb.Append(@"<td class='tag-td'>Stt</td>");
            sb.Append(@"<td class='tag-td'>Mã thẻ BN</td>");
            sb.Append(@"<td class='tag-td'>Mã bệnh nhân</td>");
            sb.Append(@"<td class='tag-td'>Tên bệnh nhân</td>");
            sb.Append(@"<td class='tag-td'>Ngày giờ</td>");
            sb.Append(@"<td class='tag-td'>Loại hình</td>");
            sb.Append(@"<td class='tag-td'>Số tiền</td>");
            sb.Append(@"</tr>");

            for (var j = 0; j < dataGroupByPaymentType.Count(); j++)
            {
                var item = dataGroupByPaymentType.ElementAt(j);
                sb.AppendFormat(@"<tr><td colspan='6' class='tag-td-title'>{0}</td>",
                    item.Key == "Phí phát thẻ mới" ? "Mất thẻ".ToUpper() : item.Key.ToUpper());
                sb.AppendFormat(@"<td>{0}</td></tr>", item.Sum(x => x.Price).ToString("#,##0"));
                var index = 0;
                foreach (var dataInItem in item)
                {
                    sb.Append(@"<tr>");
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", index + 1);
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.TekmediCardNumber);
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.Code);
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.Name);
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.Time.ToString("dd-MM-yyyy"));
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.PaymentType);
                    sb.AppendFormat(@"<td class='tag-td-data'>{0}</td>", dataInItem.Price.ToString("#,##0"));
                    sb.Append(@"</tr>");
                    index++;
                }
            }

            sb.Append(@"</table>");
            sb.Append(@"<div style='float: right;text-align: center;padding :10px;'>");
            sb.AppendFormat(@"<span style='margin-bottom : 15px;display:block'>{0}</span>", exportRequest.EmployeeName);
            sb.Append(@"</br>");
            sb.AppendFormat(@"<span>Bệnh viện K, ngày {0} tháng {1} năm {2}</span>", DateTime.Now.Day,
                DateTime.Now.Month, DateTime.Now.Year);
            sb.Append(@"</div>");
            return sb.ToString();
        }


        public string GeneratorExportBalanceHtml(string webRoot,
            List<PatientInfoViewModel> data, ExportRequest exportRequest
        )
        {
            if (data.Count == 0) throw new Exception(ErrorMessages.NotFoundDataToExport);

            var sb = new StringBuilder();
            var base64Image = "";
            using (var image = Image.FromFile(Path.Combine(webRoot, @"templates/tekmedi.png")))
            {
                using (var m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    var imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    var base64String = Convert.ToBase64String(imageBytes);
                    base64Image = base64String;
                }
            }

            sb.Append(@"<style> html, body { height: initial!important; overflow: initial!important; }");
            sb.Append(@"table, td, th {border: 1px solid black;}");
            sb.Append(@"table {text-align: center;width: 100%;border-collapse: collapse;margin-bottom : 40px}");
            sb.Append(
                @".tag-td {font-size: 12px;padding : 4px;text-align: center;background-color: red!important;color: white!important;");
            sb.Append(
                @".tag-td-data {font-size: 8px;text-align: center;background-color: white!important;color: black!important;");
            sb.Append(@".tag-td-data-date {padding : 10px;");
            sb.Append(
                @".sign {font-size: 12px;padding : 5px;text-align: center;background-color: white!important;color: black!important;");
            sb.Append(@"</style>");

            sb.Append(@"<header>");
            sb.Append(@"<div style='display:flex;'>");
            sb.AppendFormat(@"<img src=data:image/png;base64,{0} width =113 height = 83 hspace=51 vspace =13>",
                base64Image);
            sb.Append(
                @"<div width=113 height=83 hspace=51 vspace=13> <p> TEKMEDI JSC </p><p> The Sun Avenue SAV8 - 22.08, Số 28, Đường Mai Chí Thọ, Phường An Phú, Quận 2, Thành phố Hồ Chí Minh </p>");
            sb.Append(
                @"<p> www.tekmedi.com &nbsp&nbsp &nbsp   service @tekmedi.com &nbsp &nbsp &nbsp(028) 3 930 1439 </p></div></div></br></br>");
            sb.Append(@"<div style='text-align:center;'>");
            sb.Append(@"<b> DANH SÁCH BỆNH NHÂN </b>");
            sb.Append(@"</div><div style='text-align:left;'><b> Thông tin giao dịch </b></div></br><div>");
            sb.AppendFormat(@"<b> Từ ngày: {0} đến ngày {1}</b>",
                exportRequest.StartDate.ToString("dd-MM-yyyy"),
                exportRequest.EndDate.ToString("dd-MM-yyyy"));
            sb.Append(@"</header>");
            sb.Append(@"<table>");
            sb.Append(@"<tr>");
            sb.Append(@"<td class='tag-td'>STT</td>");
            sb.Append(@"<td class='tag-td'>Mã thẻ</td>");
            sb.Append(@"<td class='tag-td'>Mã bệnh nhân</td>");
            sb.Append(@"<td class='tag-td'>Họ và tên</td>");
            sb.Append(@"<td class='tag-td'>Giới tính</td>");
            sb.Append(@"<td class='tag-td'>Ngày sinh</td>");
            sb.Append(@"<td class='tag-td'>Số tiền đã nạp</td>");
            sb.Append(@"<td class='tag-td'>Số tiền đã trừ</td>");
            sb.Append(@"<td class='tag-td'>Số tiền trong thẻ</td>");
            sb.Append(@"</tr>");

            for (var j = 0; j < data.Count; j++)
            {
                sb.Append(@"<tr>");
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>", j + 1);
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>", data[j].TekmediCardNumber);
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>", data[j].Code);
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>", data[j].FullName);
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>", data[j].Gender);
                sb.AppendFormat(@"<td class='tag-td-data' >{0}</td>",
                    data[j].BirthdayYearOnly
                        ? data[j].Birthday.Value.ToString("yyyy")
                        : data[j].Birthday.Value.ToString("dd/MM/yyyy"));
                sb.Append(@"</tr>");
            }

            sb.Append(@"</table>");
            sb.Append(@"<div style='float: right;text-align: center;padding :10px;'>");
            sb.AppendFormat(@"<span style='margin-bottom : 15px;display:block'>{0}</span>", exportRequest.EmployeeName);
            sb.Append(@"</br>");
            sb.AppendFormat(@"<span>Bệnh viện K, ngày {0} tháng {1} năm {2}</span>", DateTime.Now.Day,
                DateTime.Now.Month, DateTime.Now.Year);
            sb.Append(@"</div>");
            return sb.ToString();
        }
    }
}