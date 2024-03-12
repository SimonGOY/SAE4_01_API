using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_infocb_icb")]
    public class InfoCB
    {
        [Key]
        [Column("icb_id")]
        public int IdCarte { get; set; }

        [Column("icb_numcarte")]
        public string? NumCarte { get; set; } = null!;

        [Column("icb_dateexpiration")]
        public string? DateExpiration { get; set; } = null!;

        [Column("icb_titulairecompte")]
        public string? TitulaireCompte { get; set; } = null!;
    }
}
