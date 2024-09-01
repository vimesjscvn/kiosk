using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;

namespace CS.EF.Models
{
    /// <summary>
    ///     Department Setting
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("user_switch_board", Schema = "Online")]
    public class UserSwitchBoard : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets user id.
        /// </summary>
        /// <value>The time end.</value>
        [Required]
        [Column("user_id")]
        public Guid SysUserId { get; set; }

        public virtual SysUser SysUser { get; set; }

        /// <summary>
        ///     Gets or sets the switch board id.
        /// </summary>
        /// <value>The time end.</value>
        [Required]
        [Column("switch_board_id")]
        public Guid SwitchBoardId { get; set; }

        public virtual SysUser SwitchBoard { get; set; }
    }
}