using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static API.Model.QuizModel;
using static API.Model.ReadingMaterial;

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
        public List<ReadingMaterialModels> ReadingMaterials { get; set; } = new List<ReadingMaterialModels>();
    }

    [Table("lesson")]
    public class LessonModels
    {
        [Key]
        public int Lesson_ID { get; set; }

        public int Module_ID { get; set; }

        [Column("lesson_name")]
        public string Lesson_Name { get; set; }

        [JsonIgnore]
        [ForeignKey("Module_ID")]
        public ModuleModels? Module { get; set; }

        public List<QuizModels> Quizzes { get; set; } = new List<QuizModels>();
    }
}
