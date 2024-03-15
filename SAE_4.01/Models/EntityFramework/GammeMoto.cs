using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_gamme_moto_gam")]
    public partial class GammeMoto
    {
        [Key]
        [Column("gam_id")]
        public int IdGamme { get; set; }

        [Column("gam_libelle")]
        [StringLength(75)]
        public string LibelleGamme { get; set; } = null!;


        [InverseProperty(nameof(ModeleMoto.GammeMotoModeleMoto))]
        public virtual ICollection<ModeleMoto>? ModeleMotoGammeMoto { get; set; }
    }
}
