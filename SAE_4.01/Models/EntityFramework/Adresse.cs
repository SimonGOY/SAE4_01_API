using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_adresse_adr")]
    public class Adresse
    {
        [Key]
        [Column("adr_num")]
        public int NumAdresse { get; set; }

        [Column("pay_nom")]
        [StringLength(50)]
        public string? NomPays { get; set; }

        [Column("adr_adresse")]
        [StringLength(50)]
        public string AdresseAdresse { get; set; } = null!;

        [ForeignKey(nameof(NomPays))]
        [InverseProperty(nameof(Pays.AdressePays))]
        public virtual Pays PaysAdresse { get; set; } = null!;

        [InverseProperty(nameof(Client.AdresseClient))]
        public virtual ICollection<Client>? ClientAdresse { get; set; }
    }
}
