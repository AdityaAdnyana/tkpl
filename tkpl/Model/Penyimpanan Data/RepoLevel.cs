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
                    var newModule = new Module(apiMod.Module_Name);

                    foreach (var apiLess in apiMod.Lessons)
                    {
                        var newLesson = new Lesson(apiLess.Lesson_Name, "Materi Pembelajaran Aktif");

                        newModule.AddComponent(newLesson);
                    }

                    MasterTable.Add(newModule);
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

    // Inisialisasi data fallback untuk memastikan aplikasi tetap memiliki data level meskipun API tidak tersedia
    private static void InitializeFallbackData()
    {
        if (MasterTable.Count == 0)
        {
            var fallbackModule = new Module("Mekanika Klasik (Offline Mode)");
            fallbackModule.AddComponent(new Lesson("Kinematika", "Studi tentang gerak benda tanpa mempedulikan penyebabnya."));
            MasterTable.Add(fallbackModule);
        }
    }
}

// Kelas-kelas ini merepresentasikan struktur data yang diterima dari API. Mereka digunakan untuk deserialisasi JSON dan kemudian diubah menjadi objek-objek level yang sesuai dalam MasterTable.
public class ModuleFromApi
{
    // ini contoh clean attribute
    public int Module_ID { get; set; }
    public string Module_Name { get; set; }
    public List<LessonFromApi> Lessons { get; set; } = new List<LessonFromApi>();
}

// Kelas ini merepresentasikan data pelajaran yang diterima dari API. Setiap pelajaran memiliki ID dan nama, yang kemudian akan digunakan untuk membuat objek Lesson dalam MasterTable.
public class LessonFromApi
{
    public int Lesson_ID { get; set; }
    public string Lesson_Name { get; set; }
}