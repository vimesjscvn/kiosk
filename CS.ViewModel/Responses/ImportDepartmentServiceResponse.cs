using System.Collections.Generic;
using CS.VM.Models;

namespace CS.VM.Responses
{
    public class ImportDepartmentServiceResponse
    {
        public List<ImportDepartmentServiceModel> Import { get; set; }
        public int Total { get; set; }
        public int TotalError { get; set; }
        public string FileErrorUrl { get; set; }
        public bool IsVerify { get; set; }
    }
}