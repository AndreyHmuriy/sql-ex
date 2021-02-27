using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ex.RecyclingFirmEntity
{
    class Outcome_o
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
            Column("out")]
        public double Out{ get; set; }

        public Outcome_o() { }

        public Outcome_o(byte point, DateTime date, double @out)
        {
            Point = point;
            Date = date;
            Out = @out;
        }
    }
}
