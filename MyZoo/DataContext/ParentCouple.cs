using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZoo.DataContext
{
    public class ParentCouple
    {
        public ParentCouple()
        {
            Animals = new List<Animal>();
        }

        public int ParentCoupleId { get; set; }

        [ForeignKey("Mother")]
        public int? MotherId { get; set; }
        public virtual Mother Mother { get; set; }
        [ForeignKey("Father")]
        public int? FatherId { get; set; }
        public virtual Father Father { get; set; }
        public virtual List<Animal> Animals { get; set; }
    }
}
