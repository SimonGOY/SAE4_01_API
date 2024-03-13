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
        [InverseProperty(nameof(Equipement.ContenuCommandeEquipement))]
        public virtual Equipement EquipementContenuCommande { get; set; } = null!;

        [ForeignKey(nameof(IdTaille))]
        [InverseProperty(nameof(Taille.ContenuCommandeTaille))]
        public virtual Taille TailleContenuCommande { get; set; } = null!;

        [ForeignKey(nameof(IdColoris))]
        [InverseProperty(nameof(Coloris.ContenuCommandeColoris))]
        public virtual Coloris ColorisContenuCommande { get; set; } = null!;

        [ForeignKey(nameof(IdCommande))]
        [InverseProperty(nameof(Commande.ContenuCommandeCommande))]
        public virtual Commande CommandeContenuCommande { get; set; } = null!;
    }
}
