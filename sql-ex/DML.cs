using sql_ex.ComputerFirmEntity;
using System;

namespace sql_ex
{
    class DML_ComputerFirm
    {
        public bool AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException();
            using (var context = new ComputerFirmContext())
            {
                context.Product.Add(product);
                return (context.SaveChanges() != 0);
            }
        }

        public bool AddPrinter(Printer printer)
        {
            if (printer == null) throw new ArgumentNullException();
            using (var context = new ComputerFirmContext())
            {
                context.Printer.Add(printer);
                return (context.SaveChanges() != 0);
            }
        }

        public bool AddPC(PC pc)
        {
            if (pc == null) throw new ArgumentNullException();
            using (var context = new ComputerFirmContext())
            {
                context.PC.Add(pc);
                return (context.SaveChanges() != 0);
            }
        }

        public bool AddLaptop(Laptop laptop)
        {
            if (laptop == null) throw new ArgumentNullException();
            using (var context = new ComputerFirmContext())
            {
                context.Laptop.Add(laptop);
                return (context.SaveChanges() != 0);
            }
         }
    }
}
