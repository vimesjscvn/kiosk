using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IService{SurveyResult,IRepository}" />
    public interface ISurveyResultService : IService<SurveyResult, IRepository<SurveyResult>>
    {
    }
}