using CS.Base.ViewModels;
using CS.Common.Common;

namespace Admin.API.Domain.Models.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CS.Base.ViewModels.BaseViewModel" />
    /// <seealso cref="BaseViewModel" />
    public class PaymentResponse : BaseViewModel
    {
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
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public string Message { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        public string EmployeeName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        /// <value>
        /// The store.
        /// </value>
        public string Store { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the prescription number.
        /// </summary>
        /// <value>
        /// The prescription number.
        /// </value>
        public int PrescriptionNumber { get; set; } = -1;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class AuthorizationPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// Gets or sets the authorization identifier.
        /// </summary>
        /// <value>
        /// The authorization identifier.
        /// </value>
        public PaymentAuthorization Authorization { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class FailedPaymentResponse : PaymentResponse
    {
        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public PaymentReason Reason { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PaymentReason
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string message { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal? amount { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PaymentAuthorization
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string id { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string type { get; set; }
        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>
        /// The create time.
        /// </value>
        public string create_time { get; set; }
        /// <summary>
        /// Gets or sets the expire time.
        /// </summary>
        /// <value>
        /// The expire time.
        /// </value>
        public string expire_time { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string state { get; set; }
    }
}
