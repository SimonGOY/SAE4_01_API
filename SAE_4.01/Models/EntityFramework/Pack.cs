using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_pack_pck")]
    public class Pack
    {
        [Key]
        [Column("pck_id")]
        public int IdPack { get; set; }
        // A faire :  la foreign key
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


        [InverseProperty(nameof(SeCompose.PackSeCompose))]
        public virtual SeCompose? SeComposePack { get; set; }
    }
}
