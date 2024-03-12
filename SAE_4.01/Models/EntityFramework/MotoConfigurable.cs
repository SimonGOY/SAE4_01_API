using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_r_motoconfigurable_mcf")]
    public class MotoConfigurable
    {
        [Key]
        [Column("mcf_id")]
        public int IdMotoConfigurable { get; set; }

        /* A faire
        [InverseProperty("NomPropInversee")]
        public virtual Type IdMoto { get; set; } = null!;*/
    }
}
