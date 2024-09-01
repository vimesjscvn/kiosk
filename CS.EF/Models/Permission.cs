using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    [Table("sys_permis", Schema = "IHM")]
    public class Permission : BaseObjectExtended
    {
        [Column("code")] public string Code { get; set; }

        [Column("description")] public string Description { get; set; }

        [Column("is_active")] public bool? IsActive { get; set; }

        [InverseProperty("Permission")] public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}