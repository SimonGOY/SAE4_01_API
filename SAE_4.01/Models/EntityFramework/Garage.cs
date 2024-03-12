using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_garage_grg")]
    public partial class Garage
    {
        [Key]
        [Column("mcf_id")]
        public int IdMotoConfigurable { get; set; }

        [Key]
        [Column("clt_id")]
        public int IdClient { get; set; }

        [ForeignKey(nameof(IdMotoConfigurable))]
        [InverseProperty(nameof(MotoConfigurable.GarageMotoConfigurable))]
        public virtual MotoConfigurable MotoConfigurableGarage { get; set; } = null!;

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.GarageClient))]
        public virtual Client ClientGarage { get; set; } = null!;
    }
}
