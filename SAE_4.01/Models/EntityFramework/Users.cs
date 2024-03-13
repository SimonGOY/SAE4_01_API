using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_users_usr")]
    public partial class Users
    {

        [Key]
        [Column("usr_id")]
        public int Id { get; set; }

        [Column("clt_id")]
        public int IdClient { get; set; }

        [Column("usr_email")]
        [StringLength(255)]
        public string Email { get; set; } = null!;

        [Column("usr_password")]
        public string Password { get; set; } = null!;

        [Column("usr_remembertoken")]
        public string? RememberToken { get; set; }

        [Column("usr_createdat", TypeName = "DATE")]
        public DateTime CreatedAt { get; set; }

        [Column("usr_updatedat", TypeName = "DATE")]
        public DateTime UpdatedAt { get; set; }

        [Column("usr_iscomplete")]
        public bool IsComplete { get; set; }

        [Column("usr_doubleauth")]
        public bool DoubleAuth { get; set; }

        [Column("usr_lastconnected", TypeName = "DATE")]
        public DateTime LastConnected { get; set; }

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.UsersClient))]
        public virtual Client ClientUsers { get; set; } = null!;
    }
}
