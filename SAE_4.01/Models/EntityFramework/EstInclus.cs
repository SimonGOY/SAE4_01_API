using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_j_estinclus_ecl")]
    public class EstInclus
    {
        [Key]
        [Column("opt_id")]
        public int IdOption { get; set; }
        [Key]
        [Column("sty_id")]
        public int IdStyle { get; set; }


        [ForeignKey(nameof(IdOption))]
        [InverseProperty(nameof(Option.InclusOption))]
        public virtual Option OptionInclus { get; set; } = null!;

        [ForeignKey(nameof(IdStyle))]
        [InverseProperty(nameof(Style.InclusStyle))]
        public virtual Style StyleInclus { get; set; } = null!;
    }
}
