﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_equipement_equ")]
    public partial class Equipement
    {
        public Equipement()
        {
            
        }

        [Key]
        [Column("equ_id")]
        public int IdEquipement { get; set; }

        [Column("equ_idcollection")]
        public int? IdCollection { get; set; }

        [Column("equ_idcatequipement")]
        public int? IdCatEquipement { get; set; }

        [Column("equ_nom")]
        [StringLength(50)]
        public string? NomEquipement { get; set; }

        [Column("equ_desc")]
        public string? DescriptionEquipement { get; set; }

        [Column("equ_sexe")]
        [StringLength(10)]
        public string? SexeEquipement { get; set; }

        [Column("equ_prix")]
        public float? PrixEquipement { get; set; }

        [Column("equ_dureegarantie")]
        public int? DureeGarantie { get; set; }

        [Column("equ_tendance")]
        public bool? Tendance { get; set; }

        [Column("equ_segment")]
        [StringLength(30)]
        public string? Segment { get; set; }
    }
}