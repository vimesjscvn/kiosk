using System;
using System.Collections.Generic;
using CS.VM.External.Responses;
using Newtonsoft.Json;

namespace CS.VM.External.Requests
{
    /// <summary>
    /// </summary>
    public class GetRawCalendarRequest
    {
        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        public DateTime? RegisteredDate { get; set; }
    }

    /// <summary>
    ///     Class GetCalendarResponse.
    ///     Implements the <see cref="BaseExternalResponse" />
    /// </summary>
    /// <seealso cref="BaseExternalResponse" />
    public class GetRawCalendarResponse : BaseExternalResponse
    {
        /// <summary>
        ///     Gets or sets the danh sach lich tai kham.
        /// </summary>
        /// <value>The danh sach lich tai kham.</value>
        public List<GetRawCalendarResponseData> DanhSachLichTaiKham { get; set; }
    }

    /// <summary>
    ///     Class GetCalendarResponseData.
    /// </summary>
    public class GetRawCalendarResponseData
    {
        /// <summary>
        ///     Gets or sets the ma benh nhan.
        /// </summary>
        /// <value>The ma benh nhan.</value>
        public int MaBenhNhan { get; set; }

        /// <summary>
        ///     Gets or sets the ngay tai kham.
        /// </summary>
        /// <value>The ngay tai kham.</value>
        public string NgayTaiKham { get; set; }

        /// <summary>
        ///     Gets or sets the ma bac si.
        /// </summary>
        /// <value>The ma bac si.</value>
        public string MaBacSi { get; set; }

        /// <summary>
        ///     Gets or sets the ma phong ban.
        /// </summary>
        /// <value>The ma phong ban.</value>
        public int MaPhongBan { get; set; }

        /// <summary>
        ///     Gets or sets the ma bac si.
        /// </summary>
        /// <value>The ma bac si.</value>
        public string DoiTuong { get; set; }

        /// <summary>
        ///     Gets or sets the ma bac si.
        /// </summary>
        /// <value>The ma bac si.</value>
        public string CoCanLamSan { get; set; }
    }
}