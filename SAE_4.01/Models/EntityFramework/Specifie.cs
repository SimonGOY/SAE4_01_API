using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_j_specifie_spe")]
    public class Specifie
    {
        [Key]
        [Column("spe_idmoto")]
        public int IdMoto { get; set; }
        [Key]
        [Column("opt_id")]
        public int IdOption { get; set;}
        [Column("mcf_id")]
        public int IdMotoConfigurable { get; set;}

        /* A faire les 2 fk idmcf et idopt */
    }
}
