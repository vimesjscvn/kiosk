using System;

namespace Admin.Domain.Models.Requests
{
    public class ClinicNSDTNotEnough3Hours
    {
        public Guid ServiceId { get; set; }
        public bool Enough3Hours { get; set; }
        public DateTime Time { get; set; }
    }
}