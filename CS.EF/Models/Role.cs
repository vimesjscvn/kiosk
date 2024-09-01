using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using CS.Base;

namespace CS.EF.Models
{
    [Table("sys_type", Schema = "IHM")]
    public class Role : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [Column("code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [Column("description")]
        public string Description { get; set; }

        [Column("is_active")] public bool IsActive { get; set; }

        [InverseProperty("Role")] public virtual ICollection<RolePermission> RolePermissions { get; set; }

        [NotMapped] public IList<Permission> Permissions => RolePermissions.Select(rp => rp.Permission).ToList();

        [InverseProperty("Role")] public virtual ICollection<RoleUser> RoleUsers { get; set; }

        [NotMapped] public IList<SysUser> SysUsers => RoleUsers.Select(ru => ru.SysUser).ToList();
    }
}