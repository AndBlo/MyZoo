using System.Data.Entity.Validation;
using System.Windows;
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

        public void doIt()
        {
            using (var context = new ZooDataBaseContext())
            {
                try
                {
                    Seed(context);
                }
                catch (DbEntityValidationException e)
                {
                    MessageBox.Show(e.Message);
                    //throw;
                }
            }
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
            Country norway = new Country()
            {
                Name = "Norge"
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
                Sex = "Hona",
                Species = bear,
                Country = russia
            };
            Animal bearFatherSture = new Animal()
            {
                Name = "Sture",
                Weight = 230,
                Sex = "Hane",
                Species = bear,
                Country = sweden
            };
            Animal bearChildBjorne = new Animal()
            {
                Name = "Björne",
                Weight = 95,
                Sex = "Hane",
                Species = bear,
                Country = sweden
            };

            Animal parrotMotherDoris = new Animal()
            {
                Name = "Doris",
                Weight = (float)1.1,
                Sex = "Hona",
                Species = amazonParrot,
                Country = sweden
            };
            Animal parrotFatherGreger = new Animal()
            {
                Name = "Greger",
                Sex = "Hane",
                Weight = (float)1.5,
                Species = amazonParrot,
                Country = sweden
            };
            Animal parrotChildSvea = new Animal()
            {
                Name = "Svea",
                Sex = "Hona",
                Weight = (float)0.5,
                Species = amazonParrot,
                Country = sweden
            };

            Animal sealMotherBerta = new Animal()
            {
                Name = "Berta",
                Weight = 53,
                Sex = "Hona",
                Species = seal,
                Country = norway
            };
            Animal sealFatherRoger = new Animal()
            {
                Name = "Roger",
                Weight = 125,
                Sex = "Hane",
                Species = seal,
                Country = sweden
            };
            Animal sealChildSara = new Animal()
            {
                Name = "Sara",
                Weight = 35,
                Sex = "Hona",
                Species = seal,
                Country = sweden
            };

            Family parrotFamily = new Family()
            {
                AnimalChild = parrotChildSvea,
                AnimalMother = parrotMotherDoris,
                AnimalFather = parrotFatherGreger
            };
            Family bearFamily = new Family()
            {
                AnimalChild = bearChildBjorne,
                AnimalFather = bearFatherSture,
                AnimalMother = bearMotherPascha
            };
            Family sealFamily = new Family()
            {
                AnimalChild = sealChildSara,
                AnimalMother = sealMotherBerta,
                AnimalFather = sealFatherRoger
            };

            context.Families.AddOrUpdate(f => f.FamilyId,
                bearFamily,
                parrotFamily,
                sealFamily
                );

            //context.SaveChanges();
        }
    }
}
