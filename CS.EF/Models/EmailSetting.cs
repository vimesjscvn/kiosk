using System.ComponentModel.DataAnnotations.Schema;
using CS.Base;
using CS.Common.Common;

namespace CS.EF.Models
{
    /// <summary>
    /// </summary>
    /// <seealso cref="CS.Base.BaseObjectExtended" />
    [Table("email_setting", Schema = "IHM")]
    public class EmailSetting : BaseObjectExtended
    {
        /// <summary>
        ///     Gets or sets from mail.
        /// </summary>
        /// <value>
        ///     From mail.
        /// </value>
        [Column("from_mail")]
        public string FromMail { get; set; }

        /// <summary>
        ///     Gets or sets from mail password.
        /// </summary>
        /// <value>
        ///     From mail password.
        /// </value>
        [Column("from_mail_password")]
        public string FromMailPassword { get; set; }

        /// <summary>
        ///     Converts to mail.
        /// </summary>
        /// <value>
        ///     To mail.
        /// </value>
        [Column("to_mail")]
        public string ToMail { get; set; }

        /// <summary>
        ///     Gets or sets the subject.
        /// </summary>
        /// <value>
        ///     The subject.
        /// </value>
        [Column("subject")]
        public string Subject { get; set; }

        /// <summary>
        ///     Gets or sets the type of the email.
        /// </summary>
        /// <value>
        ///     The type of the email.
        /// </value>
        [Column("type")]
        public EmailType EmailType { get; set; }

        /// <summary>
        ///     Gets or sets the port.
        /// </summary>
        /// <value>
        ///     The port.
        /// </value>
        [Column("port")]
        public int Port { get; set; }

        /// <summary>
        ///     Gets or sets the host.
        /// </summary>
        /// <value>
        ///     The host.
        /// </value>
        [Column("host")]
        public string Host { get; set; }

        [Column("time_expired")] public int TimeExpired { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value><c>true</c> if this instance is deleted; otherwise, <c>false</c>.</value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}