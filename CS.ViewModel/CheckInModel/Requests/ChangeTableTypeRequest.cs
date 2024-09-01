using CS.VM.Models;

namespace CS.VM.CheckInModel.Requests
{
    public class ChangeTableTypeRequest : TableTypeModel
    {
        public int Limit { get; set; }
    }
}