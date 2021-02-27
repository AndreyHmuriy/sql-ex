using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ex.RecyclingFirmEntity
{
    class Income
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.None),
            Column("code")]
        public int Code { get; set; }

        [Column("point")
            ,Required]
        public byte Point { get; set; }

        [Column("date")
            ,Required]
        public DateTime Date { get; set; }

        [Column("inc"),
            Required]
        public double Inc { get; set; }

        public Income() { }

        public Income(int code, byte point, DateTime date, double inc)
        {
            Code = code;
            Point = point;
            Date = date;
            Inc = inc;
        }
    }
}
