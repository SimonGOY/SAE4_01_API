using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_demandeessai_dme")]
    public class DemandeEssai
    {
        [Key]
        [Column("dme_id")]
        public int IdDemandeEssai { get; set; }

        [Column("con_id")]
        public int IdConcessionnaire { get; set; }

        [Column("mom_id")]
        public int IdMoto { get; set; }

        [Column("ctf_id")]
        public int IdContact { get; set; }

        [Column("dme_descriptif")]
        public string? DescriptifDemandeEssai { get; set; }
    }
}
