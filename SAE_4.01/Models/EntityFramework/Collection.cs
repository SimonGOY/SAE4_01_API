using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_collection_col")]
    public partial class Collection
    {
        public Collection()
        {
            
        }

        [Key]
        [Column("col_id")]
        public int IdCollection { get; set; }

        [Column("col_nom")]
        [StringLength(50)]
        public string NomCollection { get; set; } = null!;
    }
}
