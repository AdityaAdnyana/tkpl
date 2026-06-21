using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using tkpl.Model;


public static class ReportQuiz
{
    // Cache lokal berisi item-item report yang akan dikirim ke API
    public static List<ReportQuizItem> QuizItems = new List<ReportQuizItem>();

    private static readonly HttpClient _httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7021/")
    };

    public static async Task<bool> SaveReportsToApiAsync()
    {
        try
        {
            if (QuizItems.Count == 0) return true;

            // Buat list DTO yang sesuai format API/database
            // Quiz_ID tidak disertakan karena tidak tersedia di level quiz session
            var dataToSend = new List<ReportQuizRequest>();
            foreach (var item in QuizItems)
            {
                dataToSend.Add(new ReportQuizRequest
                {
                    User_ID = item.UserId,
                    Lesson_Title = item.LessonTitle,
                    Question_Text = item.QuestionText,
                    Correct_Answer = item.CorrectAnswer,
                    User_Answer = item.UserAnswer,
                    Score_Weight = item.ScoreWeight,
                    Is_Correct = item.IsCorrect.ToString()
                });
            }

            // Kirim batch ke API
            var response = await _httpClient.PostAsJsonAsync("ReportQuiz/batch", dataToSend);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                string errorBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API menolak report: {response.StatusCode} — {errorBody}");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Gagal menyimpan report ke database: {ex.Message}");
            return false;
        }
    }
}

/// <summary>
/// Merepresentasikan satu item laporan jawaban kuis yang disimpan secara lokal
/// dan akan dikirim ke database melalui API.
/// </summary>
public class ReportQuizItem
{
    // Data untuk tampilan di DataGridView (UserPage)
    public string LessonTitle { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public string CorrectAnswer { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;
    public decimal ScoreWeight { get; set; }
    public AnswerStatus IsCorrect { get; set; }
    // Data yang akan disimpan ke database
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public int LevelId { get; set; }

    public ReportQuizItem() { }

    
    public ReportQuizItem(int userId,AnswerStatus status, string lessonTitle, string correctAnswer, string answer, string questionText,decimal scoreWeight)
    {
        UserId = userId;
        IsCorrect = status;
        LessonTitle = lessonTitle;
        CorrectAnswer = correctAnswer;
        UserAnswer = answer;
        QuestionText = questionText;
        ScoreWeight = scoreWeight;
    }
}

/// <summary>
/// DTO untuk mengirim data report ke API endpoint POST /ReportQuiz/batch.
/// Strukturnya cocok dengan tabel report_quiz di database.
/// Quiz_ID tidak disertakan karena client tidak memiliki akses ke Quiz_ID secara langsung;
/// kolom tersebut nullable di database sehingga aman untuk dibiarkan null.
/// </summary>
public class ReportQuizRequest
{
    public int User_ID { get; set; }
    public string? Lesson_Title { get; set; }
    public string? Question_Text { get; set; }
    public string? Correct_Answer { get; set; }
    public string? User_Answer { get; set; }
    public decimal? Score_Weight { get; set; }
    public string? Is_Correct { get; set; }
}
