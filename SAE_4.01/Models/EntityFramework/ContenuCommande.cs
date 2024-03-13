using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_contenu_commande_ccm")]
    public class ContenuCommande
    {
        [Key]
        [Column("equ_id")]
        public int IdEquipement { get; set; }
        [Key]
        [Column("tle_id")]
        public int IdTaille { get; set; }
        [Key]
        [Column("cls_id")]
        public int IdColoris { get; set; }
        [Key]
        [Column("cmd_id")]
        public int IdCommande { get; set; }
        [Column("equ_quantite")]
        public int Quantite { get; set; }

        // A faire les 4 fk

        /* ce modèle
        [ForeignKey(nameof(FilmId))]
        [InverseProperty(nameof(Film.NotesFilm))]
        public virtual Film FilmNote { get; set; } = null!;*/
    }
}
