﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_modelemoto_mod")]
    public partial class ModeleMoto
    {
        public ModeleMoto()
        {
            
        }

        [Key]
        [Column("mod_id")]
        public int IdMoto { get; set; }

        [Column("gam_idgamme")]
        public int IdGamme { get; set; }

        [Column("mod_nommoto")]
        [StringLength(50)]
        public string NomMoto { get; set; } = null!;

        [Column("mod_desc")]
        public string DescriptifMoto { get; set; } = null!;

        [Column("mod_prix")]
        public float PrixMoto { get; set; }

        [ForeignKey(nameof(IdGamme))]
        [InverseProperty(nameof(GammeMoto.ModelesMoto))]
        public virtual GammeMoto GammesMoto { get; set; } = null!;

        [ForeignKey(nameof(IdGamme))]
        [InverseProperty(nameof(MotoDisponible.ModelesMoto))]
        public virtual MotoDisponible MotosDisponible { get; set; } = null!;

        //[InverseProperty(nameof(Caracteristique.nom))]
        //public virtual ICollection<Caracteristique> Caracteristiques { get; set; }

        //[InverseProperty(nameof(Media.nom))]
        //public virtual ICollection<Media> Medias { get; set; }
    }
}
