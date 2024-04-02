using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_media_equipement_meq")]
    public partial class MediaEquipement
    {
        [Key]
        [Column("meq_id")]
        public int IdMediaEquipement { get; set; }

        [Column("equ_idequipement")]
        public int? IdEquipement { get; set; }

        [Column("med_lienmedia")]
        public string LienMedia { get; set; } = null!;

        [ForeignKey(nameof(IdEquipement))]
        [InverseProperty(nameof(Equipement.MediaEquipements))]
        public virtual Equipement EquipementMedia { get; set; } = null!;
    }
}
