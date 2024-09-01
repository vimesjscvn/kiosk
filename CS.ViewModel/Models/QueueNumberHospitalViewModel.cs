using System;

namespace CS.VM.Models
{
    public class QueueNumberHospitalViewModel
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string WardId { get; set; }
        public string WardName { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public DateTime? RegisteredDate { get; set; }
        public DateTime? ScheduledTime { get; set; }
        public string HospitalCode { get; set; }
    }
}