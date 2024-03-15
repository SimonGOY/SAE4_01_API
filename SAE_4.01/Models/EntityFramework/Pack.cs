using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Xml.Linq;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_pack_pck")]
    [Index(nameof(IdMoto), nameof(NomPack), Name = "uq_pck_mod_id_nom", IsUnique = true)]
    public class Pack
    {
        public Pack()
        {
            SeComposePack = new HashSet<SeCompose>();
        }

        [Key]
        [Column("pck_id")]
        public int IdPack { get; set; }

        [Column("mod_id")]
        public int IdMoto { get; set; }

        [Column("pck_nom")]
        [StringLength(20)]
        public string NomPack { get; set; } = null!;

        [Column("pck_description")]
        public string DescriptionPack { get; set; } = null!;

        [Column("pck_photo")]
        [StringLength(50)]
        public string PhotoPack { get; set; } = null!;

        [Column("pck_prix", TypeName = "DECIMAL(6,2)")]
        public decimal PrixPack { get; set; }


        [ForeignKey(nameof(IdMoto))]
        [InverseProperty(nameof(ModeleMoto.PackModeleMoto))]
        public virtual ModeleMoto ModeleMotoPack { get; set; } = null!;


        [InverseProperty(nameof(SeCompose.PackSeCompose))]
        public virtual ICollection<SeCompose>? SeComposePack { get; set; }
    }
}
