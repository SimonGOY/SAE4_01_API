using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_concessionnaire_con")]
    public class Concessionnaire
    {
        public Concessionnaire()
        {
            PrefereConcessionnaire = new HashSet<Prefere>();
        }

        [Key]
        [Column("con_id")]
        public int IdConcessionnaire { get; set; }

        [Column("con_nom")]
        [StringLength(50)]
        public string NomConcessionnaire { get;set; } = null!;

        [Column("con_email")]
        [StringLength(100)]
        public string EmailConcessionnaire { get; set; } = null!;

        [Column("con_site")]
        [StringLength(150)]
        public string SiteConcessionnaire { get; set; } = null!;

        [Column("con_telephone")]
        [StringLength(20)]
        public string TelephoneConcessionnaire { get; set; } = null!;

        [Column("con_adresse")]
        public string AdresseConcessionnaire { get; set; } = null!;


        [InverseProperty(nameof(Offre.ConcessionnaireOffre))]
        public virtual ICollection<Offre>? OffreConcessionnaire { get; set; }

        [InverseProperty(nameof(Reservation.ConcessionnaireReservation))]
        public virtual ICollection<Reservation>? ReservationConcessionnaire { get; set; }

        [InverseProperty(nameof(Prefere.ConcessionnairePrefere))]
        public virtual ICollection<Prefere>? PrefereConcessionnaire { get; set; }

        [InverseProperty(nameof(DemandeEssai.ConcessionnaireDemandeEssai))]
        public virtual ICollection<DemandeEssai>? DemandeEssaiConcessionnaire { get; set; }
    }
}
