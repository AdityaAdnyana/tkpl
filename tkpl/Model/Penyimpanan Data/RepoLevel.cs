using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using tkpl.Model;

public static class RepoLevel
{
    public static List<Module> MasterTable = new List<Module>();

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
                    List<Lesson> tempLessons = new List<Lesson>();

                    foreach (var apiLess in apiMod.Lessons)
                    {
                        // Membuat objek Lesson berdasarkan data dari database SQL
                        var newLesson = new Lesson(apiLess.Lesson_Name, "Materi Pembelajaran Aktif");

                        tempLessons.Add(newLesson);
                    }

                    // Memasukkan modul hasil unduhan database ke dalam MasterTable utama
                    MasterTable.Add(new Module(apiMod.Module_Name, tempLessons));
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

    /// <summary>
    /// Mengisi data dummy lokal jika koneksi ke API gagal (Offline Mode).
    /// </summary>
    private static void InitializeFallbackData()
    {
        if (MasterTable.Count == 0)
        {
            MasterTable.Add(new Module("Mekanika Klasik (Offline Mode)", new List<Lesson>
            {
                new Lesson("Kinematika", "Studi tentang gerak benda tanpa mempedulikan penyebabnya.")
            }));
        }
    }
}

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
}