using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_r_presentation_equipement_pre")]
    public partial class PresentationEquipement
    {
        [Key]
        [Column("pre_id")]
        public int IdPresentation { get; set; }

        [Column("equ_idequipement")]
        public int IdEquipement { get; set; }

        [Column("col_idcoloris")]
        public int IdColoris { get; set; }


        [ForeignKey(nameof(IdEquipement))]
        [InverseProperty(nameof(Equipement.PresentationEquipementEquipement))]
        public virtual Equipement EquipementPresentationEquipement { get; set; } = null!;

        [ForeignKey(nameof(IdColoris))]
        [InverseProperty(nameof(Coloris.PresentationEquipementColoris))]
        public virtual Coloris ColorisPresentationEquipement { get; set; } = null!;


        [InverseProperty(nameof(Media.PresentationEquipementMedia))]
        public virtual ICollection<Media>? MediaPresentationEquipement { get; set; }
    }
}
