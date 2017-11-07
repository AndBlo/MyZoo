using MyZoo.DataContext;

namespace MyZoo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyZoo.DataContext.ZooDataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyZoo.DataContext.ZooDataBaseContext context)
        {
            Country sweden = new Country()
            {
                Name = "Sverige"
            };
            Country russia = new Country()
            {
                Name = "Ryssland"
            };
            Country zimbabwe = new Country()
            {
                Name = "Zimbabwe"
            };

            DataContext.Type carnivore = new DataContext.Type()
            {
                Name = "Köttätare"
            };
            DataContext.Type herbivore = new DataContext.Type()
            {
                Name = "Växtätare"
            };

            DataContext.Environment ground = new DataContext.Environment()
            {
                Name = "Mark"
            };
            DataContext.Environment tree = new DataContext.Environment()
            {
                Name = "Träd"
            };
            DataContext.Environment water = new DataContext.Environment()
            {
                Name = "Vatten"
            };

            Species bear = new Species()
            {
                Name = "Björn",
                Environment = ground,
                Type = carnivore
            };
            Species amazonParrot = new Species()
            {
                Name = "Amazonpapegoja",
                Environment = tree,
                Type = herbivore
            };
            Species seal = new Species()
            {
                Name = "Knubbsäl",
                Environment = water,
                Type = carnivore
            };

            Animal bearMotherPascha = new Animal()
            {
                Name = "Pascha",
                Weight = 145,
                Species = bear,
                Country = russia
            };
            Animal bearFatherSture = new Animal()
            {
                Name = "Sture",
                Weight = 230,
                Species = bear,
                Country = sweden
            };
            Animal bearChildBjorne = new Animal()
            {
                Name = "Björne",
                Weight = 95,
                Species = bear,

            };

            Animal parrotMotherDoris = new Animal()
            {
                Name = "Doris",
                Weight = 1,
                Species = amazonParrot,
                Country = sweden
            };
            Animal parrotFatherGreger = new Animal()
            {
                Name = "Greger",
                Weight = 1,
                Species = amazonParrot,
                Country = sweden
            };
            Animal parrotChildSvea
        }
    }
}
