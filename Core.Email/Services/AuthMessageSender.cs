using System.Threading.Tasks;
using Core.Email.Configurations;
using Core.Email.Interfaces;
using CS.VM.Requests;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Core.Email.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<SMSoptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public SMSoptions Options { get; } // set only via Secret Manager

        /// <summary>
        ///     Verifies the type of the code with.
        /// </summary>
        /// <param name="verifyRequest">The verify request.</param>
        /// <returns></returns>
        public Task<bool> VerifyCodeWithType(VerifyCodeRequest verifyRequest)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        ///     Sends the type of the mail with.
        /// </summary>
        /// <param name="mailRequest">The mail request.</param>
        /// <returns></returns>
        public Task<bool> SendMailWithType(EmailSenderRequest mailRequest)
        {
            return Task.FromResult(true);
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            // Your Account SID from twilio.com/console
            var accountSid = Options.SMSAccountIdentification;
            // Your Auth Token from twilio.com/console
            var authToken = Options.SMSAccountPassword;

            TwilioClient.Init(accountSid, authToken);

            return MessageResource.CreateAsync(
                new PhoneNumber(number),
                from: new PhoneNumber(Options.SMSAccountFrom),
                body: message);
        }
    }
}