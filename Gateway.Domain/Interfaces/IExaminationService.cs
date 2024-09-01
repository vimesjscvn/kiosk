using Core.Domain.BusinessObjects;

namespace Gateway.Domain.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IExaminationService
    {
        GetRawListExaminationByCodeResponse GetListByCode(GetRawListExaminationByCodeRequest request);
        GetRawExaminationDetailByCodeResponse GetExaminationDetailByCode(GetRawExaminationDetailByCodeRequest request);
        PostRawRegisterExaminationResponse PostRegisterExamination(PostRawRegisterExaminationRequest request);
        PostRawRegisterExamByGroupResponse PostRegisterExamByGroup(PostRawRegisterExamByGroupRequest request);
    }
}