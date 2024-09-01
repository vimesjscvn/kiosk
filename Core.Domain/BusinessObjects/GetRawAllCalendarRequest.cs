using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    /// <summary>
    /// </summary>
    /// <seealso cref="BaseRawRequest" />
    public class GetRawAllCalendarRequest : BaseRawRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [StringLength(36)]
        [JsonRequired]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        [JsonProperty("registered_date")] public DateTime RegisteredDate { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarResponse.
    ///     Implements the <see cref="CS.VM.External.Responses.BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="CS.VM.External.Responses.BaseExternalResponse" />
    public class GetRawAllCalendarResponse : BaseRawResponse
    {
        /// <summary>
        ///     Gets or sets the danh sach lich tai kham.
        /// </summary>
        /// <value>The danh sach lich tai kham.</value>
        public List<GetRawAllCalendarResponseData> ExaminationCalendar { get; set; }
    }

    /// <summary>
    ///     Class GetAllCalendarResponseData.
    /// </summary>
    public class GetRawAllCalendarResponseData
    {
        /// <summary>
        ///     Gets or sets the ma benh nhan.
        /// </summary>
        /// <value>The ma benh nhan.</value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the ngay tai kham.
        /// </summary>
        /// <value>The ngay tai kham.</value>
        [JsonProperty("registered_date")]
        public string RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the ma bac si.
        /// </summary>
        /// <value>The ma bac si.</value>
        [JsonProperty("doctor_code")]
        public string DoctorCode { get; set; }

        /// <summary>
        ///     Gets or sets the ma phong ban.
        /// </summary>
        /// <value>The ma phong ban.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets the co can lam san.
        /// </summary>
        /// <value>The co can lam san.</value>
        [JsonProperty("is_have_clinic")]
        public string IsHaveClinic { get; set; }

        /// <summary>
        ///     Gets or sets the doi tuong.
        /// </summary>
        /// <value>The doi tuong.</value>
        [JsonProperty("patient_type")]
        public string PatientType { get; set; }
    }
}