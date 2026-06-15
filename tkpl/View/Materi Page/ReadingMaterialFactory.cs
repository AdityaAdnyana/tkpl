using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using tkpl.Model.Reading_Material;
using tkpl.Utils;

namespace tkpl.View.Materi_Page
{
    public static class ReadingMaterialFactory
    {
        public static ReadingMaterialDisplay CreateDisplayMaterial(int materialId)
        {
            var display = new ReadingMaterialDisplay();

            
            var materialData = RepoReadingMaterial.MaterialTable.FirstOrDefault(m => m.Reading_Material_ID == materialId);

            if (materialData != null)
            {
                display.Title = materialData.title;
                display.Content = materialData.string_material;
            }
            else
            {
                display.Title = "Materi Tidak Ditemukan";
                display.Content = "Maaf, materi dengan ID ini tidak ada di database.";
                return display;
            }

           
            var imageData = RepoReadingMaterialImage.MateriImageTable.FirstOrDefault(i => i.Reading_Material_ID == materialId);

            if (imageData != null && !string.IsNullOrEmpty(imageData.image_url))
            {
                display.CoverImage = GetImageFromDrive(imageData.image_url);
            }

            return display;
        }

        private static Image GetImageFromDrive(string driveUrl)
        {
            try
            {
               
                // Ini otomatis mengekstrak ID sekaligus menjadikannya direct link URL.
                string directUrl = driveUrl.ToDirectDriveLink();

              
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(directUrl);
                    using (MemoryStream mem = new MemoryStream(data))
                    {
                        return Image.FromStream(mem);
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
