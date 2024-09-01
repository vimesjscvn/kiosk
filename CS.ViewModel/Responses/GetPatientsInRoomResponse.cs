using System.Collections.Generic;
using CS.VM.Models;

namespace CS.VM.Responses
{
    public class GetPatientsInRoomResponse
    {
        public List<PatientsInRoomViewModel> PatientsInRooms { get; set; }

        public int CurrentNormalNumber { get; set; }
        public int CurrentPriorityNumber { get; set; }
    }

    public class GetRoomPatientResponse
    {
        public List<PatientHaveRoomViewModel> PatientHaveRooms { get; set; }
    }
}