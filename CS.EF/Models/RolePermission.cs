using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("sys_type_permiss", Schema = "IHM")]
    public class RolePermission
    {
        [ForeignKey("Permission")]
        [Column("sys_permis_id", Order = 0)]
        public Guid PermissionId { get; set; }

        public virtual Permission Permission { get; set; }

        [ForeignKey("Role")]
        [Column("sys_type_id", Order = 1)]
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}