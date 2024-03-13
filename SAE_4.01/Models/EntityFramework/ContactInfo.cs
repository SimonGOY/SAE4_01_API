using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_contactinfo_ctf")]
    public class ContactInfo
    {
        [Key]
        [Column("ctf_id")]
        public int IdContact { get; set; }

        [Column("ofr_id")]
        public int IdOffre { get; set; }

        [Column("ctf_nom")]
        [StringLength(50)]
        public string NomContact { get; set; } = null!;

        [Column("ctf_prenom")]
        [StringLength(50)]
        public string PrenomContact { get; set; } = null!;

        [Column("ctf_datenaissance", TypeName ="DATE")]
        public DateTime DateNaissanceContact { get; set; }

        [Column("ctf_email")]
        [StringLength(100)]
        public string EmailContact { get; set; } = null!;

        [Column("ctf_tel")]
        [StringLength(10)]
        public string TelContact { get; set; } = null!;


        [ForeignKey(nameof(IdOffre))]
        [InverseProperty(nameof(Offre.ContactInfoOffre))]
        public virtual Offre OffreContactInfo { get; set; } = null!;


        [InverseProperty(nameof(DemandeEssai.ContactInfoDemandeEssai))]
        public virtual ICollection<Media>? DemandeEssaiContactInfo { get; set; }
    }
}
