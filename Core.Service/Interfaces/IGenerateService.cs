using CS.EF.Models;

namespace Core.Service.Interfaces
{
    public interface IGenerateService
    {
        string GeneratRegisterHospital(QueueNumber queueNumber, TempPatient tempPatient, ListValue hospital);
    }
}