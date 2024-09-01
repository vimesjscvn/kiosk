using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("hsoft_payment_history", Schema = "IHM")]
    public class HsoftPaymentHistory
    {
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        [Key]
        [Column("transaction_id")]
        public Guid TransactionId { get; set; }
        /// <summary>
        /// Gets or sets the json.
        /// </summary>
        /// <value>
        /// The json.
        /// </value>
        [Column("json", TypeName = "jsonb")]
        public string Json { get; set; }
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        [Column("patient_code")]
        public string PatientCode { get; set; }
    }
}
