using System.Collections.Generic;

namespace CS.VM.CheckInModel.Responses
{
    public class GetMultiTableQueueItem
    {
        public int Type { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }

    public class GetMultiTableQueueResponse
    {
        public GetMultiTableQueueResponse()
        {
            Data = new List<GetMultiTableQueueItem>();
        }

        public string Table { get; set; }
        public string Name { get; set; }
        public List<GetMultiTableQueueItem> Data { get; set; }
    }
}