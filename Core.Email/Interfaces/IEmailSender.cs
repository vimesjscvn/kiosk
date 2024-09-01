using System.Threading.Tasks;
using CS.VM.Requests;

namespace Core.Email.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        ///     Sends the type of the mail with.
        /// </summary>
        /// <param name="mailRequest">The mail request.</param>
        /// <returns></returns>
        Task<bool> SendMailWithType(EmailSenderRequest mailRequest);

        /// <summary>
        ///     Verifies the type of the code with.
        /// </summary>
        /// <param name="verifyRequest">The verify request.</param>
        /// <returns></returns>
        Task<bool> VerifyCodeWithType(VerifyCodeRequest verifyRequest);
    }
}