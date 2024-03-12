﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_concessionnaire_con")]
    public class Concessionnaire
    {
        [Key]
        [Column("con_id")]
        public int IdConcessionnaire { get; set; }

        [Column("con_nom")]
        [StringLength(50)]
        public string? NomConcessionnaire { get;set; } = null!;

        [Column("con_email")]
        [StringLength(100)]
        public string? EmailConcessionnaire { get; set; } = null!;

        [Column("con_site")]
        [StringLength(150)]
        public string? SiteConcessionnaire { get; set; } = null!;

        [Column("con_telephone")]
        [StringLength(20)]
        public string? TelephoneConcessionnaire { get; set; } = null!;

        [Column("con_adresse")]
        public string? AdresseConcessionnaire { get; set; } = null!;
    }
}