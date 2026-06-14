using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("users")]
    public class UserModels
    {
        [Key]
        public int User_ID { get; set; }

        public int? Current_Level_ID { get; set; }

        [Column("Report_Quiz")]
        public string? Report_Quiz { get; set; }

        [ForeignKey("Current_Level_ID")]
        public LevelModels? CurrentLevel { get; set; }
    }
}