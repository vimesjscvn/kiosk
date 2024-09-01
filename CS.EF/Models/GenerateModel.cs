using CS.Common.Common;

namespace CS.EF.Models
{
    public class GenerateTempPatientModel
    {
        public string PatientCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string QueueNumber { get; set; }
        public string YearOfBirth { get; set; }
        public PatientType PatientType { get; set; }
        public Gender Gender { get; set; }
        public string QrCode { get; set; }
    }
}