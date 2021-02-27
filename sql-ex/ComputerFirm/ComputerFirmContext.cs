using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sql_ex.ComputerFirmEntity
{
    class ComputerFirmContext : DbContext
    {
        #region Данные
        List<Product> products = new List<Product>()
        {
            new Product("B","1121","PC"),
            new Product("A","1232","PC"),
            new Product("A","1233","PC"),
            new Product("E","1260","PC"),
            new Product("A","1276","Printer"),
            new Product("D","1288","Printer"),
            new Product("A","1298","Laptop"),
            new Product("C","1321","Laptop"),
            new Product("A","1401","Printer"),
            new Product("A","1408","Printer"),
            new Product("D","1433","Printer"),
            new Product("E","1434","Printer"),
            new Product("B","1750","Laptop"),
            new Product("A","1752","Laptop"),
            new Product("E","2112","PC"),
            new Product("E","2113","PC")
        };

        List<PC> pcs = new List<PC>()
        {
            new PC(1,"1232",500,64,5,"12x", 600 ),
            new PC(2,"1121",750,128,14,"40x", 850 ),
            new PC(3,"1233",500,64,5,"12x", 600 ),
            new PC(4,"1121",600,128,14,"40x", 850 ),
            new PC(5,"1121",600,128,8,"40x", 850 ),
            new PC(6,"1233",750,128,20,"50x", 950 ),
            new PC(7,"1232",500,32,10,"12x", 400 ),
            new PC(8,"1232",450,64,8,"24x", 350 ),
            new PC(9,"1232",450,32,10,"24x", 350 ),
            new PC(10,"1260",500,32,10,"12x", 350 ),
            new PC(11,"1233",900,128,40,"40x", 980 ),
            new PC(12,"1233",800,128,20,"50x", 970 )
        };

        List<Laptop> laptops = new List<Laptop>()
        {
            new Laptop(1,"1298",350,32,4,700,11),
            new Laptop(2,"1321",500,64,8,970,12),
            new Laptop(3,"1750",750,128,12,1200,14),
            new Laptop(4,"1298",600,64,10,1050,15),
            new Laptop(5,"1752",750,128,10,1150,14),
            new Laptop(6,"1298",450,64,10,950,12),
        };

        List<Printer> printers = new List<Printer>()
        {
            new Printer(1,"1276",'n',"Laser",400),
            new Printer(2,"1433",'y',"Jet",270),
            new Printer(3,"1434",'y',"Jet",290),
            new Printer(4,"1401",'n',"Matrix",150),
            new Printer(5,"1408",'n',"Matrix",270),
            new Printer(6,"1288",'n',"Laser",400),
        };
        #endregion

        public void CreateDatabase()
        {
            Database.EnsureDeleted();
            bool isExists =  Database.CanConnect();
            if (!(isExists))
            {
                Database.EnsureCreated();
                InsertProduct();
            }
        }

        //public async Task<bool> CreateDatabase()
        //{
        //    bool isExists = await Database.CanConnectAsync();
        //    if (!(isExists))
        //    {                
        //        await Database.EnsureCreatedAsync();
        //        InsertProduct();
        //        return false;
        //    }
        //    return true;
        //}

        public ComputerFirmContext()
        {
            //if (!Database.CanConnect())
            //{
            //    Database.EnsureCreated();
            //    Product.AddRange(products);
            //    SaveChanges();
            //}
        }

        private void InsertProduct()
        {
            Product.AddRange(products);
            PC.AddRange(pcs);
            Laptop.AddRange(laptops);
            Printer.AddRange(printers);
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ComputerFirm2;Trusted_Connection=True;");           
           optionsBuilder.UseSqlite(@"Data source=ComputerFirm.db;");
        }

        public virtual DbSet<Laptop> Laptop { get; set; }
        public virtual DbSet<PC> PC { get; set; }
        public virtual DbSet<Printer> Printer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
    }
}
