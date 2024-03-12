using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_couleur_clr")]
    public class Couleur
    {
        [Key]
        [Column("clr_id")]
        public int IdCouleur { get; set; }
        // A faire : idmoto
        [Column("clr_nom")]
        [StringLength(50)]
        public string NomCouleur { get; set; } = null!;
        [Column("clr_prix")]
        public double PrixCouleur { get; set; }
        [Column("clr_description")]
        public string DescriptionCouleur { get; set; } = null!;
        [Column("clr_photo")]
        public string PhotoCouleur { get; set; } = null!;
        [Column("clr_moto")]
        public string MotoCouleur { get; set; } = null!;

    }
}
