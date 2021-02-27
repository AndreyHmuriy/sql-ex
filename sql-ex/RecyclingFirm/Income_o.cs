using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql_ex.RecyclingFirmEntity
{
    class Income_o
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required,
            Column("point")]
        public byte Point { get; set; }

        [Required,
            Column("date")]
        public DateTime Date { get; set; }

        [Required,
            Column("inc")]
        public double Inc { get; set; }

        public Income_o() { }

        public Income_o(byte point, DateTime date, double inc)
        {
            Point = point;
            Date = date;
            Inc = inc;
        }
    }
}
