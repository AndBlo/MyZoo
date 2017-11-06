﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZoo.DataContext
{
    public class Father
    {
        [Key]
        [ForeignKey("Animal")]
        public int? AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
