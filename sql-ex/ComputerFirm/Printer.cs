using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ex.ComputerFirmEntity
{
    class Printer
    {
        #region Столбцы
        [Key, 
            DatabaseGeneratedAttribute(DatabaseGeneratedOption.None),
            Column("code")]
        public int Code { get; set; }

        [Required,
            MaxLength(50),
            Column("model")]
        public string Model { get; set; }

        [Required,
            MaxLength(1),
            Column("color")]
        public char Color { get; set; }

        [Required,
            MaxLength(10),
            Column("type")]
        public string Type { get; set; }

        [Column("price")]
        public double? Price { get; set; }
        #endregion
        
        public Printer() { }
        public Printer(int code, string model, char color, string type, double? price)
        {
            Code = code;
            Model = model;
            Color = color;
            Type = type;
            Price = price;
        }

        [ForeignKey("Model")]
        public virtual Product Product { get; set; }
    }
}
