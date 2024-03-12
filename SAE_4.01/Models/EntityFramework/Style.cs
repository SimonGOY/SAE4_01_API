using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_style_sty")]
    public class Style
    {
        [Key]
        [Column("sty_id")]
        public int IdStyle { get; set; }
        [Column("sty_nom")]
        public string Name { get; set; } = null!;
        [Column("sty_prix")]
        public double PrixStyle { get; set; }
        [Column("sty_description")]
        public string DescriptionStyle { get; set; } = null !;
        [Column("sty_photo")]
        public string PhotoStyle { get; set; } = null!;
        [Column("sty_photomoto")]
        public string PhotoMoto { get; set; } = null!;

        /* A faire
        [InverseProperty("NomPropInversee")]
        public virtual Type IdMoto { get; set; } = null!;*/

    }
}
