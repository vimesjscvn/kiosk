using System;

namespace CS.VM.Responses
{
    public class ResetQueueNumberResponse
    {
        public bool Success { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}