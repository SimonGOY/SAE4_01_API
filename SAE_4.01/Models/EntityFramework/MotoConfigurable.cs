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

        [InverseProperty(nameof(Offre.MotoConfigurableOffre))]
        public virtual ICollection<Offre>? OffreMotoConfigurable { get; set; }

        [InverseProperty(nameof(Garage.MotoConfigurableGarage))]
        public virtual ICollection<Garage>? GarageMotoConfigurable { get; set; }

        [InverseProperty(nameof(ModeleMoto.ConfigMoto))]
        public virtual ICollection<ModeleMoto>? ModeleConfig { get; set; }
    }
}
