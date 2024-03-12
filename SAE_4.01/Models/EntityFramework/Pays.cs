using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_pays_pay")]
    public class Pays
    {
        [Key]
        [Column("pay_nom")]
        [StringLength(50)]
        public string? NomPays { get; set; }
    }
}
