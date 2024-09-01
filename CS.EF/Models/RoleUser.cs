using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    ///     Class SysUser.
    ///     Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("sys_type_user", Schema = "IHM")]
    public class RoleUser
    {
        [Key]
        [ForeignKey("SysUser")]
        [Column("sys_user_id", Order = 0)]
        public Guid SysUserId { get; set; }

        public virtual SysUser SysUser { get; set; }

        [Key]
        [ForeignKey("Role")]
        [Column("sys_type_id", Order = 1)]
        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}