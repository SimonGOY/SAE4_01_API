using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_j_se_compose_sec")]
    public class SeCompose
    {
        [Key]
        [Column("pck_id")]
        public int IdPack { get; set; }
        [Key]
        [Column("opt_id")]
        public int IdOption { get; set; }


        [ForeignKey(nameof(IdPack))]
        [InverseProperty(nameof(Pack.SeComposePack))]
        public virtual Pack PackSeCompose { get; set; } = null!;

        [ForeignKey(nameof(IdOption))]
        [InverseProperty(nameof(Option.SeComposeOption))]
        public virtual Option OptionSeCompose { get; set; } = null!;
    }
}
