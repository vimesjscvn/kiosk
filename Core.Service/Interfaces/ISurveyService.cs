using Core.UoW;
using CS.EF.Models;

namespace Core.Service.Interfaces
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IService{SurveyResult,IRepository}" />
    public interface ISurveyService : IService<SurveyResult, IRepository<SurveyResult>>
    {
    }
}