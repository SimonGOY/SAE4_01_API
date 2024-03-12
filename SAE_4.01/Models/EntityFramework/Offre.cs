using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_offre_ofr")]
    public class Offre
    {
        [Key]
        [Column("ofr_id")]
        public int IdOffre { get; set; }

        [Column("ofr_assurance")]
        public bool Assurance { get; set; }

        [Column("ofr_financement")]
        [StringLength(30)]
        public string? FinancementOffre { get; set; } = null!;
    }
}
