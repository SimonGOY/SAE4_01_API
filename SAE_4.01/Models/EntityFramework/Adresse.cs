using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_adresse_adr")]
    public partial class Adresse
    {
        [Key]
        [Column("adr_num")]
        public int NumAdresse { get; set; }

        [Column("pay_nom")]
        [StringLength(50)]
        public string NomPays { get; set; } = null!;

        [Column("adr_adresse")]
        [StringLength(50)]
        public string AdresseAdresse { get; set; } = null!;


        [ForeignKey(nameof(NomPays))]
        [InverseProperty(nameof(Pays.AdressePays))]
        public virtual Pays PaysAdresse { get; set; } = null!;


        [InverseProperty(nameof(Client.AdresseClient))]
        public virtual ICollection<Client>? ClientAdresse { get; set; }
    }

    public partial class Adresse
    {
        public override bool Equals(object? obj)
        {
            return obj is Adresse adresse &&
                   this.NumAdresse == adresse.NumAdresse &&
                   this.NomPays == adresse.NomPays &&
                   this.AdresseAdresse == adresse.AdresseAdresse;
        }
    }
}
