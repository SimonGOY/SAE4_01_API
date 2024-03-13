using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_motodisponible_mdp")]
    public partial class MotoDisponible
    {
        [Key]
        [Column("mdp_id")]
        public int IdMotoDisponible { get; set; }

        [Column("mdp_prix")]
        public float PrixMotoDisponible { get; set; }

        [Column("mod_idmoto")]
        public int IdMoto { get; set; }


        [ForeignKey(nameof(IdMotoDisponible))]
        [InverseProperty(nameof(ModeleMoto.MotoDisponibleModeleMoto))]
        public virtual ModeleMoto ModeleMotoMotoDisponible { get; set; } = null!;


        [InverseProperty(nameof(Reservation.MotoDisponibleReservation))]
        public virtual ICollection<Reservation>? ReservationMotoDisponible { get; set; }
    }
}
