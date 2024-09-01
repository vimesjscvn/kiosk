using System;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class BaseServiceRequest
    {
        /// <summary>
        ///     Gets or sets the hospital code.
        /// </summary>
        /// <value>
        ///     The hospital code.
        /// </value>
        [JsonRequired]
        [JsonProperty("hospital_code")]
        public string HospitalCode { get; set; }

        /// <summary>
        ///     Gets or sets the patient code.
        /// </summary>
        /// <value>
        ///     The patient code.
        /// </value>
        [JsonRequired]
        [JsonProperty("patient_code")]
        public string PatientCode { get; set; }

        /// <summary>
        ///     Gets or sets the registered date.
        /// </summary>
        /// <value>
        ///     The registered date.
        /// </value>
        [JsonRequired]
        [JsonProperty("registered_date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        ///     Gets or sets the registered code.
        /// </summary>
        /// <value>
        ///     The registered code.
        /// </value>
        [JsonRequired]
        [JsonProperty("registered_code")]
        public string RegisteredCode { get; set; }

        /// <summary>
        ///     Gets or sets the type of the object.
        /// </summary>
        /// <value>
        ///     The type of the object.
        /// </value>
        [JsonRequired]
        [JsonProperty("object_type")]
        public string ObjectType { get; set; }

        /// <summary>
        ///     Gets or sets the manage code.
        /// </summary>
        /// <value>
        ///     The manage code.
        /// </value>
        [JsonRequired]
        [JsonProperty("management_id")]
        public string ManagementId { get; set; }
    }

    public class ServiceDataModel
    {
        /// <summary>
        ///     Gets or sets the service identifier.
        /// </summary>
        /// <value>
        ///     The service identifier.
        /// </value>
        [JsonRequired]
        [JsonProperty("id_specified")]
        public string IdSpecified { get; set; }

        /// <summary>
        ///     Gets or sets the service code.
        /// </summary>
        /// <value>
        ///     The service code.
        /// </value>
        [JsonRequired]
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        [JsonRequired]
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        ///     Gets or sets the department code.
        /// </summary>
        /// <value>
        ///     The department code.
        /// </value>
        [JsonRequired]
        [JsonProperty("examination_code")]
        public string ExaminationCode { get; set; }

        /// <summary>
        ///     Gets or sets the type of the costs.
        /// </summary>
        /// <value>
        ///     The type of the costs.
        /// </value>
        [JsonRequired]
        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        /// <summary>
        ///     Gets or sets the note.
        /// </summary>
        /// <value>
        ///     The note.
        /// </value>
        [JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        ///     Gets or sets the room code.
        /// </summary>
        /// <value>
        ///     The room code.
        /// </value>
        [JsonProperty("room_code")]
        public string RoomCode { get; set; }
    }

    public class MedicineDataModel
    {
        /// <summary>
        ///     Gets or sets the prescription identifier.
        /// </summary>
        /// <value>
        ///     The prescription identifier.
        /// </value>
        [JsonProperty("prescription_id")]
        public string PrescriptionId { get; set; }

        /// <summary>
        ///     Gets or sets the prescription detail identifier.
        /// </summary>
        /// <value>
        ///     The prescription detail identifier.
        /// </value>
        [JsonProperty("prescription_detail_id")]
        public string PrescriptionDetailId { get; set; }

        /// <summary>
        ///     Gets or sets the medicine code.
        /// </summary>
        /// <value>The medicine code.</value>
        [JsonProperty("medicine_code")]
        public string MedicineCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the medicine.
        /// </summary>
        /// <value>The name of the medicine.</value>
        [JsonProperty("medicine_name")]
        public string MedicineName { get; set; }

        /// <summary>
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        [JsonRequired]
        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the amount.
        /// </summary>
        /// <value>
        ///     The amount.
        /// </value>
        [JsonRequired]
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        ///     Gets or sets the unit.
        /// </summary>
        /// <value>
        ///     The unit.
        /// </value>
        [JsonProperty("unit_price")]
        public double UnitPrice { get; set; }
    }
}