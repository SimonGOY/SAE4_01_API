using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_coloris_cls")]
    [Index(nameof(NomColoris), Name = "uq_cls_nom", IsUnique = true)]
    public class Coloris
    {
        [Key]
        [Column("cls_id")]
        public int IdColoris { get; set; }

        [Column("cls_nom")]
        [StringLength(20)]
        public string NomColoris { get; set; } = null!;

        [InverseProperty(nameof(Stock.ColorisStock))]
        public virtual ICollection<Stock>? StockColoris { get; set; }


        [InverseProperty(nameof(PresentationEquipement.ColorisPresentationEquipement))]
        public virtual ICollection<PresentationEquipement>? PresentationEquipementColoris { get; set; }

        [InverseProperty(nameof(ContenuCommande.ColorisContenuCommande))]
        public virtual ICollection<ContenuCommande>? ContenuCommandeColoris { get; set; }
    }
}
