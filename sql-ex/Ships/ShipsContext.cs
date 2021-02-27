using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace sql_ex.ShipsEntities
{
    class ShipsContext:DbContext
    {
        #region Данные
        private List<Classes> classesList = new List<Classes>()
        {
            new Classes("Bismarck","bb","Germany",8,15,42000),
            new Classes("Iowa","bb","USA",9,16,46000),
            new Classes("Kongo","bc","Japan",8,14,32000),
            new Classes("North Carolina","bb","USA",12,16,37000),
            new Classes("Renown","bc","Gt.Britain",6,15,32000),
            new Classes("Revenge","bb","Gt.Britain",8,15,29000),
            new Classes("Tennessee","bb","USA",12,14,32000),
            new Classes("Yamato","bb","Japan",9,18,65000)
        };

        private List<Battles> battlesList = new List<Battles>()
        {
            new Battles("#Cuba62a",new DateTime(1962,10,20)),
            new Battles("#Cuba62b", new DateTime(1962,10,25)),
            new Battles("Guadalcanal", new DateTime(1942,11,15)),
            new Battles("North Atlantic", new DateTime(1942,05,25)),
            new Battles("North Cape", new DateTime(1943,12,26)),
            new Battles("Surigao Strait", new DateTime(1944,10,25))
        };

        private List<Outcomes> outcomesList = new List<Outcomes>()
        {
            new Outcomes("Bismarck","North Atlantic","sunk"),
            new Outcomes("California","Guadalcanal","damaged"),
            new Outcomes("CAlifornia","Surigao Strait","ok"),
            new Outcomes("Duke of York","North Cape","ok"),
            new Outcomes("Fuso","Surigao Strait","sunk"),
            new Outcomes("Hood","North Atlantic","sunk"),
            new Outcomes("King George V","North Atlantic","ok"),
            new Outcomes("Kirishima","Guadalcanal","sunk"),
            new Outcomes("Prince of Wales","North Atlantic","damaged"),
            new Outcomes("Rodney","North Atlantic","OK"),
            new Outcomes("Schamhorst","North Cape","sunk"),
            new Outcomes("South Dakota","Guadalcanal","damaged"),
            new Outcomes("Tennessee","Surigao Strait","ok"),
            new Outcomes("Washington","Guadalcanal","ok"),
            new Outcomes("West Virginia","Surigao Strait","ok"),
            new Outcomes("Yamashiro","Surigao Strait","sunk")
        };

        private List<Ships> shipsList = new List<Ships>()
        {
            new Ships("California","Tennessee",1921),
            new Ships("Haruna","Kongo",1916),
            new Ships("Heil","Kongo",1914),
            new Ships("Iowa","Iowa",1943),
            new Ships("Kirishima","Kongo",1915),
            new Ships("Kongo","Kongo",1913),
            new Ships("Missouri","Iowa",1944),
            new Ships("Musashi","Yamato",1942),
            new Ships("New Jersey","Iowa",1943),
            new Ships("North Carolina","North Carolina",1941),
            new Ships("Ramillies","Revenge",1917),
            new Ships("Renown","Renown",1916),
            new Ships("Repulse","Renown",1916),
            new Ships("Resolution","Renown",1916),
            new Ships("Revenge","Revenge",1916),
            new Ships("Royal Oak","Revenge",1916),
            new Ships("Royal Sovereign","Revenge",1916),
            new Ships("South Dakota","North Carolina",1941),
            new Ships("Tennessee","Tennessee",1920),
            new Ships("Washington","North Carolina",1941),
            new Ships("Wisconsin","Iowa",1944),
            new Ships("Yamato","Yamato",1941)
        };
        #endregion
        public ShipsContext()
        {

        }

        public void CreateDatabase()
        {
            Database.EnsureDeleted();
            bool isExists = Database.CanConnect();
            if (!(isExists))
            {
                Database.EnsureCreated();

                Classes.AddRange(classesList);
                Battles.AddRange(battlesList);
                Outcomes.AddRange(outcomesList);
                Ships.AddRange(shipsList);

                SaveChanges();

                classesList.Clear();
                battlesList.Clear();
                outcomesList.Clear();
                shipsList.Clear();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Outcomes>(e =>
            //{
            //    e.HasNoKey();
            //});

            //modelBuilder.Entity<Battles>(e =>
            //{
            //    e.HasMany(c => c.Outcomes).WithOne(c => c.Battles);
            //});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Shipsssss;Trusted_Connection=True;");
           optionsBuilder.UseSqlite(@"Data Source=Ships.db");
        }

        public virtual DbSet<Ships> Ships { get; set; }
        public virtual DbSet<Battles> Battles { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Outcomes> Outcomes { get; set; }
    }
}
