using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    public class PostRawVerifyInsuranceGatewayRequest
    {
        [JsonProperty("maThe")] public string maThe { get; set; }

        [JsonProperty("hoTen")] public string hoTen { get; set; }

        [JsonProperty("ngaySinh")] public string ngaySinh { get; set; }

        [JsonProperty("hoTenCb")] public string hoTenCb { get; set; }

        [JsonProperty("cccdCb")] public string cccdCb { get; set; }

        public string token { get; set; }

        public string id_token { get; set; }
    }

    public class DsLichSuKCB2018
    {
        [JsonProperty("maHoSo")] public string maHoSo { get; set; }

        [JsonProperty("maCSKCB")] public string maCSKCB { get; set; }

        [JsonProperty("ngayVao")] public string ngayVao { get; set; }

        [JsonProperty("ngayRa")] public string ngayRa { get; set; }

        [JsonProperty("tenBenh")] public string tenBenh { get; set; }

        [JsonProperty("tinhTrang")] public string tinhTrang { get; set; }

        [JsonProperty("kqDieuTri")] public string kqDieuTri { get; set; }
    }

    public class PostRawVerifyInsuranceGatewayResponse
    {
        [JsonProperty("maKetQua")] public string maKetQua { get; set; }

        [JsonProperty("ghiChu")] public string ghiChu { get; set; }

        [JsonProperty("maThe")] public string maThe { get; set; }

        [JsonProperty("hoTen")] public string hoTen { get; set; }

        [JsonProperty("ngaySinh")] public string ngaySinh { get; set; }

        [JsonProperty("gioiTinh")] public string gioiTinh { get; set; }

        [JsonProperty("diaChi")] public string diaChi { get; set; }

        [JsonProperty("maDKBD")] public string maDKBD { get; set; }

        [JsonProperty("cqBHXH")] public string cqBHXH { get; set; }

        [JsonProperty("gtTheTu")] public string gtTheTu { get; set; }

        [JsonProperty("gtTheDen")] public string gtTheDen { get; set; }

        [JsonProperty("maKV")] public string maKV { get; set; }

        [JsonProperty("ngayDu5Nam")] public string ngayDu5Nam { get; set; }

        [JsonProperty("maSoBHXH")] public string maSoBHXH { get; set; }

        [JsonProperty("maTheCu")] public string maTheCu { get; set; }

        [JsonProperty("maTheMoi")] public string maTheMoi { get; set; }

        [JsonProperty("gtTheTuMoi")] public string gtTheTuMoi { get; set; }

        [JsonProperty("gtTheDenMoi")] public string gtTheDenMoi { get; set; }

        [JsonProperty("maDKBDMoi")] public string maDKBDMoi { get; set; }

        [JsonProperty("tenDKBDMoi")] public string tenDKBDMoi { get; set; }

        [JsonProperty("dsLichSuKCB2018")] public List<DsLichSuKCB2018> dsLichSuKCB2018 { get; set; }

        [JsonProperty("dsLichSuKT2018")] public List<object> dsLichSuKT2018 { get; set; }
    }
}