using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DepartmentGroup.Domain.Models.Requests.PostModels
{
    public class InsertPatientDepartmentServiceModel
    {
        [Required] public string ExaminationCode { get; set; }

        [Required] public List<int> ObjectTypeList { get; set; }

        [Required] public string RoomCode { get; set; }

        [Required] public List<string> ServiceCodeList { get; set; }
    }
}