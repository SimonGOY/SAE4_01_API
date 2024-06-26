﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_collection_cln")]
    public partial class Collection
    {
        [Key]
        [Column("cln_id")]
        public int IdCollection { get; set; }

        [Column("cln_nom")]
        [StringLength(50)]
        public string NomCollection { get; set; } = null!;


        [InverseProperty(nameof(Equipement.CollectionEquipement))]
        public virtual ICollection<Equipement>? EquipementCollection { get; set; }
    }
}
