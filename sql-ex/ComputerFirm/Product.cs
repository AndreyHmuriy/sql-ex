using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_ex.ComputerFirmEntity
{
    class Product
    {
        #region Столбцы
        [Required,
         MaxLength(10),
         Column("maker")]
        public string Maker { get; set; }

        [Key, 
         DatabaseGeneratedAttribute(DatabaseGeneratedOption.None),
         MaxLength(50),
         Column("model")]
        public string Model { get; set; }

        [Required,
         MaxLength(50),
         Column("type")]
        public string Type { get; set; }
        #endregion

        public virtual ICollection<Laptop> Laptop { get; set; }
        public virtual ICollection<PC> PC { get; set; }
        public virtual ICollection<Printer> Printer { get; set; }

        public Product(string maker,string model,string type):this()
        {
            Maker = maker;
            Model = model;
            Type = type;
        }

        public Product()
        {
            this.Laptop = new HashSet<Laptop>();
            this.PC = new HashSet<PC>();
            this.Printer = new HashSet<Printer>();
        }
    }
}