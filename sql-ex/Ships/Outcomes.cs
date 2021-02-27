using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sql_ex.ShipsEntities
{
    class Outcomes
    {
        //ввел дополнительное поле ID из-за наличие в базе на сайте дубликатов в Ship( что являлся первоочередным первичным ключом)
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50),
            Column("ship")]
        public string Ship { get; set; }

        [Required,
            MaxLength(20),
            Column("battle")]
        public string Battle { get; set; }

        [Required,
            MaxLength(10),
            Column("result")]
        public string Result { get; set; }

        public Outcomes() { }

        public Outcomes(string ship, string battle, string result)
        {
            Ship = ship;
            Battle = battle;
            Result = result;
        }

        [ForeignKey("Battle")]
        public virtual Battles Battles { get; set; }
    }
}
