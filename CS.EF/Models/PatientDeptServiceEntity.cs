using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    [Table("patient_department_service", Schema = "Dept")]
    public class PatientDeptServiceEntity : BaseObjectExtended
    {
        [Column("room_code")] public string RoomCode { get; set; }

        [Column("service_code")] public string ServiceCode { get; set; }

        [Column("is_active")] public bool IsActive { get; set; }

        [Column("examination_code")] public string ExaminationCode { get; set; }

        [Column("object_type")] public string ObjectType { get; set; }
    }
}