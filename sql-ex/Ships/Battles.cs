using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ex.ShipsEntities
{
    class Battles
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.None),
            MaxLength(20),
            Column("name")]
        public string Name { get; set; }

        [Required,
            Column("date")]
        public DateTime Date { get; set; }
        
        public Battles()
        {
            this.Outcomes = new HashSet<Outcomes>();
        }

        public Battles(string name, DateTime date):this()
        {
            Name = name;
            Date = date;
        }

        public virtual ICollection<Outcomes> Outcomes { get; set; }
    }
}
