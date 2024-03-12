using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_client_clt")]
    public partial class Client
    {
        [Key]
        [Column("clt_id")]
        public int IdClient { get; set; }

        [Column("clt_numeroadresse")]
        public int NumAdresse { get; set; }

        [Column("clt_civilite")]
        [StringLength(10)]
        public string? Civilite { get; set; }

        [Column("clt_nom")]
        [StringLength(50)]
        public string? NomClient { get; set; }

        [Column("clt_prenom")]
        [StringLength(50)]
        public string? PrenomClient { get; set; }

        [Column("clt_datenaissance", TypeName ="DATE")]
        public DateTime DateNaissanceClient { get; set; }

        [Column("clt_email")]
        [StringLength(50)]
        public string? EmailClient { get; set; }

        [InverseProperty(nameof(InfoCB.ClientInfoCB))]
        public virtual ICollection<InfoCB>? InfoCBClient { get; set; }


        //[InverseProperty(nameof(Reservation.nom))]
        //public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
