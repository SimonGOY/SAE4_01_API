using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_media_med")]
    public partial class Media
    {
        public Media()
        {
            
        }

        [Key]
        [Column("med_id")]
        public int IdMedia { get; set; }

        [Column("equ_idequipement")]
        public int IdEquipement { get; set; }

        [Column("mod_idmoto")]
        public int IdMoto { get; set; }

        [Column("pre_idpresentation")]
        public int IdPresentation { get; set; }

        [Column("med_lienmedia")]
        public string LienMedia { get; set; } = null!;
    }
}
