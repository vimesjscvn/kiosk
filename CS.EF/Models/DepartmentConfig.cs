using System;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    [Table("department_config", Schema = "Dept")]
    public class DepartmentConfig : BaseObjectExtended
    {
        [Column("department_code")] public string DepartmentCode { get; set; }

        [Column("group_dept_code")] public string GroupDeptCode { get; set; }

        [Column("time_on_minute")] public int? TimeOnMinute { get; set; }

        [Column("time_active")] public string TimeActive { get; set; }

        [Column("age_to")] public int? AgeTo { get; set; }

        [Column("age_from")] public int? AgeFrom { get; set; }

        [Column("type_gender")] public TypeGender TypeGender { get; set; }

        [Column("total_number")] public int? TotalNumber { get; set; }

        [Column("re_exam_days", TypeName = "integer[]")]
        public int[] ActiveReExamDays { get; set; }

        [Column("department_id")] public Guid DepartmentId { get; set; }

        [Column("group_id")] public Guid? GroupId { get; set; }

        public virtual Department Department { get; set; }

        public virtual Group Group { get; set; }
    }
}