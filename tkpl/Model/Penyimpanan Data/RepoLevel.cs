using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using tkpl.Model;
using tkpl.Utils;

public static class RepoLevel
{
    public static List<Module> MasterTable { get; set; } = new List<Module>();
    public static Dictionary<int, int> LevelToModuleMap { get; set; } = new Dictionary<int, int>();

    private static readonly HttpClient _httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7021/")
    };

    // Mengambil data level dari API dan mengisi MasterTable. Jika gagal, gunakan data lokal sebagai fallback.
    public static async Task FetchLevelsFromApiAsync()
    {
        try
        {
            var modulesFromApi = await _httpClient.GetFromJsonAsync<List<ModuleFromApi>>("Level");

            if (modulesFromApi != null)
            {
                MasterTable.Clear();

                foreach (var apiMod in modulesFromApi)
                {
                    var newModule = new Module(apiMod.Module_ID, apiMod.Module_Name);

                    foreach (var apiLess in apiMod.Lessons)
                    {
                        var newLesson = new Lesson(apiLess.Lesson_Name ?? "Unknown Lesson", "Materi Pembelajaran Aktif");

                        if (apiLess.Quizzes != null)
                        {
                            foreach (var apiQuiz in apiLess.Quizzes)
                            {
                                int difficulty = apiQuiz.Quiz_Difficulty ?? 1;

                                // Ambil URL gambar pertama jika ada, lalu konversi jika itu link Google Drive
                                string rawImageUrl = apiQuiz.QuizImages?.FirstOrDefault()?.Image_Url ?? "";
                                string directImageUrl = rawImageUrl.ToDirectDriveLink();

                                if (apiQuiz.EssayQuizzes != null)
                                {
                                    foreach (var eq in apiQuiz.EssayQuizzes)
                                    {
                                        var essay = new EssayQuiz<string>
                                        {
                                            Difficulty = difficulty,
                                            QuestionText = eq.Quiz_Text ?? "",
                                            ExpectedAnswer = eq.Correct_Answer ?? "",
                                            ImagePath = directImageUrl
                                        };
                                        newLesson.Questions.Add(essay);
                                    }
                                }

                                if (apiQuiz.ObjectiveQuizzes != null)
                                {
                                    foreach (var oq in apiQuiz.ObjectiveQuizzes)
                                    {
                                        var objective = new ObjectiveQuiz<string>
                                        {
                                            Difficulty = difficulty,
                                            QuestionText = oq.Quiz_Text ?? "",
                                            ImagePath = directImageUrl
                                        };

                                        string expectedAns = "";
                                        if (oq.Options != null)
                                        {
                                            foreach (var opt in oq.Options)
                                            {
                                                objective.Options.Add(opt.Answer_Text ?? "");
                                                if (opt.Is_Correct == 1)
                                                {
                                                    expectedAns = opt.Answer_Text ?? "";
                                                }
                                            }
                                        }
                                        objective.ExpectedAnswer = expectedAns;

                                        newLesson.Questions.Add(objective);
                                    }
                                }
                            }
                        }

                        newModule.AddComponent(newLesson);
                    }

                    MasterTable.Add(newModule);
                }
            }

            var detailsFromApi = await _httpClient.GetFromJsonAsync<List<LevelModuleDetailFromApi>>("Level/LevelModuleDetail");
            if (detailsFromApi != null)
            {
                LevelToModuleMap.Clear();
                foreach (var detail in detailsFromApi)
                {
                    LevelToModuleMap[detail.LevelId] = detail.ModuleId;
                }
            }
        }
        catch (Exception ex)
        {
            // Jika server API mati, tampilkan log pesan error dan biarkan MasterTable kosong
            Console.WriteLine($"Gagal sinkronisasi ke server API: {ex.Message}");
        }
    }
}
public class LevelModuleDetailFromApi
{
    [System.Text.Json.Serialization.JsonPropertyName("detailId")]
    public int DetailId { get; set; }
    
    [System.Text.Json.Serialization.JsonPropertyName("moduleId")]
    public int ModuleId { get; set; }
    
    [System.Text.Json.Serialization.JsonPropertyName("levelId")]
    public int LevelId { get; set; }
}

// Kelas-kelas ini merepresentasikan struktur data yang diterima dari API. Mereka digunakan untuk deserialisasi JSON dan kemudian diubah menjadi objek-objek level yang sesuai dalam MasterTable.
public class ModuleFromApi
{
    public int Module_ID { get; set; }
    public string Module_Name { get; set; }
    public List<LessonFromApi> Lessons { get; set; } = new List<LessonFromApi>();
}

public class LessonFromApi
{
    public int Lesson_ID { get; set; }
    public string Lesson_Name { get; set; }
    public List<QuizFromApi> Quizzes { get; set; } = new List<QuizFromApi>();
}

public class QuizFromApi
{
    public int Quiz_ID { get; set; }
    public int? Quiz_Difficulty { get; set; }
    public List<EssayQuizFromApi> EssayQuizzes { get; set; } = new List<EssayQuizFromApi>();
    public List<ObjectiveQuizFromApi> ObjectiveQuizzes { get; set; } = new List<ObjectiveQuizFromApi>();
    public List<QuizImageFromApi> QuizImages { get; set; } = new List<QuizImageFromApi>();
}

public class QuizImageFromApi
{
    public string? Image_Url { get; set; }
}

public class EssayQuizFromApi
{
    public string? Quiz_Text { get; set; }
    public string? Correct_Answer { get; set; }
}

public class ObjectiveQuizFromApi
{
    public string? Quiz_Text { get; set; }
    public List<ObjectiveQuizOptionFromApi> Options { get; set; } = new List<ObjectiveQuizOptionFromApi>();
}

public class ObjectiveQuizOptionFromApi
{
    public string? Answer_Text { get; set; }
    public sbyte? Is_Correct { get; set; }
}