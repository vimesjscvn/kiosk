using System.Collections.Generic;

namespace Core.Domain.BusinessObjects
{
    public class GetRawMasterDataRequest
    {
    }

    public class GetRawServiceListResponse : BaseRawResponse
    {
        public List<GetRawServiceListDataResponse> Result { get; set; } = new List<GetRawServiceListDataResponse>();
    }

    public class GetRawServiceListDataResponse
    {
        public string ServiceCode { get; set; }
        public string Description { get; set; }
        public string ListValueCode { get; set; }
    }

    public class GetRawDrugListResponse : BaseRawResponse
    {
        public List<GetDrugListRawResponse> Result { get; set; } = new List<GetDrugListRawResponse>();
    }

    public class GetDrugListRawResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public string UsageScope { get; set; }
    }
}