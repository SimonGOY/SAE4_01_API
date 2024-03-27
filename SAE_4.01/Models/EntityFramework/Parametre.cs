using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_parametre_par")]
    public class Parametre
    {
        [Key]
        [Column("par_nom")]
        [StringLength(50)]
        public string NomParametre { get; set; } = null!;

        [Column("par_description")]
        [StringLength(50)]
        public string Description { get; set;} = null!;
    }
}
