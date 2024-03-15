using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_j_est_inclus_ecl")]
    public class EstInclus
    {
        [Key]
        [Column("opt_id")]
        public int IdOption { get; set; }
        [Key]
        [Column("sty_id")]
        public int IdStyle { get; set; }


        [ForeignKey(nameof(IdOption))]
        [InverseProperty(nameof(Option.EstInclusOption))]
        public virtual Option OptionEstInclus { get; set; } = null!;

        [ForeignKey(nameof(IdStyle))]
        [InverseProperty(nameof(Style.EstInclusStyle))]
        public virtual Style StyleEstInclus { get; set; } = null!;
    }
}
