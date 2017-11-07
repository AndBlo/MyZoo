using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZoo.DataContext
{
    class Family
    {
        public int FamilyId { get; set; }

        public virtual Animal Child { get; set; }
        public virtual Animal Mother { get; set; }
        public virtual Animal Father { get; set; }
    }
}
