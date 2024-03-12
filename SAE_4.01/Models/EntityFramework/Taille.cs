using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_r_taille_tle")]
    public partial class Taille
    {
        [Key]
        [Column("tle_id")]
        public int IdTaille { get; set; }

        [Column("tle_libelle")]
        [StringLength(15)]
        public string? LibelleTaille { get; set; }

        [Column("tle_description")]
        [StringLength(8)]
        public string? DescTaille { get; set; }
    }
}
