using Core.Domain.BusinessObjects;

namespace Gateway.Domain.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IReExaminationService
    {
        GetRawReExaminationListByCodeAndDateResponse GetReExaminationListByCodeAndDate(
            GetRawReExaminationListByCodeAndDateRequest request);

        PostRawRegisterReExaminationResponse PostRegisterReExamination(PostRawRegisterReExaminationRequest request);
    }
}