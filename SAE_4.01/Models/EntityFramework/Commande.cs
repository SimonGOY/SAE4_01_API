using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_commande_cmd")]
    public partial class Commande
    {
        [Key]
        [Column("cmd_id")]
        public int IdCommande { get; set; }

        [Column("clt_id")]
        public int IdClient { get; set; }

        [Column("cmd_date", TypeName = "DATE")]
        public DateTime DateCommande { get; set; }

        [Column("cmd_etat")]
        public DateTime Etat { get; set; }

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.CommandeClient))]
        public virtual Client ClientCommande { get; set; } = null!;

        [InverseProperty(nameof(Transaction.CommandeTransaction))]
        public virtual ICollection<Transaction>? TransactionCommande { get; set; }
    }
}
