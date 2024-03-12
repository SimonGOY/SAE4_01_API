using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_accessoire_acc")]
    public class Accessoire
    {
        [Key]
        [Column("acc_id")]
        public int IdAccessoire { get; set; }
        [Column("acc_nom")]
        [StringLength(50)]
        public string NomAccessoire { get; set; } = null!;
        [Column("acc_prix")]
        public decimal PrixAccessoire { get; set; }
        [Column("acc_detail")]
        public string DetailAccessoire { get; set; } = null!;
        [Column("acc_photo")]
        public string PhotoAccessoire { get; set; } = null!;

        /* A faire
        [InverseProperty("NomPropInversee")]
        public virtual Type IdMoto { get; set; } = null!;
        
        [InverseProperty("NomPropInversee")]
        public virtual Type IdCatAcc { get; set; } = null!;*/
    }
}
