using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_option_opt")]
    public class Option
    {
        [Key]
        [Column("opt_id")]
        public int IdOption { get; set; }
        [Column("opt_nom")]
        [StringLength(50)]
        public string NomOption { get; set; } = null!;
        [Column("opt_prix")]
        public decimal PrixOption { get; set; }
        [Column("opt_detail")]
        public string DetailOption { get; set; } = null!;
        [Column("opt_photo")]
        public string PhotoOption { get; set; } = null!;

        [InverseProperty(nameof(EstInclus.OptionIncluse))]
        public virtual ICollection<EstInclus>? InclusOption { get; set; }
    }
}
