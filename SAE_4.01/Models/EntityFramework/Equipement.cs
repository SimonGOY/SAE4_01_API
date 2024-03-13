using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_equipement_equ")]
    public partial class Equipement
    {
        public Equipement()
        {
            EstLieEquipement1 = new HashSet<EstLie>();
            EstLieEquipement2 = new HashSet<EstLie>();
        }

        [Key]
        [Column("equ_id")]
        public int IdEquipement { get; set; }

        [Column("cln_idcollection")]
        public int IdCollection { get; set; }

        [Column("cte_idcatequipement")]
        public int IdCatEquipement { get; set; }

        [Column("equ_nom")]
        [StringLength(50)]
        public string NomEquipement { get; set; } = null!;

        [Column("equ_desc")]
        public string DescriptionEquipement { get; set; } = null!;

        [Column("equ_sexe")]
        [StringLength(10)]
        public string SexeEquipement { get; set; } = null!;

        [Column("equ_prix")]
        public float PrixEquipement { get; set; }

        [Column("equ_dureegarantie")]
        public int DureeGarantie { get; set; }

        [Column("equ_tendance")]
        public bool Tendance { get; set; }

        [Column("equ_segment")]
        [StringLength(30)]
        public string Segment { get; set; } = null!;


        [ForeignKey(nameof(IdCollection))]
        [InverseProperty(nameof(Collection.EquipementCollection))]
        public virtual Collection CollectionEquipement { get; set; } = null!;

        [ForeignKey(nameof(IdCatEquipement))]
        [InverseProperty(nameof(CategorieEquipement.EquipementCategorieEquipement))]
        public virtual CategorieEquipement CategorieEquipementEquipement { get; set; } = null!;


        [InverseProperty(nameof(Stock.EquipementStock))]
        public virtual ICollection<Stock>? StockEquipement { get; set; }

        [InverseProperty(nameof(Media.EquipementMedia))]
        public virtual ICollection<Media>? MediaEquipement { get; set; }

        [InverseProperty(nameof(PresentationEquipement.EquipementPresentationEquipement))]
        public virtual ICollection<PresentationEquipement>? PresentationEquipementEquipement { get; set; }

        [InverseProperty(nameof(EstLie.EquipementEstLie1))]
        public virtual ICollection<EstLie>? EstLieEquipement1 { get; set; }

        [InverseProperty(nameof(EstLie.EquipementEstLie2))]
        public virtual ICollection<EstLie>? EstLieEquipement2 { get; set; }

        [InverseProperty(nameof(ContenuCommande.EquipementContenuCommande))]
        public virtual ICollection<ContenuCommande>? ContenuCommandeEquipement { get; set; }
    }
}
