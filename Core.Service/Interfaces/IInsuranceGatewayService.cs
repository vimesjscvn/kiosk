using System.Threading.Tasks;
using Core.Domain.BusinessObjects;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IInsuranceGatewayService
    {
        /// <summary>
        ///     Posts the raw clinic list.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        Task<PostRawLoginInsuranceGatewayResponse> PostRawLoginInsuranceGateway(
            PostRawLoginInsuranceGatewayRequest request);

        Task<PostRawVerifyInsuranceGatewayResponse> PostRawVerifyInsuranceGateway(
            PostRawVerifyInsuranceGatewayRequest request);

        Task<PostRawLoginInsuranceGatewayResponse> PostRawLoginInsuranceGatewayV1(
            PostRawLoginInsuranceGatewayRequest request);

        Task<PostRawVerifyInsuranceGatewayResponse> PostRawVerifyInsuranceGatewayV1(
            PostRawVerifyInsuranceGatewayRequest request);
    }
}