using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("level")]
    public class LevelModels
    {
        [Key]
        public int Level_ID { get; set; }

        [Column("level_name")]
        public string level_name { get; set; }
    }
}