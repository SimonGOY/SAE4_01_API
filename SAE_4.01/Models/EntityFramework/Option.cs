using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_option_opt")]
    public class Option
    {
        public Option()
        {
            InclusOption = new HashSet<EstInclus>();

            SpecifieOption = new HashSet<Specifie>();

            SeComposeOption = new HashSet<SeCompose>();
        }

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


        [InverseProperty(nameof(EstInclus.OptionEstInclus))]
        public virtual ICollection<EstInclus>? EstInclusOption { get; set; }

        [InverseProperty(nameof(Specifie.OptionSpecifie))]
        public virtual ICollection<Specifie>? SpecifieOption { get; set; }

        [InverseProperty(nameof(SeCompose.OptionSeCompose))]
        public virtual ICollection<SeCompose>? SeComposeOption { get; set; }
    }
}
