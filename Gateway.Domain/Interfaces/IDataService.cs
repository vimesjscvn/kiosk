using Core.Domain.BusinessObjects;

namespace Gateway.Domain.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IDataService
    {
        GetRawListGroupDeptResponse GetListGroupDept(GetRawListGroupDeptRequest request);

        GetRawListServiceByRegisteredCodeResponse GetListServiceByRegisteredCode(
            GetRawListServiceByRegisteredCodeRequest request);

        PostRawUpdateListServiceResponse PostUpdateListService(PostRawUpdateListServiceRequest request);
    }
}