namespace MyZoo.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Family
    {
        public int FamilyId { get; set; }

        public int? ChildId { get; set; }

        public int? MotherId { get; set; }

        public int? FatherId { get; set; }

        public virtual Animal Animal { get; set; }

        public virtual Animal Animal1 { get; set; }

        public virtual Animal Animal2 { get; set; }
    }
}
