using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_j_estlie_eli")]
    public partial class EstLie
    {
        [Key]
        [Column("equ_idequipement")]
        public int IdEquipement { get; set; }

        [Key]
        [Column("equ_equidequipement")]
        public int EquIdEquipement { get; set; }


        [ForeignKey(nameof(IdEquipement))]
        [InverseProperty(nameof(Equipement.EstLieEquipement1))]
        public virtual Equipement EquipementEstLie1 { get; set; } = null!;

        [ForeignKey(nameof(EquIdEquipement))]
        [InverseProperty(nameof(Equipement.EstLieEquipement2))]
        public virtual Equipement EquipementEstLie2 { get; set; } = null!;
    }
}
