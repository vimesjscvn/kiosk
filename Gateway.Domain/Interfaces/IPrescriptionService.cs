using Core.Domain.BusinessObjects;

namespace Gateway.Domain.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IPrescriptionService
    {
        GetRawPrescriptionDetailByCodeResponse GetPrescriptionDetailByCode(
            GetRawPrescriptionDetailByCodeRequest request);
    }
}