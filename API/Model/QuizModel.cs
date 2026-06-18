using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Model
{
    public class QuizModel
    {
        [Table("quiz")]
        public class QuizModels
        {
            [Key]
            public int Quiz_ID { get; set; }
            public int? Lesson_ID { get; set; }

            [Column("quiz_type")]
            public string? Quiz_Type { get; set; }

            [Column("score_weight")]
            public decimal? Score_Weight { get; set; }

            [Column("quiz_difficulty")]
            public int? Quiz_Difficulty { get; set; }

            [JsonIgnore]
            [ForeignKey("Lesson_ID")]
            public LessonModels? Lesson { get; set; }

            public List<EssayQuizModels> EssayQuizzes { get; set; } = new List<EssayQuizModels>();
            public List<ObjectiveQuizModels> ObjectiveQuizzes { get; set; } = new List<ObjectiveQuizModels>();
            public List<QuizImageModels> QuizImages { get; set; } = new List<QuizImageModels>();
        }

        [Table("essay_quiz")]
        public class EssayQuizModels
        {
            [Key]
            public int Essay_Quiz_ID { get; set; }
            public int? Quiz_ID { get; set; }

            [Column("quiz")]
            public string? Quiz_Text { get; set; }

            [Column("correct_answer")]
            public string? Correct_Answer { get; set; }

            [JsonIgnore]
            [ForeignKey("Quiz_ID")]
            public QuizModels? Quiz { get; set; }
        }

        [Table("objective_quiz")]
        public class ObjectiveQuizModels
        {
            [Key]
            public int Objective_Quiz_ID { get; set; }
            public int? Quiz_ID { get; set; }

            [Column("quiz")]
            public string? Quiz_Text { get; set; }

            [JsonIgnore]
            [ForeignKey("Quiz_ID")]
            public QuizModels? Quiz { get; set; }

            public List<ObjectiveQuizOptionsModels> Options { get; set; } = new List<ObjectiveQuizOptionsModels>();
        }

        [Table("objective_quiz_options")]
        public class ObjectiveQuizOptionsModels
        {
            [Key]
            public int Objective_Answer_ID { get; set; }
            public int? Objective_Quiz_ID { get; set; }

            [Column("answer")]
            public string? Answer_Text { get; set; }

            [Column("is_correct")]
            public sbyte? Is_Correct { get; set; }

            [JsonIgnore]
            [ForeignKey("Objective_Quiz_ID")]
            public ObjectiveQuizModels? ObjectiveQuiz { get; set; }
        }

        [Table("quiz_image")]
        public class QuizImageModels
        {
            [Key]
            public int Quiz_Image_ID { get; set; }

            public int? Quiz_ID { get; set; }

            [Column("image_url")]
            public string? Image_Url { get; set; }

            [JsonIgnore]
            [ForeignKey("Quiz_ID")]
            public QuizModels? Quiz { get; set; }
        }
    }
}
