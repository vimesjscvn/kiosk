using System.Collections.Generic;
using CS.EF.Models;
using CS.VM.Models;

namespace CS.VM.Responses
{
    public class ReceptionResponse
    {
        public List<ReceptionViewModel> Receptions { get; set; }
    }

    public class ReceptionHistoryResponse
    {
        public List<History> ReceptionHistories { get; set; }
    }
}