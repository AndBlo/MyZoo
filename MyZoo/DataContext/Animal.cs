using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZoo.DataContext
{
    public class Animal
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        [Column("Weight(kg)")]
        public int Weight { get; set; }
        public string Sex { get; set; }

        public int? SpeciesId { get; set; }
        public virtual Species Species { get; set; }

        public int? ParentCoupleId { get; set; }
        public virtual ParentCouple ParentCouple { get; set; }
        public int? CountryOfOriginId { get; set; }
        public virtual CountryOfOrigin CountryOfOrigin { get; set; }
    }
}
