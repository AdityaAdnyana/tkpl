using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using tkpl.Model;

namespace tkpl.Model.Reading_Material
{
    public static class RepoReadingMaterialImage
    {
        public static int idStart = 5;

        // Simulasi tabel lokal / Cache
        public static List<MateriImageTable> MateriImageTable = new List<MateriImageTable>();

        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7021/")
        };

        // Data cadangan jika API mati 
        private static void InitializeFallbackData()
        {
            if (MateriImageTable.Count == 0)
            {
                MateriImageTable.Add(new MateriImageTable { Reading_Material_Image_ID = 1, Reading_Material_ID = 1, image_url = "https://drive.google.com/file/d/16oY2anv3BjicYLI1xQ4fQOCRI2u4pkIp/view?usp=drive_link" });
                MateriImageTable.Add(new MateriImageTable { Reading_Material_Image_ID = 2, Reading_Material_ID = 2, image_url = "https://drive.google.com/file/d/1qVsAw8d9J1i_hQnFjgi6ZxEs4JXTPFKx/view?usp=drive_link" });
                MateriImageTable.Add(new MateriImageTable { Reading_Material_Image_ID = 3, Reading_Material_ID = 3, image_url = "https://drive.google.com/file/d/1SoRhHscgasQPsN_6WL_zGarC6TN5ywpn/view?usp=drive_link" });
                MateriImageTable.Add(new MateriImageTable { Reading_Material_Image_ID = 4, Reading_Material_ID = 4, image_url = "https://drive.google.com/file/d/1DdgrW53NMsLzT8N1XZe3KoeOTpb_ALn2/view?usp=drive_link" });
            }
        }


        public static async Task FetchImagesFromApiAsync()
        {
            try
            {
                
                var imagesFromAPI = await _httpClient.GetFromJsonAsync<List<ImageFromAPI>>("reading_material_image");

                if (imagesFromAPI != null)
                {
                    MateriImageTable.Clear();

                    foreach (var apiImage in imagesFromAPI)
                    {
                        var newImage = new MateriImageTable
                        {
                            Reading_Material_Image_ID = apiImage.Reading_Material_Image_ID,
                            Reading_Material_ID = apiImage.Reading_Material_ID,
                            image_url = apiImage.image_url
                        };
                        MateriImageTable.Add(newImage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gagal sinkronisasi ke server API (ReadingMaterialImage): {ex.Message}");
                InitializeFallbackData();
            }
        }

        // DTO (Data Transfer Object) untuk menerima JSON dari API
        public class ImageFromAPI
        {
            public int Reading_Material_Image_ID { get; set; }
            public int Reading_Material_ID { get; set; }
            public string image_url { get; set; }
        }
    }
}
