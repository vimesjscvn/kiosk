using System.ComponentModel.DataAnnotations;

namespace DepartmentGroup.Domain.Models.Requests.PutModels
{
    public class UpdatePatientDepartmentServiceModel
    {
        [Required] public string ExaminationCode { get; set; }

        [Required] public int ObjectType { get; set; }

        [Required] public string RoomCode { get; set; }

        [Required] public string ServiceCode { get; set; }
    }
}