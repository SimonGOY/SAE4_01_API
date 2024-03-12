﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SAE_4._01.Models.EntityFramework
{
    [Table("t_e_stock_stk")]
    public class Stock
    {
        [Key]
        [Column("tle_id")]
        public int IdTaille { get; set; }

        [Key]
        [Column("col_id")]
        public int IdColoris { get; set; }

        [Key]
        [Column("eqp_id")]
        public int IdEquipement { get; set; }

        [Column("stk_quantite")]
        public int Quantite { get; set; }
    }
}
