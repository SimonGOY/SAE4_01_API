using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_telephone_tel")]
    public class Telephone
    {
        [Key]
        [Column("tel_id")]
        public int Id { get; set; }

        [Column("clt_id")]
        public int IdClient { get; set; }

        [Column("tel_num")]
        [StringLength(20)]
        public string? NumTelephone { get; set; }

        [Column("tel_type")]
        [StringLength(60)]
        public string Type { get; set; } = null!;

        [Column("tel_fonction")]
        [StringLength(25)]
        public string Fonction { get; set; } = null!;


        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.TelephoneClient))]
        public virtual Client ClientTelephone { get; set; } = null!;
    }
}
