using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_j_estinclus_ein")]
    public class EstInclus
    {
        [Key]
        [Column("opt_id")]
        public int IdOption { get; set; }
        [Key]
        [Column("sty_id")]
        public int IdStyle { get; set; }

        /* A faire les 2 foreign key*/
    }
}
