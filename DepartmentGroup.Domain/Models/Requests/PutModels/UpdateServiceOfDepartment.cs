using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CS.Common.Common;

namespace DepartmentGroup.Domain.Models.Requests.PutModels
{
    public class InsertServiceOfDepartmentModel
    {
        [Required] public string ExaminationCode { get; set; }

        [Required] public List<int> ObjectTypeList { get; set; }

        [Required] public string RoomCode { get; set; }

        [Required] public List<string> ServiceCodeList { get; set; }
    }

    public class UpdateServiceOfDepartmentModel
    {
        [Required] public string ExaminationCode { get; set; }

        public List<int> ObjectTypeList { get; set; }
        public string RoomCode { get; set; }
        public List<string> ServiceCodeList { get; set; }
        public ObjectType ObjectType { get; set; }
        public string ServiceCode { get; set; }
    }
}