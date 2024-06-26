﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_style_sty")]
    public class Style
    {
        public Style()
        {
            EstInclusStyle = new HashSet<EstInclus>();
        }

        [Key]
        [Column("sty_id")]
        public int IdStyle { get; set; }

        [Column("sty_nom")]
        public string NomStyle { get; set; } = null!;

        [Column("sty_prix")]
        public double PrixStyle { get; set; }

        [Column("sty_description")]
        public string DescriptionStyle { get; set; } = null!;

        [Column("sty_photo")]
        public string PhotoStyle { get; set; } = null!;

        [Column("mod_id")]
        public int IdMoto { get; set; }

        [Column("sty_photomoto")]
        public string PhotoMoto { get; set; } = null!;


        [ForeignKey(nameof(IdMoto))]
        [InverseProperty(nameof(ModeleMoto.StyleModeleMoto))]
        public virtual ModeleMoto ModeleMotoStyle { get; set; } = null!;


        [InverseProperty(nameof(EstInclus.StyleEstInclus))]
        public virtual ICollection<EstInclus>? EstInclusStyle { get; set; }

    }
}
