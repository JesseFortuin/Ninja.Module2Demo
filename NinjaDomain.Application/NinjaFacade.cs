using NinjaDomain.Classes;
using NinjaDomain.Classes.Enums;
using NinjaDomain.DataModel;
using System.Data.Entity;

namespace NinjaDomain.Application
{
    public class NinjaFacade : INinjaFacade
    {
        public void InsertNinja()
        {
            var ninja = new Ninja
            {
                Name = "JodySan",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1993, 04, 13),
                ClanId = 1,
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                context.Ninjas.Add(ninja);

                context.SaveChanges();
            }
        }

        public void InsertMultipleNinjas()
        {
            var ninja1 = new Ninja
            {
                Name = "Leonardo",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1984, 1, 1),
                ClanId = 1,
            };

            var ninja2 = new Ninja
            {
                Name = "Raphael",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1985, 1, 1),
                ClanId = 1,
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                context.Ninjas.AddRange(new List<Ninja> { ninja1, ninja2 });

                context.SaveChanges();
            }   
        }

        public void SimpleNinjaQueries()
        {
            //throw new NotImplementedException();

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = context.Ninjas.Where
                    (n => n.DateOfBirth >= new DateTime(1984, 1, 1))
                    .OrderBy(n => n.Name)
                    .Skip(1).Take(1)
                    .FirstOrDefault();

                //foreach (var ninja in ninjas)
                //{
                Console.WriteLine(ninja.Name);
                //}
            }
        }

        public void QueryAndUpdateNinja()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = context.Ninjas.FirstOrDefault();

                ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);

                context.SaveChanges();
            }
        }

        public void QueryAndUpdateNinjaDisconnected()
        {
            Ninja ninja;

            //retrieving data
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                ninja = context.Ninjas.FirstOrDefault();
            }

            //client changing data (if they were working on a website, api, or service)
            ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);

            //telling database this object has been modified
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                context.Ninjas.Attach(ninja);

                context.Entry(ninja).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void RetrieveDataWithFind()
        {
            var keyval = 4;

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                //find is helpful if you have key value of an object
                var ninja = context.Ninjas.Find(keyval);

                Console.WriteLine("After Find#1" + ninja.Name);

                var someNinja = context.Ninjas.Find(keyval);

                Console.WriteLine("After Find#2" + someNinja.Name);

                ninja = null;
            }
        }

        public void RetrieveDataWithStoredProc()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninjas = context.Ninjas.SqlQuery("exec GetOldNinjas");

                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
            }
        }

        public void RemoveNinja()
        {
            Ninja ninja;

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                ninja = context.Ninjas.FirstOrDefault();

                //context.Ninjas.Remove(ninja);

                //context.SaveChanges();
            }

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                //context.Ninjas.Attach(ninja);

                //context.Ninjas.Remove(ninja);

                context.Entry(ninja).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public void RemoveNinjaWithKeyValue()
        {
            var keyval = 1;

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = context.Ninjas.Find(keyval);

                context.Ninjas.Remove(ninja);

                context.SaveChanges();
            }
        }

        public void RemoveNinjaViaStoredProcedure()
        {
            var keyval = 3;

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                //not on specific dbset
                context.Database.ExecuteSqlCommand(
                    "exec DeleteNinjaViaId {0}", keyval);
            }
        }

        public void InsertNinjaWithEquipment()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = new Ninja
                {
                    Name = "Jason",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1994, 04, 08),
                    ClanId = 1,
                };

                var katana = new NinjaEquipment
                {
                    Name = "Shibimaru",
                    Type = EquipmentType.weapon,
                };

                var shoes = new NinjaEquipment
                {
                    Name = "Gucci Flipflops",
                    Type = EquipmentType.Tool,
                };

                context.Ninjas.Add(ninja);

                //context is aware of object, applies same state to following
                ninja.EquipmentOwned.Add(katana);

                ninja.EquipmentOwned.Add(shoes);

                context.SaveChanges();
            }
        }

        public void SimpleNinjaGraphQuery()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                //var ninja = context.Ninjas.Include(n => n.EquipmentOwned)
                //    .FirstOrDefault(n => n.Name.StartsWith("Jason"));

                var ninja = context.Ninjas.FirstOrDefault(n => n.Name.StartsWith("Ja"));

                Console.WriteLine("Ninja Retrieved: " + ninja.Name);

                //context.Entry(ninja).Collection(n => n.EquipmentOwned).Load();
                //Console.WriteLine
                //    ("Ninja Equipment Count: {0}", ninja.EquipmentOwned.Count());
            }
        }

        public void ProjectionQuery()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninjas = context.Ninjas
                    .Select(n => new { n.Name, n.DateOfBirth, n.EquipmentOwned })
                    .ToList();
            }
        }
    }
}