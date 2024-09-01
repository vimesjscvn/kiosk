using System.Collections.Generic;
using CS.VM.Models;
using CS.VM.PatientModels;
using CS.VM.Requests;

namespace Core.Service.Interfaces
{
    public interface ITemplateGenerator
    {
        public string GeneratorAdminHistoryCardHtml(string webRoot,
            List<StatisticalViewModel> data, ExportRequest exportRequest
        );

        public string GeneratorExportBalanceHtml(string webRoot,
            List<PatientInfoViewModel> data, ExportRequest exportRequest
        );

        public string GeneratorHistoryCardByEmployeeHtml(string webRoot,
            List<StatisticalViewModel> data, ExportRequest exportRequest
        );
    }
}