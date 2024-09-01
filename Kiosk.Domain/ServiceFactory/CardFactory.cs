using CS.Common.Common;
using System;
using TEK.Core.Service.Interfaces;
using TEK.Payment.Domain.Services;

namespace TEK.Payment.Domain.ServiceFactory
{
    public class CardFactory
    {
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CardFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public CardFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public ICardService GetService(string type)
        {
            if (type == Constants.CardType.VCB)
                return (ICardService)serviceProvider.GetService(typeof(BankCardService));

            return (ICardService)serviceProvider.GetService(typeof(LocalCardService));
        }
    }
}
