﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_categorie_accessoire_cta")]
    public class CategorieAccessoire
    {
        [Key]
        [Column("cta_id")]
        public int IdCatAcc { get; set; }
        [Column("cta_nom")]
        [StringLength(50)]
        public string NomCatAcc { get; set; } = null!;

        [InverseProperty(nameof(Accessoire.CateAccessoire))]
        public virtual ICollection<Accessoire>? AccessoireCategorise { get; set; }
    }
}
