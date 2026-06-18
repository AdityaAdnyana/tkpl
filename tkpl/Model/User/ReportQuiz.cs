using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


public static class ReportQuiz
{
    // Cache lokal berisi item-item report yang akan dikirim ke API
    public static BindingList<ReportQuizItem> QuizItems = new BindingList<ReportQuizItem>();

    private static readonly HttpClient _httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7021/")
    };

    /// <summary>
    /// Mengirim semua item report yang ada di QuizItems ke API secara batch.
    /// Data yang dikirim disesuaikan dengan skema tabel report_quiz di database:
    /// User_ID, Quiz_ID, Level_ID, User_Answer.
    /// </summary>
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
                    Level_ID = item.LevelId,
                    User_Answer = item.UserAnswer
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
    public int No { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public string CorrectAnswer { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }

    // Data yang akan disimpan ke database
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public int LevelId { get; set; }

    public ReportQuizItem() { }

    /// <summary>
    /// Constructor lengkap untuk membuat ReportQuizItem.
    /// </summary>
    /// <param name="no">Nomor urut soal untuk tampilan</param>
    /// <param name="questionText">Teks soal</param>
    /// <param name="correctAnswer">Jawaban yang benar</param>
    /// <param name="userAnswer">Jawaban yang diberikan user</param>
    /// <param name="isCorrect">Apakah jawaban user benar</param>
    /// <param name="userId">ID user yang mengerjakan</param>
    /// <param name="quizId">ID quiz di database</param>
    /// <param name="levelId">ID level yang sedang dikerjakan</param>
    public ReportQuizItem(int no, string questionText, string correctAnswer, string userAnswer,
        bool isCorrect, int userId, int quizId, int levelId)
    {
        No = no;
        QuestionText = questionText;
        CorrectAnswer = correctAnswer;
        UserAnswer = userAnswer;
        IsCorrect = isCorrect;
        UserId = userId;
        QuizId = quizId;
        LevelId = levelId;
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
    public int Level_ID { get; set; }
    public string User_Answer { get; set; } = string.Empty;
}
