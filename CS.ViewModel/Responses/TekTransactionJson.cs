using CS.Common.Common;
using Newtonsoft.Json;
using System;

namespace CS.VM.Responses
{
    public class TekTransactionJson
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string TypeName => TransactionTypeConstants.GetName(Type);

        /// <summary>
        /// Gets or sets the pay provider.
        /// </summary>
        /// <value>
        /// The pay provider.
        /// </value>
        public PaymentProvider PayProvider { get; set; }

        /// <summary>
        /// Gets or sets the transaction code.
        /// </summary>
        /// <value>
        /// The transaction code.
        /// </value>
        public int TransactionCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the patient.
        /// </summary>
        /// <value>
        /// The type of the patient.
        /// </value>
        public string ExaminationType { get; set; }

        /// <summary>
        /// Gets or sets the type of the patient.
        /// </summary>
        /// <value>
        /// The type of the patient.
        /// </value>
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string StatusName => TransactionTypeConstants.GetStatus(Status);

        /// <summary>
        /// Gets a value indicating whether this instance is new version.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new version; otherwise, <c>false</c>.
        /// </value>
        public bool IsNewVersion { get; set; }

        /// <summary>
        /// Gets the extra total.
        /// </summary>
        /// <value>
        /// The extra total.
        /// </value>
        public decimal ExtraTotal { get; set; }
        /// <summary>
        /// Gets the refund total.
        /// </summary>
        /// <value>
        /// The refund total.
        /// </value>
        public decimal RefundTotal { get; set; }
        /// <summary>
        /// Gets the paid refund total.
        /// </summary>
        /// <value>
        /// The paid refund total.
        /// </value>
        public decimal PaidRefundTotal { get; set; }
        /// <summary>
        /// Gets the hold total.
        /// </summary>
        /// <value>
        /// The hold total.
        /// </value>
        public decimal HoldTotal { get; set; }
        /// <summary>
        /// Gets the store.
        /// </summary>
        /// <value>
        /// The store.
        /// </value>
        public string Store { get; set; }
        /// <summary>
        /// Gets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets the insurance number.
        /// </summary>
        /// <value>
        /// The insurance number.
        /// </value>
        public int? PrescriptionNumber { get; set; }

        /// <summary>
        /// Gets the examination code.
        /// </summary>
        /// <value>
        /// The examination code.
        /// </value>
        public string ExaminationCode { get; set; }

        /// <summary>
        /// Gets the name of the examination.
        /// </summary>
        /// <value>
        /// The name of the examination.
        /// </value>
        public string ExaminationName { get; set; }


        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [JsonProperty("created_date")]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        [JsonProperty("updated_by")]
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [JsonProperty("updated_date")]
        public DateTime? UpdatedDate { get; set; }
    }
}
