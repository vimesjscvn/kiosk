using System;

namespace DepartmentGroup.Domain.Models
{
    public class PatientDepartmentServiceJsonViewModel
    {
        public bool IsActive { get; set; }

        public string ServiceCode { get; set; }

        public string RoomCode { get; set; }

        public string ServiceName { get; set; }

        public string RoomName { get; set; }

        public string ExaminationCode { get; set; }

        public string ExaminationName { get; set; }

        public string ObjectType { get; set; }

        public Guid Id { get; set; }
    }
}