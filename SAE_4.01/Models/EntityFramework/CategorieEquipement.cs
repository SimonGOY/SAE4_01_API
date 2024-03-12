using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_categorieequipement_ceq")]
    public partial class CategorieEquipement
    {
        public CategorieEquipement()
        {
            
        }

        [Key]
        [Column("ceq_id")]
        public int IdCatEquipement { get; set; }

        [Column("ceq_catidcatequipement")]
        public int? CatIdCatEquipement { get; set; }

        [Column("ceq_libelle")]
        [StringLength(100)]
        public string? LibelleCatEquipement { get; set; }
    }
}
