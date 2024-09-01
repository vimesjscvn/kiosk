using CS.Common.Common;
using CS.Common.Enums;
using CS.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.PaymentModels.Requests
{
    public class CreatePaymentRequest
    {
        /// <summary>
        /// Gets or sets the patient code.
        /// </summary>
        /// <value>
        /// The patient code.
        /// </value>
        public string CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the type enum.
        /// </summary>
        /// <value>
        /// The type enum.
        /// </value>
        public TypeEnum TypeEnum { get; set; }

        /// <summary>
        /// Gets or sets the system user.
        /// </summary>
        /// <value>
        /// The system user.
        /// </value>
        public SysUser Employee { get; set; }

        /// <summary>
        /// Gets or sets the reception status.
        /// </summary>
        /// <value>
        /// The reception status.
        /// </value>
        public ReceptionStatus ReceptionStatus { get; set; }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public Guid TransactionId { get; set; }
    }
}
