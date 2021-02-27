using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ex.ShipsEntities
{
    class Classes
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.None),
            MaxLength(50),
            Column("class")]
        public string Class { get; set; }

        [Required,
            MaxLength(2),
            Column("type")]
        public string Type { get; set; }

        [Required,
            MaxLength(20),
            Column("country")]
        public string Country { get; set; }

        [Column("numGuns")]
        public byte? NumGuns { get; set; }

        [Column("bore")]
        public float? Bore { get; set; }

        [Column("displacement")]
        public int? Displacement { get; set; }

        public Classes()
        {
            this.Ships = new HashSet<Ships>();
        }

        public Classes(string @class, string type, string country, byte? numGuns, float? bore, int? displacement):this()
        {
            Class = @class;
            Type = type;
            Country = country;
            NumGuns = numGuns;
            Bore = bore;
            Displacement = displacement;
        }
        
        public virtual ICollection<Ships> Ships { get; set; }
    }
}
