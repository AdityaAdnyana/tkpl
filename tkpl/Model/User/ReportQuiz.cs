using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using tkpl.Model;


    public static class ReportQuiz
    {
       public static BindingList<ReportQuizItem> QuizItems = new BindingList<ReportQuizItem>();

        
    }

public class ReportQuizItem
{
    public int id { get; set; }
    public string QuestionText { get; set; }

    public Lesson Lesson { get; set; }

    public bool IsCorrect { get; set; }

    public string CorrectAnswer { get; set; }

    public ReportQuizItem(int id, Lesson lesson, int questionIndex, bool isUserCorrect)
    {
        this.id = id;
        this.Lesson = lesson;
        this.IsCorrect = isUserCorrect;

        
        if (lesson.Questions != null && questionIndex >= 0 && questionIndex < lesson.Questions.Count)
        {
            // Ambil soal Lesson
            IQuestion targetQuestion = lesson.Questions[questionIndex];

            // Tarik data langsung dari soal yang ditemukan
            this.QuestionText = targetQuestion.QuestionText;
            this.CorrectAnswer = targetQuestion.GetExpectedAnswerAsString(); // Menggunakan Cara 3
        }
        else
        {
            // Fallback jika indeks di luar jangkauan
            this.QuestionText = "Soal tidak ditemukan";
            this.CorrectAnswer = "N/A";


        }
    }
}

