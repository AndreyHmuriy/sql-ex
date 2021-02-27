using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ex.ComputerFirmEntity
{
    class Laptop
    {
        #region Столбцы
        [Key, 
            DatabaseGenerated(DatabaseGeneratedOption.None),
            Column("code")]
        public int Code { get; set; }        
        
        [Required,
            Column("model"),
            MaxLength(50)]
        public string Model { get; set; }

        [Required,
            Column("speed")]
        public short Speed { get; set; }

        [Required,
            Column("ram")]
        public short RAM { get; set; }

        [Required,
            Column("hd")]
        public float HD { get; set; }

        [Column("price")]
        public double? Price { get; set; }

        [Required,
            Column("screen")]
        public byte Screen { get; set; }
        #endregion

        public Laptop() { }

        public Laptop(int code, string model, short speed, short ram, float hd, double? price, byte screen)
        {
            Code = code;
            Model = model;
            Speed = speed;
            RAM = ram;
            HD = hd;
            Price = price;
            Screen = screen;
        }

        [ForeignKey("Model")]
        public virtual Product Product { get; set; }
    }
}
