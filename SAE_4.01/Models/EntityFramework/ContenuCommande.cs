using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_contenu_commande_ccm")]
    public class ContenuCommande
    {
        [Key]
        [Column("equ_id")]
        public int IdEquipement { get; set; }
        [Key]
        [Column("tle_id")]
        public int IdTaille { get; set; }
        [Key]
        [Column("cls_id")]
        public int IdColoris { get; set; }
        [Key]
        [Column("cmd_id")]
        public int IdCommande { get; set; }
        [Column("equ_quantite")]
        public int Quantite { get; set; }


        [ForeignKey(nameof(IdEquipement))]
        [InverseProperty(nameof(Equipement.Equipement))]
        public virtual Equipement Equipement { get; set; } = null!;

        [ForeignKey(nameof(IdTaille))]
        [InverseProperty(nameof(Taille.Taille))]
        public virtual Taille Taille { get; set; } = null!;

        [ForeignKey(nameof(IdColoris))]
        [InverseProperty(nameof(Coloris.Coloris))]
        public virtual Coloris Coloris { get; set; } = null!;

        [ForeignKey(nameof(IdCommande))]
        [InverseProperty(nameof(Commande.Commande))]
        public virtual Commande Commande { get; set; } = null!;
    }
}
