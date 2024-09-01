using CS.VM.Models;
using System.Collections.Generic;

namespace CS.VM.Responses
{
    public class ExportBalanceWebResponse
    {
        public int TotalRecord { get; set; }
        public List<ExportBalanceExcelDataDto> Data { get; set; } = new List<ExportBalanceExcelDataDto>();
    }
}
