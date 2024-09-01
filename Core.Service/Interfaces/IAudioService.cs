using System.Threading.Tasks;
using CS.Common.Common;

namespace Core.Service.Interfaces
{
    public interface IAudioService
    {
        string CreateAudio(string path, string table, int numberFrom, int numberTo, RoomType type,
            PriorityType typePatient);

        string CreateAudioSingle(string path, string table, PriorityType type, int number);

        Task<string> CreateAudioSingleEndoscopic(string path, string table, PriorityType type, int number,
            string virtualRoomCode, int displayyOrder, string urlAudioDepartment);

        string CreateAudioReceptionTable(string webRoot, string requestTable, int requestFrom, int requestTo, int type,
            string departmentCode, bool isRecall = false);

        string CreateAudioDepartment(string webRoot, string group, int requestFrom, int requestTo, int type,
            string departmentCode, string departmentName, string patientName);
    }
}