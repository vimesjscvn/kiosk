using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class GetRawCalendarRequest: BaseRawRequest
    {
        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonRequired]
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetRawCalendarResponse : BaseRawResponse
    {
        /// <summary>
        /// Gets or sets the danh sach lich tai kham.
        /// </summary>
        /// <value>The danh sach lich tai kham.</value>
        public List<GetRawCalendarResponseData> DanhSachLichTaiKham { get; set; }
    }

    /// <summary>
    /// Class GetCalendarResponseData.
    /// </summary>
    public class GetRawCalendarResponseData
    {
        /// <summary>
        /// Gets or sets the ma benh nhan.
        /// </summary>
        /// <value>The ma benh nhan.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the ngay tai kham.
        /// </summary>
        /// <value>The ngay tai kham.</value>
        [JsonProperty("registered_date")]
        public string RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the ma bac si.
        /// </summary>
        /// <value>The ma bac si.</value>
        [JsonProperty("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        /// Gets or sets the ma phong ban.
        /// </summary>
        /// <value>The ma phong ban.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the co can lam san.
        /// </summary>
        /// <value>The co can lam san.</value>
        [JsonProperty("is_have_clinic")]
        public string IsHaveClinic { get; set; }

        /// <summary>
        /// Gets or sets the doi tuong.
        /// </summary>
        /// <value>The doi tuong.</value>
        [JsonProperty("patient_type")]
        public string PatientType { get; set; }
    }
}
