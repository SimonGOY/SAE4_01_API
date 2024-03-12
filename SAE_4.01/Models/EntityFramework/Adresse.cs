using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_adresse_adr")]
    public class Adresse
    {
        [Key]
        [Column("adr_num")]
        public int NumAdresse { get; set; }

        [Column("adr_adresse")]
        [StringLength(50)]
        public string? AdresseAdresse { get; set; } = null!;
    }
}
