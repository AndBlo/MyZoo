using MyZoo.DataContext;

namespace MyZoo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyZoo.DataContext.ZooDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyZoo.DataContext.ZooDBContext context)
        {
            DataContext.Type type1 = new DataContext.Type()
            {
                Name = "Köttätare"
            };
            DataContext.Type type2 = new DataContext.Type()
            {
                Name = "Växtätare"
            };

            DataContext.Environment environment1 = new DataContext.Environment()
            {
                Name = "Mark"
            };
            DataContext.Environment environment2 = new DataContext.Environment()
            {
                Name = "Träd"
            };
            DataContext.Environment environment3 = new DataContext.Environment()
            {
                Name = "Vatten"
            };

            CountryOfOrigin coo1 = new CountryOfOrigin()
            {
                Name = "Sverige"
            };
            CountryOfOrigin coo2 = new CountryOfOrigin()
            {
                Name = "Ryssland"
            };

            CountryOfOrigin coo3 = new CountryOfOrigin()
            {
                Name = "Zambia"
            };

            Species species1 = new Species()
            {
                Name = "Björn",
                Environment = environment1,
                Type = type1
            };

            Species species2 = new Species()
            {
                Name = "Giraff",
                Environment = environment1,
                Type = type2
            };

            Animal giraff = new Animal()
            {
                Name = "Örjan",
                Weight = 400,
                Sex = "Hane",
                CountryOfOrigin = coo3,
                Species = species2
            };

            Animal animal1Father = new Animal()
            {
                Name = "Sture",
                Weight = 200,
                Sex = "Hane",
                CountryOfOrigin = coo1,
                Species = species1
            };

            Father father1 = new Father()
            {
                Animal = animal1Father
            };

            Animal animal3Mother = new Animal()
            {
                Name = "Pascha",
                Sex = "Hona",
                Weight = 165,
                CountryOfOrigin = coo2,
                Species = species1
            };
            Mother mother1 = new Mother()
            {
                Animal = animal3Mother
            };

            Animal animal2Child = new Animal()
            {
                Name = "Björne",
                Weight = 130,
                Sex = "Hane",
                CountryOfOrigin = coo1,
                Species = species1
            };
            Animal animal4 = new Animal()
            {
                Name = "Putin",
                Weight = 278,
                Sex = "Hane",
                CountryOfOrigin = coo2,
                Species = species1
            };

            ParentCouple unknownCouple = new ParentCouple()
            {
                Father = null,
                Mother = null
            };
            ParentCouple couple1 = new ParentCouple()
            {
                Father = father1,
                Mother = mother1
            };

            animal2Child.ParentCouple = couple1;
            animal1Father.ParentCouple = unknownCouple;

            context.Animals.AddOrUpdate(p => p.Name,
                animal2Child,
                animal4,
                giraff);
        }
    }
}
