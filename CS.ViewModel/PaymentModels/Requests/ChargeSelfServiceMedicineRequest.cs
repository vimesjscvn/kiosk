using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CS.VM.PaymentModels.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class ChargeSelfServiceMedicineRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonProperty("MaBenhNhan")]
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the patient.
        /// </summary>
        /// <value>
        /// The name of the patient.
        /// </value>
        [JsonProperty("TenBenhNhan")]
        [JsonRequired]
        public string PatientName { get; set; }

        /// <summary>
        /// Gets or sets the name of the patient.
        /// </summary>
        /// <value>
        /// The name of the patient.
        /// </value>
        [JsonProperty("SoTiepNhan")]
        [JsonRequired]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the sell date.
        /// </summary>
        /// <value>
        /// The sell date.
        /// </value>
        [JsonProperty("NgayBan")]
        [JsonRequired]
        public DateTime SellDate { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        [JsonProperty("TongTien")]
        [JsonRequired]
        public double TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the employee code.
        /// </summary>
        /// <value>
        /// The employee code.
        /// </value>
        [JsonProperty("MaNhanVien")]
        [JsonRequired]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Gets or sets the store code.
        /// </summary>
        /// <value>
        /// The store code.
        /// </value>
        [JsonProperty("MaQuay")]
        [JsonRequired]
        public string StoreCode { get; set; }

        /// <summary>
        /// Gets or sets the detail.
        /// </summary>
        /// <value>
        /// The detail.
        /// </value>
        [JsonProperty("Request_ThanhToan_BanThuoc_ChiTiet")]
        public List<ChargeSelfServiceMedicineDetail> MedicineLists { get; set; }
    }

    public class ChargeSelfServiceMedicineDetail
    {
        /// <summary>
        /// Gets or sets the toa thuoc identifier.
        /// </summary>
        /// <value>The toa thuoc identifier.</value>
        [JsonProperty("ToaThuoc_Id")]
        public string PrescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the toa thuoc ct identifier.
        /// </summary>
        /// <value>The toa thuoc ct identifier.</value>
        [JsonProperty("ToaThuocCT_Id")]
        public string PrescriptionDetailId { get; set; }

        /// <summary>
        /// Gets or sets the ma duoc.
        /// </summary>
        /// <value>The ma duoc.</value>
        [JsonProperty("MaDuoc")]
        [JsonRequired]
        public string MedicineCode { get; set; }

        /// <summary>
        /// Gets or sets the ten duoc.
        /// </summary>
        /// <value>The ten duoc.</value>
        [JsonProperty("TenDuoc")]
        [JsonRequired]
        public string MedicineName { get; set; }

        /// <summary>
        /// Gets or sets the so luong.
        /// </summary>
        /// <value>The so luong.</value>
        [JsonProperty("SoLuong")]
        [JsonRequired]
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the don gia.
        /// </summary>
        /// <value>The don gia.</value>
        [JsonProperty("DonGia")]
        [JsonRequired]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the benh nhan thanh toan.
        /// </summary>
        /// <value>The benh nhan thanh toan.</value>
        [JsonProperty("ThanhTien")]
        [JsonRequired]
        public double Amount { get; set; }
    }
}
