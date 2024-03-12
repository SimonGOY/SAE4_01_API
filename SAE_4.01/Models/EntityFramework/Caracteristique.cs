using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_caracteristique_car")]
    public partial class Caracteristique
    {
        public Caracteristique()
        {
            
        }

        [Key]
        [Column("car_id")]
        public int IdCaracteristique { get; set; }

        [Column("car_idmoto")]
        public int? IdMoto { get; set; }

        [Column("car_idcat")]
        public int? IdCatCaracteristique { get; set; }

        [Column("car_nom")]
        [StringLength(50)]
        public string? NomCaracteristique { get; set; }

        [Column("car_valeur")]
        public string? ValeurCaracteristique { get; set; }
    }
}.
