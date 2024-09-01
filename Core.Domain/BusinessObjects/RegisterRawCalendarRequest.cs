using System;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class RegisterRawCalendarRequest : BaseRawRequest
    {
        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonRequired]
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }
    }

    /// <summary>
    /// </summary>
    public class RegisterRawCalendarResponse : BaseRawResponse
    {
        /// <summary>
        ///     Gets or sets the danh sach lich tai kham.
        /// </summary>
        /// <value>The danh sach lich tai kham.</value>
        public RegisterRawCalendarData Data { get; set; }
    }

    /// <summary>
    ///     Class GetCalendarResponseData.
    /// </summary>
    public class RegisterRawCalendarData
    {
        /// <summary>
        ///     Gets or sets the identifier specified.
        /// </summary>
        /// <value>
        ///     The identifier specified.
        /// </value>
        [JsonProperty("IdSpecified")]
        public string IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the temporary patient code.
        /// </summary>
        /// <value>
        ///     The temporary patient code.
        /// </value>
        [JsonProperty("TempPatientCode")]
        public string TempPatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonProperty("PatientCode")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the doctor code.
        /// </summary>
        /// <value>
        ///     The doctor code.
        /// </value>
        [JsonProperty("DoctorCode")]
        public string DoctorCode { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        [JsonProperty("DepartmentCode")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>
        ///     The registered code.
        /// </value>
        [JsonProperty("RegisteredCode")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the employee code.
        /// </summary>
        /// <value>
        ///     The employee code.
        /// </value>
        [JsonProperty("EmployeeCode")]
        public string EmployeeCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        [JsonProperty("RegisteredDate")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the type of the patient.
        /// </summary>
        /// <value>
        ///     The type of the patient.
        /// </value>
        [JsonProperty("PatientType")]
        public string PatientType { get; set; }

        /// <summary>
        ///     Gets or sets the money.
        /// </summary>
        /// <value>
        ///     The money.
        /// </value>
        [JsonProperty("Money")]
        public double Money { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        [JsonProperty("Status")]
        public object Status { get; set; }

        /// <summary>
        ///     Gets or sets the ho.
        /// </summary>
        /// <value>
        ///     The ho.
        /// </value>
        [JsonProperty("Ho")]
        public string Ho { get; set; }

        /// <summary>
        ///     Gets or sets the ten.
        /// </summary>
        /// <value>
        ///     The ten.
        /// </value>
        [JsonProperty("Ten")]
        public string Ten { get; set; }

        /// <summary>
        ///     Gets or sets the ho ten.
        /// </summary>
        /// <value>
        ///     The ho ten.
        /// </value>
        [JsonProperty("HoTen")]
        public string HoTen { get; set; }

        /// <summary>
        ///     Gets or sets the ngay sinh.
        /// </summary>
        /// <value>
        ///     The ngay sinh.
        /// </value>
        [JsonProperty("NgaySinh")]
        public string NgaySinh { get; set; }

        /// <summary>
        ///     Gets or sets the nam sinh.
        /// </summary>
        /// <value>
        ///     The nam sinh.
        /// </value>
        [JsonProperty("NamSinh")]
        public string NamSinh { get; set; }

        /// <summary>
        ///     Gets or sets the gioi tinh.
        /// </summary>
        /// <value>
        ///     The gioi tinh.
        /// </value>
        [JsonProperty("GioiTinh")]
        public string GioiTinh { get; set; }

        /// <summary>
        ///     Gets or sets the dia chi.
        /// </summary>
        /// <value>
        ///     The dia chi.
        /// </value>
        [JsonProperty("DiaChi")]
        public string DiaChi { get; set; }

        /// <summary>
        ///     Gets or sets the dien thoai.
        /// </summary>
        /// <value>
        ///     The dien thoai.
        /// </value>
        [JsonProperty("DienThoai")]
        public string DienThoai { get; set; }

        /// <summary>
        ///     Gets or sets the CMND.
        /// </summary>
        /// <value>
        ///     The CMND.
        /// </value>
        [JsonProperty("CMND")]
        public string CMND { get; set; }

        /// <summary>
        ///     Gets or sets the pastport.
        /// </summary>
        /// <value>
        ///     The pastport.
        /// </value>
        [JsonProperty("Pastport")]
        public string Pastport { get; set; }

        /// <summary>
        ///     Gets or sets the ngay cap CMND.
        /// </summary>
        /// <value>
        ///     The ngay cap CMND.
        /// </value>
        [JsonProperty("NgayCapCMND")]
        public string NgayCapCMND { get; set; }

        /// <summary>
        ///     Gets or sets the noi cap CMND.
        /// </summary>
        /// <value>
        ///     The noi cap CMND.
        /// </value>
        [JsonProperty("NoiCapCMND")]
        public string NoiCapCMND { get; set; }

        /// <summary>
        ///     Gets or sets the ma tinh thanh.
        /// </summary>
        /// <value>
        ///     The ma tinh thanh.
        /// </value>
        [JsonProperty("MaTinhThanh")]
        public string MaTinhThanh { get; set; }

        /// <summary>
        ///     Gets or sets the ma quan huyen.
        /// </summary>
        /// <value>
        ///     The ma quan huyen.
        /// </value>
        [JsonProperty("MaQuanHuyen")]
        public string MaQuanHuyen { get; set; }

        /// <summary>
        ///     Gets or sets the ma phuong xa.
        /// </summary>
        /// <value>
        ///     The ma phuong xa.
        /// </value>
        [JsonProperty("MaPhuongXa")]
        public string MaPhuongXa { get; set; }

        /// <summary>
        ///     Gets or sets the ip.
        /// </summary>
        /// <value>
        ///     The ip.
        /// </value>
        [JsonProperty("ip")]
        public string ip { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [uu tien].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [uu tien]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("UuTien")]
        public bool UuTien { get; set; }

        /// <summary>
        ///     Gets or sets the loai uu tien.
        /// </summary>
        /// <value>
        ///     The loai uu tien.
        /// </value>
        [JsonProperty("LoaiUuTien")]
        public string LoaiUuTien { get; set; }
    }
}