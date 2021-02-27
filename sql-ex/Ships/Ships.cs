using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ex.ShipsEntities
{
    class Ships
    {
        [Key,
            MaxLength(50),
            Column("name")]
        public string Name { get; set; }

        [Required,
            MaxLength(50),
            Column("class")]
        public string Class { get; set; }
        
        [Column("launched")]
        public short? Launched { get; set; }

        public Ships() { }

        public Ships(string name, string @class, short? launched)
        {
            Name = name;
            Class = @class;
            Launched = launched;
        }

        [ForeignKey("Class")]
        public virtual Classes Classes { get; set; }
    }
}
