using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_demandeessai_dme")]
    public class DemandeEssai
    {
        [Key]
        [Column("dme_id")]
        public int IdDemandeEssai { get; set; }

        [Column("con_id")]
        public int IdConcessionnaire { get; set; }

        [Column("mom_id")]
        public int IdMoto { get; set; }

        [Column("ctf_id")]
        public int IdContact { get; set; }

        [Column("dme_descriptif")]
        public string? DescriptifDemandeEssai { get; set; }

        [ForeignKey(nameof(IdConcessionnaire))]
        [InverseProperty(nameof(Concessionnaire.DemandeEssaiConcessionnaire))]
        public virtual Concessionnaire ConcessionnaireDemandeEssai { get; set; } = null!;

        [ForeignKey(nameof(IdMoto))]
        [InverseProperty(nameof(ModelMoto.DemandeEssaiModelMoto))]
        public virtual ModelMoto ModelMotoDemandeEssai { get; set; } = null!;

        [ForeignKey(nameof(IdContact))]
        [InverseProperty(nameof(ContactInfo.DemandeEssaiContactInfo))]
        public virtual ContactInfo ContactInfoDemandeEssai { get; set; } = null!;
    }
}
