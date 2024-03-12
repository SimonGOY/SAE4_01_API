using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_h_transaction_tct")]
    public class Transaction
    {
        [Key]
        [Column("tct_id")]
        public int IdTransaction { get; set; }

        [Column("tct_type")]
        [StringLength(60)]
        public string Type { get; set; } = null!;

        [Column("tct_montant", TypeName = "decimal(6,2)")]
        public decimal Montant { get; set; }
    }
}
