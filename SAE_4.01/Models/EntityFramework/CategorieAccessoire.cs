using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_categorieaccessoire_cta")]
    public class CategorieAccessoire
    {
        [Key]
        [Column("cta_id")]
        public int IdCatAcc { get; set; }
        [Column("cta_nom")]
        public string NomCatAcc { get; set; } = null!;
    }
}
