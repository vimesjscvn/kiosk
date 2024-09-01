using System;

namespace CS.VM.Responses
{
    public class IncreasePrintedBillCountResponse
    {
        public Guid Id { get; set; }
        public int PrintedBillCount { get; set; }
    }
}