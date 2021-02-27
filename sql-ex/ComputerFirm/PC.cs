using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ex.ComputerFirmEntity
{
    class PC
    {
        #region Столбцы
        [Key, 
            DatabaseGenerated(DatabaseGeneratedOption.None),
            Column("code")]
        public int Code { get; set; }

        [Required,
            MaxLength(50),
            Column("model")]
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

        [Required,
            MaxLength(10),
            Column("cd")]
        public string CD { get; set; }

        [Column("price")]
        public double? Price { get; set; }
        #endregion

        public PC() { }

        public PC(int code,string model, short speed, short ram, float hd, string cd, double? price)
        {
            Code = code;
            Model = model;
            Speed = speed;
            RAM= ram;
            HD= hd;
            CD= cd;
            Price= price;
        }

        [ForeignKey("Model")]
        public virtual Product Product { get; set; }
    }
}
