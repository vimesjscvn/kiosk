using System;
using CS.VM.Models;
using Newtonsoft.Json;

namespace CS.VM.Requests
{
    public class UpdateRegisteredQueuNumberRequest : RegisterQueueNumberModel
    {
        [JsonRequired] public Guid Id { get; set; }
    }
}