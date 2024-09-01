using System;
using CS.Common.Common;

namespace DepartmentGroup.Domain.Models
{
    public class DepartmentConfigViewModel
    {
        public int TimeOnMinute { get; set; }

        public string TimeActive { get; set; }

        public string DepartmentCode { get; set; }

        public Guid DepartmentId { get; set; }

        public int AgeTo { get; set; }

        public int AgeFrom { get; set; }

        public TypeGender TypeGender { get; set; }

        public int TotalNumber { get; set; }

        public string TypeGenderName { get; set; }

        public TimeSpan? EndTimeActiveAm { get; set; }

        public TimeSpan? StartTimeActiveAm { get; set; }

        public TimeSpan? EndTimeActivePm { get; set; }
        public TimeSpan? StartTimeActivePm { get; set; }
    }
}