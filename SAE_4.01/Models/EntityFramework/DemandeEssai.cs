﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_demande_essai_dmd")]
    public partial class DemandeEssai
    {
        [Key]
        [Column("dmd_id")]
        public int IdDemandeEssai { get; set; }

        [Column("con_id")]
        public int IdConcessionnaire { get; set; }

        [Column("mod_id")]
        public int IdMoto { get; set; }

        [Column("ctf_id")]
        public int IdContact { get; set; }

        [Column("dmd_descriptif")]
        public string DescriptifDemandeEssai { get; set; } = null!;

        [ForeignKey(nameof(IdConcessionnaire))]
        [InverseProperty(nameof(Concessionnaire.DemandeEssaiConcessionnaire))]
        public virtual Concessionnaire ConcessionnaireDemandeEssai { get; set; } = null!;

        [ForeignKey(nameof(IdMoto))]
        [InverseProperty(nameof(ModeleMoto.DemandeEssaiModeleMoto))]
        public virtual ModeleMoto ModeleMotoDemandeEssai { get; set; } = null!;

        [ForeignKey(nameof(IdContact))]
        [InverseProperty(nameof(ContactInfo.DemandeEssaiContactInfo))]
        public virtual ContactInfo ContactInfoDemandeEssai { get; set; } = null!;
    }
}
