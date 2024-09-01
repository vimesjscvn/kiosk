using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("transaction_number_users", Schema = "IHM")]
    public class TransactionNumberUser
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("transaction_number_config_id")]
        [ForeignKey("TransactionNumberConfig")]
        public Guid TransactionNumberConfigId { get; set; }

        [Column("user_id")]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual TransactionNumberConfig TransactionNumberConfig { get; set; }       

        public virtual SysUser User { get; set; }
    }
}
