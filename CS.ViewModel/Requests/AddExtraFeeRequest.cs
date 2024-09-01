using System;

namespace CS.VM.Requests
{
    public class AddExtraFeeRequest
    {
        public string TekmediCardNumber { get; set; }
        public decimal Price { get; set; }
        public Guid EmployeeId { get; set; }
        public string PatientCode { get; set; }
        public string RegisterCode { get; set; }
    }
}
