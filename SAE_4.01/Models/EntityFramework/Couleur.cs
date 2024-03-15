using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_couleur_clr")]
    [Index(nameof(NomCouleur),nameof(DescriptionCouleur), Name = "uq_clr_nom", IsUnique = true)]
    public class Couleur
    {
        [Key]
        [Column("clr_id")]
        public int IdCouleur { get; set; }

        [Column("mod_id")]
        public int IdMoto { get; set; }

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


        [ForeignKey(nameof(IdMoto))]
        [InverseProperty(nameof(ModeleMoto.CouleurModeleMoto))]
        public virtual ModeleMoto ModeleMotoCouleur { get; set; } = null!;
    }
}
