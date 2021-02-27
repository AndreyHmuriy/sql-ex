using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace sql_ex.RecyclingFirmEntity
{
    class RecyclingFirmContext : DbContext
    {
        List<Outcome> outcome = new List<Outcome>()
        {
            new Outcome(1,1,new DateTime(2001,3,14),15348.00),
            new Outcome(2,1,new DateTime(2001,3,24),3663.00),
            new Outcome(3,1,new DateTime(2001,3,26),1221.00),
            new Outcome(4,1,new DateTime(2001,3,28),2075.00),
            new Outcome(5,1,new DateTime(2001,3,29),2004.00),
            new Outcome(6,1,new DateTime(2001,4,11),3195.00),
            new Outcome(7,1,new DateTime(2001,4,13),4490.00),
            new Outcome(8,1,new DateTime(2001,4,27),3110.00),
            new Outcome(9,1,new DateTime(2001,5,11),2530.00),
            new Outcome(10,2,new DateTime(2001,3,22),1440.00),
            new Outcome(11,2,new DateTime(2001,3,29),7848.00),
            new Outcome(12,2,new DateTime(2001,4,2),2040.00),
            new Outcome(13,1,new DateTime(2001,3,24),3500.00),
            new Outcome(14,2,new DateTime(2001,3,22),1440.00),
            new Outcome(15,1,new DateTime(2001,3,29),2006.00),
            new Outcome(16,3,new DateTime(2001,9,13),1200.00),
            new Outcome(17,3,new DateTime(2001,9,13),1500.00),
            new Outcome(18,3,new DateTime(2001,9,14),1150.00)
        };

        List<Income> income = new List<Income>()
        {
            new Income(1,1,new DateTime(2001,3,22),15000.00),
            new Income(2,1,new DateTime(2001,3,23),15000.00),
            new Income(3,1,new DateTime(2001,3,24),3600.00),
            new Income(4,2,new DateTime(2001,3,22),10000.00),
            new Income(5,2,new DateTime(2001,3,24),1500.00),
            new Income(6,1,new DateTime(2001,4,13),5000.00),
            new Income(7,1,new DateTime(2001,5,11),4500.00),
            new Income(8,1,new DateTime(2001,3,22),15000.00),
            new Income(9,2,new DateTime(2001,3,24),1500.00),
            new Income(10,1,new DateTime(2001,4,13),5000.00),
            new Income(11,1,new DateTime(2001,3,24),3400.00),
            new Income(12,3,new DateTime(2001,9,13),1350.00),
            new Income(13,3,new DateTime(2001,9,13),1750.00)
        };

        List<Outcome_o> outcome_o = new List<Outcome_o>()
        {
            new Outcome_o(1,new DateTime(2001,3,14),15348.00),
            new Outcome_o(1,new DateTime(2001,3,24),3663.00),
            new Outcome_o(1,new DateTime(2001,3,26),1221.00),
            new Outcome_o(1,new DateTime(2001,3,28),2075.00),
            new Outcome_o(1,new DateTime(2001,3,29),2004.00),
            new Outcome_o(1,new DateTime(2001,4,11),3195.04),
            new Outcome_o(1,new DateTime(2001,4,13),4490.00),
            new Outcome_o(1,new DateTime(2001,4,27),3110.00),
            new Outcome_o(1,new DateTime(2001,5,11),2530.00),
            new Outcome_o(2,new DateTime(2001,3,22),1440.00),
            new Outcome_o(2,new DateTime(2001,3,29),7848.00),
            new Outcome_o(2,new DateTime(2001,4,2),2040.00),
            new Outcome_o(3,new DateTime(2001,9,13),1500.00),
            new Outcome_o(3,new DateTime(2001,9,14),2300.00),
            new Outcome_o(3,new DateTime(2002,9,16),2150.00)
        };

        List<Income_o> income_o = new List<Income_o>()
        {
            new Income_o(1, new DateTime(2001, 3, 22), 15000.00),
            new Income_o(1, new DateTime(2001, 3, 23), 15000.00),
            new Income_o(1, new DateTime(2001, 3, 24), 3400.00),
            new Income_o(1, new DateTime(2001, 4, 13), 5000.00),
            new Income_o(1, new DateTime(2001, 5, 11), 4500.00),
            new Income_o(2, new DateTime(2001, 3, 22), 10000.00),
            new Income_o(2, new DateTime(2001, 3, 24), 1500.00),
            new Income_o(3, new DateTime(2001, 9, 13), 11500.00),
            new Income_o(3, new DateTime(2001, 10, 2), 18000.00)
        };

        public RecyclingFirmContext()
        {
            
        }

        public void CreateDatabase()
        {
            Database.EnsureDeleted();
            bool isExists = Database.CanConnect();
            if (!(isExists))
            {
                Database.EnsureCreated();

                Income.AddRange(income);
                Outcome.AddRange(outcome);
                Income_o.AddRange(income_o);
                Outcome_o.AddRange(outcome_o);

                SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RecyclingFirm2;Trusted_Connection=True;");           
            optionsBuilder.UseSqlite(@"Data source=RecyclingFirm.db;");
        }

        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Income_o> Income_o { get; set; }
        public virtual DbSet<Outcome> Outcome { get; set; }
        public virtual DbSet<Outcome_o> Outcome_o { get; set; }
    }
}
