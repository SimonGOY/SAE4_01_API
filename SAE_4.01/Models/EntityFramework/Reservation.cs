using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_reservation_res")]
    public partial class Reservation
    {
        [Key]
        [Column("res_id")]
        public int IdReservation { get; set; }

        [Column("mot_idmoto")]
        public int IdMotoDisponible { get; set; }

        [Column("clt_idclient")]
        public int IdClient { get; set; }

        [Column("con_idconcessionnaire")]
        public int IdConcessionnaire { get; set; }

        [Column("res_dateres", TypeName = "date")]
        public DateTime DateReservation { get; set; }

        [Column("res_financement")]
        [StringLength(30)]
        public string FinancementReservation { get; set; } = null!;


        [ForeignKey(nameof(IdMotoDisponible))]
        [InverseProperty(nameof(MotoDisponible.ReservationMotoDisponible))]
        public virtual MotoDisponible MotoDisponibleReservation { get; set; } = null!;

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.ReservationClient))]
        public virtual Client ClientReservation { get; set; } = null!;

        [ForeignKey(nameof(IdConcessionnaire))]
        [InverseProperty(nameof(Concessionnaire.ReservationConcessionnaire))]
        public virtual Concessionnaire ConcessionnaireReservation { get; set; } = null!;
    }
}
