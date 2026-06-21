using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static API.Model.QuizModel;

namespace API.Model
{
    [Table("report_quiz")]
    public class ReportQuizModels
    {
        [Key]
        public int Report_Quiz_ID { get; set; }

        public int? User_ID { get; set; }
        public int? Quiz_ID { get; set; }
        public int? Level_ID { get; set; }
        [Column("lesson_title")]
        public string? Lesson_Title { get; set; }

        [Column("question_text")]
        public string? Question_Text { get; set; }

        [Column("correct_answer")]
        public string? Correct_Answer { get; set; }

        [Column("user_answer")]
        public string? User_Answer { get; set; }

        [Column("score_weight")]
        public decimal? Score_Weight { get; set; }

        [Column("is_correct")]
        public string? Is_Correct { get; set; }

        [ForeignKey("User_ID")]
        public UserModels? User { get; set; }

        [ForeignKey("Quiz_ID")]
        public QuizModels? Quiz { get; set; }

        [ForeignKey("Level_ID")]
        public LevelModels? Level { get; set; }
    }
}