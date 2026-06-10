using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Model
{
    [Table("module")]
    public class ModuleModels
    {
        [Key]
        public int Module_ID { get; set; }

        [Column("module_name")]
        public string module_name { get; set; }
        public List<LessonModels> Lessons { get; set; } = new List<LessonModels>();
    }

    [Table("lesson")]
    public class LessonModels
    {
        [Key]
        public int Lesson_ID { get; set; }
        public int Module_ID { get; set; }

        [Column("lesson_name")]
        public string lesson_name { get; set; }

        [ForeignKey("Module_ID")]
        public ModuleModels Module { get; set; }
    }
}
