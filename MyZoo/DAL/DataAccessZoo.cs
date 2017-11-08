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
using MyZoo.Migrations;
using MyZoo.Model;

namespace MyZoo.DAL
{
    class DataAccessZoo
    {
        public DataAccessZoo()
        {

        }

        public BindingList<AnimalDetailed> GetDetailedAnimalList(UserSearchModel search)
        {
            BindingList<AnimalDetailed> list = null;

            using (var db = new ZooDataBaseContext())
            {
                if (search.SpeciesSearch != "" || search.Environment != "--------" || search.Discrimination != "--------" || search.Type != "--------")
                {
                    var queryEnvironment = from a in db.Animals
                                           where a.Species.Name.ToLower().Contains(search.SpeciesSearch)
                                                 && a.Species.Environment.Name == (
                                                              search.Environment == "--------"
                                                                  ? a.Species.Environment.Name
                                                                  : search.Environment)
                                                 && a.Species.Type.Name == (
                                                        search.Type == "--------"
                                                            ? a.Species.Type.Name
                                                            : search.Type)
                                           select a;

                    if (search.Discrimination != "--------")
                    {
                        switch (search.Discrimination)
                        {
                            case "Förälder":
                                var queryDiscriminationParent = from animal in queryEnvironment
                                                                from family in db.Families
                                                                where animal.AnimalId == family.AnimalFather.AnimalId
                                                                      || animal.AnimalId == family.AnimalMother.AnimalId
                                                                join animalFamily in db.Families
                                                                    on animal.AnimalId equals animalFamily.ChildId into animalChildFamily
                                                                from af in animalChildFamily.DefaultIfEmpty()
                                                                select new AnimalDetailed()
                                                                {
                                                                    AnimalId = animal.AnimalId,
                                                                    CountryOfOrigin = animal.Country.Name,
                                                                    Environment = animal.Species.Environment.Name,
                                                                    Father = af.AnimalFather.Name,
                                                                    Mother = af.AnimalMother.Name,
                                                                    Name = animal.Name,
                                                                    Sex = animal.Sex,
                                                                    Species = animal.Species.Name,
                                                                    Type = animal.Species.Type.Name,
                                                                    WeightInKilogram = animal.Weight,
                                                                };
                                list = new BindingList<AnimalDetailed>(queryDiscriminationParent.ToList());
                                break;
                            case "Moder":
                                var queryDiscriminationMother = from animal in queryEnvironment
                                                                from family in db.Families
                                                                where animal.AnimalId == family.AnimalMother.AnimalId
                                                                join animalFamily in db.Families
                                                                    on animal.AnimalId equals animalFamily.ChildId into animalChildFamily
                                                                from af in animalChildFamily.DefaultIfEmpty()
                                                                select new AnimalDetailed()
                                                                {
                                                                    AnimalId = animal.AnimalId,
                                                                    CountryOfOrigin = animal.Country.Name,
                                                                    Environment = animal.Species.Environment.Name,
                                                                    Father = af.AnimalFather.Name,
                                                                    Mother = af.AnimalMother.Name,
                                                                    Name = animal.Name,
                                                                    Sex = animal.Sex,
                                                                    Species = animal.Species.Name,
                                                                    Type = animal.Species.Type.Name,
                                                                    WeightInKilogram = animal.Weight,
                                                                };
                                list = new BindingList<AnimalDetailed>(queryDiscriminationMother.ToList());
                                break;
                            case "Fader":
                                var queryDiscriminationFather = from animal in queryEnvironment
                                                                from family in db.Families
                                                                where animal.AnimalId == family.AnimalFather.AnimalId
                                                                join animalFamily in db.Families
                                                                    on animal.AnimalId equals animalFamily.ChildId into animalChildFamily
                                                                from af in animalChildFamily.DefaultIfEmpty()
                                                                select new AnimalDetailed()
                                                                {
                                                                    AnimalId = animal.AnimalId,
                                                                    CountryOfOrigin = animal.Country.Name,
                                                                    Environment = animal.Species.Environment.Name,
                                                                    Father = af.AnimalFather.Name,
                                                                    Mother = af.AnimalMother.Name,
                                                                    Name = animal.Name,
                                                                    Sex = animal.Sex,
                                                                    Species = animal.Species.Name,
                                                                    Type = animal.Species.Type.Name,
                                                                    WeightInKilogram = animal.Weight,
                                                                };
                                list = new BindingList<AnimalDetailed>(queryDiscriminationFather.ToList());
                                break;
                            case "Barn":
                                var queryDiscriminationChild = from animal in queryEnvironment
                                    from family in db.Families
                                    where animal.AnimalId == family.AnimalChild.AnimalId
                                    join animalFamily in db.Families
                                        on animal.AnimalId equals animalFamily.ChildId into animalChildFamily
                                    from af in animalChildFamily.DefaultIfEmpty()
                                    select new AnimalDetailed()
                                    {
                                        AnimalId = animal.AnimalId,
                                        CountryOfOrigin = animal.Country.Name,
                                        Environment = animal.Species.Environment.Name,
                                        Father = af.AnimalFather.Name,
                                        Mother = af.AnimalMother.Name,
                                        Name = animal.Name,
                                        Sex = animal.Sex,
                                        Species = animal.Species.Name,
                                        Type = animal.Species.Type.Name,
                                        WeightInKilogram = animal.Weight,
                                    };
                                list = new BindingList<AnimalDetailed>(queryDiscriminationChild.ToList());
                                break;
                        }
                    }
                    else
                    {
                        var query = from animal in queryEnvironment
                                    join animalFamily in db.Families
                                    on animal.AnimalId equals animalFamily.ChildId into animalChildFamily
                                    from af in animalChildFamily.DefaultIfEmpty()
                                    select new AnimalDetailed()
                                    {
                                        AnimalId = animal.AnimalId,
                                        CountryOfOrigin = animal.Country.Name,
                                        Environment = animal.Species.Environment.Name,
                                        Father = af.AnimalFather.Name,
                                        Mother = af.AnimalMother.Name,
                                        Name = animal.Name,
                                        Sex = animal.Sex,
                                        Species = animal.Species.Name,
                                        Type = animal.Species.Type.Name,
                                        WeightInKilogram = animal.Weight,
                                    };

                        list = new BindingList<AnimalDetailed>(query.ToList());
                    }
                }
                else
                {
                    var query =
                        from animal in db.Animals
                        join family in db.Families
                            on animal.AnimalId equals family.ChildId into animalChildFamily
                        from af in animalChildFamily.DefaultIfEmpty()
                        select new AnimalDetailed()
                        {
                            AnimalId = animal.AnimalId,
                            CountryOfOrigin = animal.Country.Name,
                            Environment = animal.Species.Environment.Name,
                            Father = af.AnimalFather.Name,
                            Mother = af.AnimalMother.Name,
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
                var childQuery = from f in db.Families
                                 where f.AnimalChild.AnimalId == animalId
                                 select f;
                var motherQuery = from f in db.Families
                                  where f.AnimalMother.AnimalId == animalId
                                  select f;
                var fatherQuery = from f in db.Families
                                  where f.AnimalFather.AnimalId == animalId
                                  select f;
                Family childFamily = childQuery.FirstOrDefault();
                Family motherFamily = motherQuery.FirstOrDefault();
                Family fatherFamily = fatherQuery.FirstOrDefault();

                if (childFamily != null)
                {
                    db.Families.Remove(childFamily);
                }
                else
                {
                    if (motherFamily != null)
                    {
                        motherFamily.AnimalMother = null;
                    }
                    if (fatherFamily != null)
                    {
                        fatherFamily.AnimalFather = null;
                    }
                }

                db.Animals.Remove(animal);
                db.SaveChanges();
            }
        }
    }
}
