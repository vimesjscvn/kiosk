using System;

namespace CS.VM.Requests
{
    public class CheckUserNameUniqueRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
    }
}