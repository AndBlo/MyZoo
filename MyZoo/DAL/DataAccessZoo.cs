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

            using (var db = new ZooDBContext())
            {
                if (search.SpeciesSearch != "")
                {
                    var query =
                        from animal in db.Animals
                        where animal.Species.Name.ToLower()
                            .Contains(search.SpeciesSearch.ToLower())
                        join parent in db.ParentCouples
                            on animal.ParentCouple.ParentCoupleId equals parent.ParentCoupleId into ap
                        from p in ap.DefaultIfEmpty()
                        select new AnimalDetailed()
                        {
                            AnimalId = animal.AnimalId,
                            CountryOfOrigin = animal.CountryOfOrigin.Name,
                            Environment = animal.Species.Environment.Name,
                            Father = animal.ParentCouple.Father.Animal.Name,
                            Mother = animal.ParentCouple.Mother.Animal.Name,
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
                        join parent in db.ParentCouples
                            on animal.ParentCouple.ParentCoupleId equals parent.ParentCoupleId into ap
                        from p in ap.DefaultIfEmpty()
                        select new AnimalDetailed()
                        {
                            AnimalId = animal.AnimalId,
                            CountryOfOrigin = animal.CountryOfOrigin.Name,
                            Environment = animal.Species.Environment.Name,
                            Father = animal.ParentCouple.Father.Animal.Name,
                            Mother = animal.ParentCouple.Mother.Animal.Name,
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
            using (var db = new ZooDBContext())
            {
                var animalQuery = from animal in db.Animals
                                  where animal.AnimalId == animalId
                                  select animal;

                var mother = animalQuery.Select(a => a.ParentCouple.Mother);

                var father = animalQuery.Select(f => f.ParentCouple.Father);

                var list = animalQuery;
                //list.Select(p => p.ParentCouple).Select(f => f.Father) = father

                if (db.Mothers.Any(a => a.Animal.AnimalId == animalId))
                {
                    var couple = db.ParentCouples.Find(db.Mothers.FirstOrDefault(m => m.Animal.AnimalId == animalId));
                    var mothr = db.Animals.Find(animalId);
                    db.Animals.Remove(db.Animals.Find(animalId));
                }
                if (db.Fathers.Any(a => a.Animal.AnimalId == animalId))
                {
                    var couple = db.ParentCouples.Find(db.Fathers.FirstOrDefault(m => m.Animal.AnimalId == animalId));
                    couple.Father = null;
                    db.Animals.Remove(db.Animals.Find(animalId));
                }
                else
                {
                    db.Animals.Remove(db.Animals.Find(animalId));
                }

                db.SaveChanges();
            }
        }
    }
}
