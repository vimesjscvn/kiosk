using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    public class TableCallNumber
    {
        [Column("seq")] [Key] public int SEQ { get; set; }

        [Column("table")] public string Table { get; set; }

        [Column("ip")] public string Ip { get; set; }

        [Column("created_date")] public DateTime? CreatedDate { get; set; }

        [Column("created_by")] public Guid CreatedBy { get; set; }

        [Column("area_code")] public string AreaCode { get; set; }

        [Column("department_code")] public string DepartmentCode { get; set; }

        [Column("is_selected")] public bool IsSelected { get; set; } = true;
    }
}