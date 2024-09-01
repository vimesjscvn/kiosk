using System;

namespace CS.VM.Requests
{
    public class TransactionNumberConfigRequest : DataTableParameters
    {
        public Guid UserId { get; set; }
    }
}
