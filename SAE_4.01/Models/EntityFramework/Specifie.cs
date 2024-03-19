using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_j_specifie_spe")]
    public class Specifie
    {
        [Key]
        [Column("opt_id")]
        public int IdOption { get; set; }
        [Key]
        [Column("spe_idmoto")]
        public int IdMoto { get; set; }


        [ForeignKey(nameof(IdOption))]
        [InverseProperty(nameof(Option.SpecifieOption))]
        public virtual Option OptionSpecifie { get; set; } = null!;

        [ForeignKey(nameof(IdMoto))]
        [InverseProperty(nameof(ModeleMoto.SpecifieModeleMoto))]
        public virtual ModeleMoto ModeleMotoSpecifie { get; set; } = null!;
    }
}
