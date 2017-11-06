using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZoo.DataContext
{
    public class Species
    {
        public int SpeciesId { get; set; }
        public string Name { get; set; }

        public virtual Type Type { get; set; }
        public virtual Environment Environment { get; set; }

    }
}
