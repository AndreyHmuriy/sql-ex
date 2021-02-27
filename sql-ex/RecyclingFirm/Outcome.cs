using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ex.RecyclingFirmEntity
{
    class Outcome
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.None),
            Column("Code")]
        public int Code { get; set; }

        [Required,
            Column("point")]
        public byte Point { get; set; }

        [Required,
            Column("date")]
        public DateTime Date { get; set; }

        [Required,
            Column("out")]
        public double Out { get; set; }

        public Outcome()
        {

        }

        public Outcome(int code, byte point, DateTime date, double @out)
        {
            Code = code;
            Point = point;
            Date = date;
            Out = @out;
        }
    }
}
