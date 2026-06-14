using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text;
using tkpl.Model;


    public static class ReportQuiz
    {
       public static BindingList<ReportQuizItem> QuizItems = new BindingList<ReportQuizItem>();

    private static readonly HttpClient _httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7021/")
    };

    // Mengambil data level dari API dan mengisi MasterTable. Jika gagal, gunakan data lokal sebagai fallback.
    private static void InitializeFallbackData()
    {
        if (QuizItems.Count == 0)
        {
            var fallbackModule = new ReportQuizItem(1, new Lesson("",""), 0, false);
            QuizItems.Add(fallbackModule);
        }
    }

    public static async Task FetchLevelsFromApiAsync()
    {
        try
        {
            var reportQuizItemsFromApi = await _httpClient.GetFromJsonAsync<List<ReportQuizItemFromAPI>>("Level");

            if (reportQuizItemsFromApi != null)
            {
                QuizItems.Clear();

                foreach (var apiRep in reportQuizItemsFromApi)
                {
                    var newReportItem = new ReportQuizItem(apiRep.id, apiRep.Lesson, apiRep.QuestionIndex, apiRep.IsCorrect);
                    QuizItems.Add(newReportItem);
                }
            }
        }
        catch (Exception ex)
        {
            // Fallback (Opsi Cadangan): Jika server API mati, gunakan data lokal agar aplikasi tidak crash
            Console.WriteLine($"Gagal sinkronisasi ke server API: {ex.Message}");
            InitializeFallbackData();
        }
    }
}

public class ReportQuizItem
{
    public int id { get; set; }
    public string QuestionText { get; set; }

    public Lesson Lesson { get; set; }

    public int QuestionIndex { get; set; }

    public bool IsCorrect { get; set; }

    public string CorrectAnswer { get; set; }



    public ReportQuizItem() { }

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
            this.CorrectAnswer = targetQuestion.GetExpectedAnswerAsString(); 
        }
        else
        {
            // Fallback jika indeks di luar jangkauan
            this.QuestionText = "Soal tidak ditemukan";
            this.CorrectAnswer = "N/A";


        }
    }
}

public class ReportQuizItemFromAPI
{
    public int id { get; set; }
    public string QuestionText { get; set; }
    public Lesson Lesson { get; set; }

    public int QuestionIndex { get; set; }
    public bool IsCorrect { get; set; }
    public string CorrectAnswer { get; set; }
}

