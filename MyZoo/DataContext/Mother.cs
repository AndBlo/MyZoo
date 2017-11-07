﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZoo.DataContext
{
    public class Mother
    {
        [Key]
        public int MotherId { get; set; }

        public virtual Animal Animal { get; set; }
    }
}
