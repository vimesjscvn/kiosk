using System;

namespace CS.VM.Models
{
    public class TransactionNumberUserViewModel
    {
        public Guid TransactionNumberConfigId { get; set; }
        public Guid TransactionNumberUserId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
