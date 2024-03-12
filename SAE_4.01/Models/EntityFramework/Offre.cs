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

        [Column("mcf_id")]
        public int IdMotoConfigurable { get; set; }

        [Column("con_id")]
        public int IdConcessionnaire { get; set; }

        [Column("ofr_assurance")]
        public bool Assurance { get; set; }

        [Column("ofr_financement")]
        [StringLength(30)]
        public string? FinancementOffre { get; set; } = null!;

        [ForeignKey(nameof(IdMotoConfigurable))]
        [InverseProperty(nameof(MotoConfigurable.OffreMotoConfigurable))]
        public virtual MotoConfigurable MotoConfigurableOffre { get; set; } = null!;

        [ForeignKey(nameof(IdConcessionnaire))]
        [InverseProperty(nameof(Concessionnaire.OffreConcessionnaire))]
        public virtual Concessionnaire ConcessionnaireOffre { get; set; } = null!;
    }
}
