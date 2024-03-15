using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_professionnel_pro")]
    [Index(nameof(IdClient), Name = "uq_pro_clt_id", IsUnique = true)]
    public partial class Professionnel
    {
        [Key]
        [Column("pro_id")]
        public int IdPro { get; set; }

        [Column("clt_id")]
        public int IdClient { get; set; }

        [Column("pro_nomcompagnie")]
        [StringLength(100)]
        public string NomCompagnie { get; set; } = null!;


        [ForeignKey(nameof(IdClient))]
        [InverseProperty(nameof(Client.ProfessionnelClient))]
        public virtual Client ClientProfessionnel { get; set; } = null!;
    }

}
