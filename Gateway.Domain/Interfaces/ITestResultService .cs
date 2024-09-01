using Core.Domain.BusinessObjects;

namespace Gateway.Domain.Interfaces
{
    /// <summary>
    /// </summary>
    public interface ITestResultService
    {
        PostRawReceiveTestResultResponse Receive(PostRawReceiveTestResultRequest request);
    }
}