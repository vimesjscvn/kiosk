using System;

namespace CS.VM.CheckInModel.Requests
{
    public class GetMultiQueueByDepartmentData
    {
        public DateTime Date { get; set; }
        public string DepartmentCode { get; set; }
        public int Limit { get; set; }
    }
}