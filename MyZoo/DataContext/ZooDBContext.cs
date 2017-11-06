using System.Data.Entity.Migrations.Model;

namespace MyZoo.DataContext
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ZooDBContext : DbContext
    {
        // Your context has been configured to use a 'ZooDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MyZoo.DataContext.ZooDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ZooDBContext' 
        // connection string in the application configuration file.
        public ZooDBContext()
            : base("name=ZooDBContext")
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<CountryOfOrigin> CountryOfOrigins { get; set; }
        public virtual DbSet<Environment> Environments { get; set; }
        public virtual DbSet<Father> Fathers { get; set; }
        public virtual DbSet<Mother> Mothers { get; set; }
        public virtual DbSet<ParentCouple> ParentCouples { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<Type> Types { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);
        }
    }

}