using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_j_est_inclus_ein")]
    public class Est_Inclus
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
