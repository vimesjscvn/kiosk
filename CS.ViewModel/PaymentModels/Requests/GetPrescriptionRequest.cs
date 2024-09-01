// ***********************************************************************
// Assembly         : CS.VM
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="GetPrescriptionRequest.cs" company="CS.VM">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CS.VM.PaymentModels.Requests
{
    /// <summary>
    /// Class GetPrescriptionRequest.
    /// </summary>
    public class GetPrescriptionRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>The patient code.</value>
        [JsonRequired]
        [JsonProperty("MaBenhNhan")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonRequired]
        [JsonProperty("SoTiepNhan")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonRequired]
        [JsonProperty("NgayDangKy")]
        public string RegisteredDate { get; set; }
    }

    /// <summary>
    /// Class GetPrescriptionResponse.
    /// </summary>
    [Serializable]
    [XmlRoot("DOCUMENT")]
    public class GetPrescriptionResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPrescriptionResponse"/> class.
        /// </summary>
        public GetPrescriptionResponse()
        {
            DanhSachBHYT = new List<GetPrescriptionResponseData>();
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [XmlIgnore]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        [XmlIgnore]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [XmlIgnore]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the danh sach bhyt.
        /// </summary>
        /// <value>The danh sach bhyt.</value>
        [XmlElement("DATATHUOCBH")]
        public List<GetPrescriptionResponseData> DanhSachBHYT { get; set; }
    }

    /// <summary>
    /// Class GetPrescriptionResponseData.
    /// </summary>
    [XmlRoot("DATATHUOCBH")]
    public class GetPrescriptionResponseData
    {
        /// <summary>
        /// Gets or sets the ma benh nhan.
        /// </summary>
        /// <value>The ma benh nhan.</value>
        [XmlIgnore]
        public int MaBenhNhan { get; set; }

        /// <summary>
        /// Gets or sets the so tiep nhan.
        /// </summary>
        /// <value>The so tiep nhan.</value>
        [XmlIgnore]
        public int SoTiepNhan { get; set; }

        /// <summary>
        /// Gets or sets the toa thuoc identifier.
        /// </summary>
        /// <value>The toa thuoc identifier.</value>
        [XmlIgnore]
        public string ToaThuoc_Id { get; set; }

        /// <summary>
        /// Gets or sets the toa thuoc ct identifier.
        /// </summary>
        /// <value>The toa thuoc ct identifier.</value>
        [XmlElement("ToaThuocCT_IDX")]
        public string ToaThuocCT_Id { get; set; }

        /// <summary>
        /// Gets or sets the ma duoc.
        /// </summary>
        /// <value>The ma duoc.</value>
        [XmlElement("MaThuoc")]
        public string MaDuoc { get; set; }

        /// <summary>
        /// Gets or sets the ten duoc.
        /// </summary>
        /// <value>The ten duoc.</value>
        [XmlIgnore]
        public string TenDuoc { get; set; }

        /// <summary>
        /// Gets or sets the so luong.
        /// </summary>
        /// <value>The so luong.</value>
        [XmlElement("SoLuong")]
        public string SoLuong { get; set; }

        /// <summary>
        /// Gets or sets the don gia.
        /// </summary>
        /// <value>The don gia.</value>
        [XmlElement("DonGia")]
        public double DonGia { get; set; }

        /// <summary>
        /// Gets or sets the benh nhan thanh toan.
        /// </summary>
        /// <value>The benh nhan thanh toan.</value>
        [XmlElement("BenhNhanThanhToan")]
        public double BenhNhanThanhToan { get; set; }
    }
}