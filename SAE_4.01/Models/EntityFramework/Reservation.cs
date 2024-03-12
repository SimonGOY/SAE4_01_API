using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_reservation_res")]
    public partial class Reservation
    {
        public Reservation()
        {

        }

        [Key]
        [Column("res_id")]
        public int IdReservation { get; set; }

        [Column("res_idmoto")]
        public int IdMotoDisponible { get; set; }

        [Column("res_idclient")]
        public int IdClient { get; set; }

        [Column("res_idconcessionnaire")]
        public int IdConcessionnaire { get; set; }

        [Column("res_dateres", TypeName = "date")]
        public DateTime DateReservation { get; set; }

        [Column("res_financement")]
        [StringLength(30)]
        public string FinancementReservation { get; set; } = null!;
    }
}
