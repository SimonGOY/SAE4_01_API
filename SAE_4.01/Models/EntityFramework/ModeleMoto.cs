using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_modele_moto_mod")]
    public partial class ModeleMoto
    {
        [Key]
        [Column("mod_id")]
        public int IdMoto { get; set; }

        [Column("gam_idgamme")]
        public int IdGamme { get; set; }

        [Column("mod_nommoto")]
        [StringLength(50)]
        public string NomMoto { get; set; } = null!;

        [Column("mod_desc")]
        public string DescriptifMoto { get; set; } = null!;

        [Column("mod_prix")]
        public float PrixMoto { get; set; }


        [ForeignKey(nameof(IdGamme))]
        [InverseProperty(nameof(GammeMoto.ModeleMotoGammeMoto))]
        public virtual GammeMoto GammeMotoModeleMoto { get; set; } = null!;


        [InverseProperty(nameof(Caracteristique.ModeleMotoCaracteristique))]
        public virtual ICollection<Caracteristique>? CaracteristiqueModeleMoto { get; set; }

        [InverseProperty(nameof(MotoDisponible.ModeleMotoMotoDisponible))]
        public virtual ICollection<MotoDisponible>? MotoDisponibleModeleMoto { get; set; }

        [InverseProperty(nameof(DemandeEssai.ModeleMotoDemandeEssai))]
        public virtual ICollection<DemandeEssai>? DemandeEssaiModeleMoto { get; set; }

        [InverseProperty(nameof(Media.ModeleMotoMedia))]
        public virtual ICollection<Media>? MediaModeleMoto { get; set; }

        [InverseProperty(nameof(Couleur.ModeleMotoCouleur))]
        public virtual ICollection<Couleur>? CouleurModeleMoto { get; set; }

        [InverseProperty(nameof(Style.ModeleMotoStyle))]
        public virtual ICollection<Style>? StyleModeleMoto { get; set; }

        [InverseProperty(nameof(MotoConfigurable.ModeleMotoMotoConfigurable))]
        public virtual ICollection<MotoConfigurable>? MotoConfigurableModeleMoto { get; set; }

        [InverseProperty(nameof(Accessoire.ModeleAccessoire))]
        public virtual ICollection<Accessoire>? AccessoireMoto { get; set; }

        [InverseProperty(nameof(Pack.ModeleMotoPack))]
        public virtual ICollection<Pack>? PackModeleMoto { get; set; }
    }
}
