using System;

namespace CS.VM.CheckInModel.Dtos
{
    public class GetPatientByCardDto
    {
        public string Name { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Balance { get; set; }
        public string BirthdayText { get; set; }
        public string BlockId { get; set; }
        public string Province { get; set; }
        public string ProvinceId { get; set; }
        public string DistrictId { get; set; }
        public string GenderText { get; set; }
    }
}