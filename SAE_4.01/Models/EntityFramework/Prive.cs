using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_prive_prv")]
    public partial class Prive
    {
        [Key]
        [Column("prv_id")]
        public int IdPrive { get; set; }

        [Column("clt_id")]
        public int IdClient { get; set; }

        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.PriveClient))]
        public virtual Client ClientPrive { get; set; } = null!;
    }
}
