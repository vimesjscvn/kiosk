using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Core.Domain.BusinessObjects
{
    public class PostRawCallNumberResponse
    {
        public string GroupDeptCode { get; set; }

        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Gets or sets from.
        /// </summary>
        /// <value>
        ///     From.
        /// </value>
        public int From { get; set; }

        /// <summary>
        ///     Gets or sets to.
        /// </summary>
        /// <value>
        ///     To.
        /// </value>
        public int To { get; set; }

        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public int Type { get; set; }

        /// <summary>
        ///     Gets or sets the table.
        /// </summary>
        /// <value>
        ///     The table.
        /// </value>
        public string RegisteredCode { get; set; }
    }

    public class PostRawCallNumberRequest
    {
        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        [MaxLength(32)]
        [JsonProperty("MaBenhVien")]
        public string HospitalCode { get; set; }

        [JsonRequired]
        [JsonProperty("MaQuay")]
        public string Table { get; set; }

        [JsonProperty("SoLuong")] public int Limit { get; set; } = 5;

        [JsonProperty("Ip")] public string Ip { get; set; }

        [JsonProperty("MaNhanVien")] public string UserId { get; set; }

        [JsonProperty("MaKhuVuc")] public string AreaCode { get; set; }

        [JsonProperty("LoaiBenhNhan")] public CallNumberPriorityType? Type { get; set; }

        [JsonProperty("LoaiPhong")] public string DepartmentType { get; set; }

        [JsonProperty("MaKhoa")] public string GroupDeptCode { get; set; }

        [JsonProperty("MaPhong")] public string DepartmentCode { get; set; }
    }

    /// <summary>
    ///     Priority Type
    ///     </summaryPriorityType
    public enum CallNumberPriorityType
    {
        /// <summary>
        ///     The Normal
        /// </summary>
        Normal,

        /// <summary>
        ///     The priority
        /// </summary>
        Priority
    }

    public class GetRawPatientsInQueueDto
    {
        /// <summary>
        ///     Gets or sets the queue number.
        /// </summary>
        /// <value>
        ///     The queue number.
        /// </value>
        public int QueueNumber { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the age.
        /// </summary>
        /// <value>
        ///     The age.
        /// </value>
        public string Age { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public int Type { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        public int Status { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        public int Gender { get; set; }

        /// <summary>
        ///     Gets or sets the gender.
        /// </summary>
        /// <value>
        ///     The gender.
        /// </value>
        public Guid PatientId { get; set; }

        public string UrlAudio { get; set; } = "";
    }
}