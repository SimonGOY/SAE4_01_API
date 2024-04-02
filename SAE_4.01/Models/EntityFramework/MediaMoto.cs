using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_media_moto_mem")]
    public partial class MediaMoto
    {
        [Key]
        [Column("mem_id")]
        public int IdMediaMoto { get; set; }

        [Column("mod_idmoto")]
        public int IdMoto { get; set; }

        [Column("mem_lienmedia")]
        public string LienMedia { get; set; } = null!;

        [Column("mem_reference")]
        public Boolean IsReference { get; set; }


        [ForeignKey(nameof(IdMoto))]
        [InverseProperty(nameof(ModeleMoto.MediaModeleMoto))]
        public virtual ModeleMoto ModeleMotoMedia { get; set; } = null!;

    }
}
