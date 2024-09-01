using CS.VM.CheckInModel.Dtos;
using CS.VM.Models;

namespace CS.VM.CheckInModel.Responses
{
    public class ChangeTableTypeResponse : TableTypeModel
    {
        /// <summary>
        ///     Gets or sets the change table type dto.
        /// </summary>
        /// <value>
        ///     The change table type dto.
        /// </value>
        public ChangeTableTypeDto ChangeTableTypeDto { get; set; }
    }
}