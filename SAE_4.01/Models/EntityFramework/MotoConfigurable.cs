using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_r_motoconfigurable_mcf")]
    public class MotoConfigurable
    {
        [Key]
        [Column("mcf_id")]
        public int IdMotoConfigurable { get; set; }
        [Column("mod_id")]
        public int IdMoto { get; set; }


        [ForeignKey(nameof(IdMoto))]
        [InverseProperty(nameof(ModeleMoto.MotoConfigurableModeleMoto))]
        public virtual ModeleMoto ModeleMotoMotoConfigurable { get; set; } = null!;


        [InverseProperty(nameof(Offre.MotoConfigurableOffre))]
        public virtual ICollection<Offre>? OffreMotoConfigurable { get; set; }

        [InverseProperty(nameof(Garage.MotoConfigurableGarage))]
        public virtual ICollection<Garage>? GarageMotoConfigurable { get; set; }

        [InverseProperty(nameof(Specifie.MotoConfigurableSpecifie))]
        public virtual ICollection<Specifie>? SpecifieMotoConfigurable { get; set; }
    }
}
