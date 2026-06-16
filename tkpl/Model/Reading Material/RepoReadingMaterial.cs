using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using tkpl.Model;

namespace tkpl.Model.Reading_Material
{
    public static class RepoReadingMaterial
    {
        // ID selanjutnya setelah 4 data dummy
        public static int idStart = 5;

        // Simulasi tabel lokal 
        public static List<ReadingMaterial> MaterialTable = new List<ReadingMaterial>();

        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7021/")
        };

        // Data cadangan jika API mati (diambil dari SQL Anda)
        private static void InitializeFallbackData()
        {
            if (MaterialTable.Count == 0)
            {
                MaterialTable.Add(new ReadingMaterial { Reading_Material_ID = 1, Module_ID = 1, title = "Simbol Vektor", string_material = "Besaran vektor adalah besaran yang memiliki nilai sekaligus arah..." });
                MaterialTable.Add(new ReadingMaterial { Reading_Material_ID = 2, Module_ID = 1, title = "Penjumlahan Vektor", string_material = "Berbeda dengan penjumlahan besaran skalar yang tinggal dijumlahkan angkanya..." });
                MaterialTable.Add(new ReadingMaterial { Reading_Material_ID = 3, Module_ID = 1, title = "Mengurai Vektor", string_material = "Sebaliknya dari menjumlahkan, sebuah vektor tunggal juga bisa dipecah..." });
                MaterialTable.Add(new ReadingMaterial { Reading_Material_ID = 4, Module_ID = 1, title = "Menjumlahkan Vektor dengan Metode Urai Vektor", string_material = "Metode analitis rumus cosinus memiliki kelemahan..." });
            }
        }

        public static async Task FetchMaterialsFromApiAsync()
        {
            try
            {
                // blms selesai
                var materialsFromAPI = await _httpClient.GetFromJsonAsync<List<ReadingMaterialFromAPI>>("ReadingMaterialFromAPI");

                if (materialsFromAPI != null)
                {
                    MaterialTable.Clear();

                    foreach (var apiMaterial in materialsFromAPI)
                    {
                        var newMaterial = new ReadingMaterial
                        {
                            Reading_Material_ID = apiMaterial.Reading_Material_ID,
                            Module_ID = apiMaterial.Module_ID,
                            title = apiMaterial.title,
                            string_material = apiMaterial.string_material
                        };
                        MaterialTable.Add(newMaterial);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal sinkronisasi ke server API (ReadingMaterial): {ex.Message}");
                InitializeFallbackData();
            }
        }

        // DTO (Data Transfer Object) untuk menerima JSON dari API
        public class ReadingMaterialFromAPI
        {
            public int Reading_Material_ID { get; set; }
            public int Module_ID { get; set; } 
            public string title { get; set; }
            public string string_material { get; set; }
        }
    }
}
