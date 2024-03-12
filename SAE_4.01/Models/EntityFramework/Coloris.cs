using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_coloris_cls")]
    public class Coloris
    {
        [Key]
        [Column("cls_id")]
        public int IdColoris { get; set; }

        [Column("cls_nom")]
        [StringLength(20)]
        public string? NomColoris { get; set; } = null!;
    }
}
