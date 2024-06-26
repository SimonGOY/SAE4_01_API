﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_client_clt")]
    public partial class Client
    {
        public Client ()
        {
            PrefereClient= new HashSet<Prefere> ();
        }

        [Key]
        [Column("clt_id")]
        public int? IdClient { get; set; }

        [Column("adr_numeroadresse")]
        public int NumAdresse { get; set; }

        [Column("clt_civilite")]
        [StringLength(10)]
        public string Civilite { get; set; } = null!;

        [Column("clt_nom")]
        [StringLength(50)]
        public string NomClient { get; set; } = null!;

        [Column("clt_prenom")]
        [StringLength(50)]
        public string PrenomClient { get; set; } = null!;

        [Column("clt_datenaissance", TypeName ="DATE")]
        public DateTime DateNaissanceClient { get; set; }

        [Column("clt_email")]
        [StringLength(100)]
        public string EmailClient { get; set; } = null!;

        [ForeignKey(nameof(NumAdresse))]
        [InverseProperty(nameof(Adresse.ClientAdresse))]
        public virtual Adresse AdresseClient { get; set; } = null!;

        [InverseProperty(nameof(InfoCB.ClientInfoCB))]
        public virtual ICollection<InfoCB>? InfoCBClient { get; set; }

        [InverseProperty(nameof(Commande.ClientCommande))]
        public virtual ICollection<Commande>? CommandeClient { get; set; }

        [InverseProperty(nameof(Garage.ClientGarage))]
        public virtual ICollection<Garage>? GarageClient { get; set; }

        [InverseProperty(nameof(Professionnel.ClientProfessionnel))]
        public virtual ICollection<Professionnel>? ProfessionnelClient { get; set; }

        [InverseProperty(nameof(Reservation.ClientReservation))]
        public virtual ICollection<Reservation>? ReservationClient { get; set; }

        [InverseProperty(nameof(Prefere.ClientPrefere))] 
        public virtual ICollection<Prefere>? PrefereClient { get; set; }

        [InverseProperty(nameof(Prive.ClientPrive))]
        public virtual ICollection<Prive>? PriveClient { get; set; }

        [InverseProperty(nameof(User.ClientUsers))]
        public virtual ICollection<User>? UsersClient { get; set; }

        [InverseProperty(nameof(Telephone.ClientTelephone))]
        public virtual ICollection<Telephone>? TelephoneClient { get; set; }

    }
}
