using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TEK.Gateway.Domain.BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class GetRawClinicListRequest : BaseRawRequest
    {
        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>The registered date.</value>
        [JsonProperty("registered_date")]
        public DateTime? RegisteredDate { get; set; }
    }

    /// <summary>
    /// Class GetClinicListResponse.
    /// </summary>
    public class GetRawClinicListResponse : BaseRawResponse
    {
        /// <summary>
        /// Gets or sets the danh sach chi dinh.
        /// </summary>
        /// <value>The danh sach chi dinh.</value>
        [JsonProperty("clinics")]
        public List<GetRawClinicListResponseData> Clinics { get; set; }

        /// <summary>
        /// Gets or sets the data thuoc.
        /// </summary>
        /// <value>The data thuoc.</value>
        [JsonProperty("medicines")]
        public List<GetRawListPrescriptionResponseData> Medicines { get; set; }
    }

    /// <summary>
    /// Class GetClinicListResponseData.
    /// </summary>
    public class GetRawClinicListResponseData
    {
        /// <summary>
        /// Gets or sets the identifier specified.
        /// </summary>
        /// <value>The identifier specified.</value>
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>The department code.</value>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the money.
        /// </summary>
        /// <value>The money.</value>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>The service identifier.</value>
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("clinic_type")]
        public int ClinicType { get; set; }

        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        [JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the examination code.
        /// </summary>
        /// <value>The examination code.</value>
        [JsonProperty("examination_code")]
        public string ExaminationCode { get; set; }

        /// <summary>
        /// Gets or sets the is finished.
        /// </summary>
        /// <value>
        /// The is finished.
        /// </value>
        [JsonProperty("is_finished")]
        public string IsFinished { get; set; }

        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("reception_id")]
        public Guid ReceptionId { get; set; }

        /// <summary>
        /// Gets or sets the room code.
        /// </summary>
        /// <value>
        /// The room code.
        /// </value>
        [JsonProperty("room_code")]
        public string GroupDeptCode { get; set; }

        [JsonProperty("total_fee")]
        public double TotalFee { get; set; }

        [JsonProperty("insurance_fee")]
        public double InsuranceFee { get; set; }

        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }
    }

    /// <summary>
    /// Class GetListPrescriptionResponseData.
    /// </summary>
    public class GetRawListPrescriptionResponseData
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        /// Gets or sets the register code.
        /// </summary>
        /// <value>
        /// The register code.
        /// </value>
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        /// Gets or sets the prescription identifier.
        /// </summary>
        /// <value>
        /// The prescription identifier.
        /// </value>
        [JsonProperty("prescription_id")]
        public string PrescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the prescription detail identifier.
        /// </summary>
        /// <value>
        /// The prescription detail identifier.
        /// </value>
        [JsonProperty("prescription_detail_id")]
        public string PrescriptionDetailId { get; set; }

        /// <summary>
        /// Gets or sets the medicine code.
        /// </summary>
        /// <value>The medicine code.</value>
        [JsonProperty("medicine_code")]
        public string MedicineCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the medicine.
        /// </summary>
        /// <value>The name of the medicine.</value>
        [JsonProperty("medicine_name")]
        public string MedicineName { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        [JsonProperty("unit_price")]
        public double UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("total_fee")]
        public double TotalFee { get; set; }

        [JsonProperty("insurance_fee")]
        public double InsuranceFee { get; set; }

        /// <summary>
        /// Gets or sets the registered code.
        /// </summary>
        /// <value>The registered code.</value>
        [JsonProperty("reception_id")]
        public Guid ReceptionId { get; set; }
    }
}
