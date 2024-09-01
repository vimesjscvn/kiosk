using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("eye_table_call_number_normal")]
    public class EyeReceptionNormalNumberTable : TableCallNumber
    {
        [Column("area_code")]
        public string AreaCode { get; set; }
    }
}
