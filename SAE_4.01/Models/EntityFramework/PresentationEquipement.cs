﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_presentationequipement_pre")]
    public partial class PresentationEquipement
    {
        public PresentationEquipement()
        {
            
        }

        [Key]
        [Column("pre_id")]
        public int IdPresentation { get; set; }

        [Column("pre_idequipement")]
        public int IdEquipement { get; set; }

        [Column("pre_idcoloris")]
        public int IdColoris { get; set; }
    }
}
