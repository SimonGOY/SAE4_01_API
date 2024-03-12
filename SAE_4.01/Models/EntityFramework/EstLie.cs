using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_j_estlie_eli")]
    public partial class EstLie
    {
        public EstLie()
        {
            
        }

        [Key]
        [Column("equ_idequipement")]
        public int IdEquipement { get; set; }

        [Key]
        [Column("equ_equidequipement")]
        public int EquIdEquipement { get; set; }



    }
}
