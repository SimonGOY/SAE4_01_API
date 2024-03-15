using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_categorie_equipement_cte")]
    public partial class CategorieEquipement
    {
        [Key]
        [Column("cte_id")]
        public int IdCatEquipement { get; set; }

        [Column("cte_catidcatequipement")]
        public int CatIdCatEquipement { get; set; }

        [Column("cte_libelle")]
        [StringLength(100)]
        public string LibelleCatEquipement { get; set; } = null!;


        [ForeignKey(nameof(CatIdCatEquipement))]
        [InverseProperty(nameof(CategorieEquipement.CategorieEquipementCategorieEquipementProperty))]
        public virtual CategorieEquipement CategorieEquipementCategorieEquipementFK { get; set; } = null!;


        [InverseProperty(nameof(CategorieEquipement.CategorieEquipementCategorieEquipementFK))]
        public virtual ICollection<CategorieEquipement>? CategorieEquipementCategorieEquipementProperty { get; set; }

        [InverseProperty(nameof(Equipement.CategorieEquipementEquipement))]
        public virtual ICollection<Equipement>? EquipementCategorieEquipement { get; set; }
    }
}
