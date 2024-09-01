using System.Collections.Generic;
using CS.VM.CheckInModel.Dtos;

namespace CS.VM.CheckInModel.Responses
{
    public class GetPatientsInQueueResponse
    {
        /// <summary>
        ///     Gets or sets the get patients in queue dtos.
        /// </summary>
        /// <value>
        ///     The get patients in queue dtos.
        /// </value>
        public List<GetPatientsInQueueDto> GetPatientsInQueueDtos { get; set; }
    }
}