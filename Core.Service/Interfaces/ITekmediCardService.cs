using CS.EF.Models;
using CS.VM.Requests;
using System;
using System.Threading.Tasks;
using TEK.Core.UoW;

namespace TEK.Core.Service.Interfaces
{
    /// <summary>
    /// Interface ITekmediCardService
    /// Implements the <see cref="CS.Base.IService{CS.EF.Models.TekmediCard, CS.Base.IRepository{CS.EF.Models.TekmediCard}}" />
    /// </summary>
    /// <seealso cref="CS.Base.IService{CS.EF.Models.TekmediCard, CS.Base.IRepository{CS.EF.Models.TekmediCard}}" />
    public interface ITekmediCardService : IService<TekmediCard, IRepository<TekmediCard>>
    {
        /// <summary>
        /// Saves the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;TekmediCardHistory&gt;.</returns>
        Task<TekmediCardHistory> SavePayment(TopUpRequest request);
        /// <summary>
        /// Handles the lost card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;TekmediCardHistory&gt;.</returns>
        Task<TekmediCardHistory> HandleLostCard(LostCardRequest request);
        /// <summary>
        /// Returns the card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;TekmediCardHistory&gt;.</returns>
        Task<TekmediCardHistory> ReturnCard(ReturnCardRequest request);
        /// <summary>
        /// Getbies the card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns>Task&lt;TekmediCard&gt;.</returns>
        Task<TekmediCard> GetCardInfoByCardNumber(string cardNumber);

        /// <summary>
        /// Registers the card payment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> RegisterCardPayment(RegisterCardRequest request);

        /// <summary>
        /// Getbies the card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns>Task&lt;TekmediCard&gt;.</returns>
        Task<TekmediCard> GetAndValidateByCardNumber(string cardNumber);

        /// <summary>
        /// Cancels the payment.
        /// </summary>
        /// <param name="historyId">The history identifier.</param>
        /// <returns>Task&lt;TekmediCardCancelHistory&gt;.</returns>
        Task<TekmediCardCancelHistory> CancelPayment(Guid historyId);

        /// <summary>
        /// Withdraws the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<TekmediCardHistory> Withdraw(WithdrawRequest request);

        /// <summary>
        /// Validates the card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns></returns>
        Task<bool> ValidateCardNumber(string cardNumber);

        /// <summary>
        /// Gets the by card number.
        /// </summary>
        /// <param name="cardNumber">The card number.</param>
        /// <returns></returns>
        Task<TekmediCard> GetByCardNumber(string cardNumber);
    }
}
