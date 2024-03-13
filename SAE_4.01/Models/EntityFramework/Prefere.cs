using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_r_prefere_prf")]
    public class Prefere
    { 
        [Key]
        [Column("clt_id")]
        public int IdClient { get; set; }

        [Key]
        [Column("con_id")]
        public int IdConcessionnaire { get; set; }

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.PrefereClient))]
        public virtual Client ClientPrefere { get; set; } = null!;

        [ForeignKey(nameof(IdConcessionnaire))]
        [InverseProperty(nameof(Concessionnaire.PrefereConcessionnaire))]
        public virtual Concessionnaire ConcessionnairePrefere { get; set; } = null!;
    }
}
