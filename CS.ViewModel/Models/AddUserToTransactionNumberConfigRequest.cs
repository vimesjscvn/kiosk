using System;

namespace CS.VM.Models
{
    public class AddUserToTransactionNumberConfigRequest
    {
        public Guid UserId { get; set; }
        public Guid TransactionNumberConfigId { get; set; }
    }
}
