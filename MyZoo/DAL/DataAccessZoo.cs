using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.SqlServer.Server;
using MyZoo.DataContext;
using MyZoo.Model;

namespace MyZoo.DAL
{
    class DataAccessZoo
    {
        public DataAccessZoo()
        {

        }

        public BindingList<AnimalDetailed> GetDetailedAnimal(UserSearchModel search)
        {
            BindingList<AnimalDetailed> list;

            using (var db = new ZooDataBaseContext())
            {
                if (search.SpeciesSearch != "")
                {
                    var query =
                        from animal in db.Animals
                        where animal.Species.Name.ToLower()
                            .Contains(search.SpeciesSearch.ToLower())
                        join family in db.Families
                            on animal.AnimalId equals family.ChildId into AnimalChildFamily
                        from animalFamily in AnimalChildFamily
                        select new AnimalDetailed()
                        {
                            AnimalId = animal.AnimalId,
                            CountryOfOrigin = animal.Country.Name,
                            Environment = animal.Species.Environment.Name,
                            Father = animalFamily.AnimalFather.Name,
                            Mother = animalFamily.AnimalMother.Name,
                            Name = animal.Name,
                            Sex = animal.Sex,
                            Species = animal.Species.Name,
                            Type = animal.Species.Type.Name,
                            WeightInKilogram = animal.Weight,
                        };

                    list = new BindingList<AnimalDetailed>(query.ToList());
                }
                else
                {
                    var query =
                        from animal in db.Animals
                        join family in db.Families
                            on animal.AnimalId equals family.ChildId into AnimalChildFamily
                        from animalFamily in AnimalChildFamily
                        select new AnimalDetailed()
                        {
                            AnimalId = animal.AnimalId,
                            CountryOfOrigin = animal.Country.Name,
                            Environment = animal.Species.Environment.Name,
                            Father = animalFamily.AnimalFather.Name,
                            Mother = animalFamily.AnimalMother.Name,
                            Name = animal.Name,
                            Sex = animal.Sex,
                            Species = animal.Species.Name,
                            Type = animal.Species.Type.Name,
                            WeightInKilogram = animal.Weight,
                        };

                    list = new BindingList<AnimalDetailed>(query.ToList());
                }

            }

            return list;
        }

        public void RemoveAnimal(int animalId)
        {
            using (var db = new ZooDataBaseContext())
            {
                var animal = db.Animals.Find(animalId);
                var d = from f in db.Families
                        where f.AnimalChild.AnimalId == animalId
                        select f;
                var family = d.ToList()[0];
                db.Families.Remove(family);
                db.Animals.Remove(animal);
                db.SaveChanges();
            }
        }
    }
}
