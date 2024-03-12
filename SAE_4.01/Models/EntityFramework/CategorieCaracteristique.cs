using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_categoriecaracteristique_cat")]
    public partial class CategorieCaracteristique
    {
        public CategorieCaracteristique()
        {
            
        }

        [Key]
        [Column("cat_id")]
        public int IdCatCaracteristique { get; set; }

        [Column("cat_nom")]
        [StringLength(50)]
        public string NomCatCaracteristique { get; set; } = null!;


        [InverseProperty(nameof(Caracteristique.CategorieCaracteristiqueCaracteristique))]
        public virtual ICollection<Caracteristique> CaracteristiqueCategorieCaracteristique { get; set; }
    }
}
