using System;

namespace CS.VM.Requests
{
    public class RemoveUserOutOfConfigRequest
    {
        public Guid UserId { get; set; }
        public Guid ConfigId { get; set; }
    }
}