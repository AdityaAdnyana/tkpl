using System;

namespace tkpl.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// Mengonversi tautan berbagi (share link) Google Drive menjadi tautan unduhan langsung (direct link).
        /// </summary>
        /// <param name="url">Tautan asli dari Google Drive.</param>
        /// <returns>Tautan langsung jika format dikenali; jika tidak, mengembalikan tautan asli.</returns>
        public static string ToDirectDriveLink(this string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return string.Empty;

            try
            {
                string fileId = ExtractGoogleDriveFileId(url);
                
                if (!string.IsNullOrEmpty(fileId))
                {
                    return $"https://drive.google.com/uc?export=view&id={fileId}";
                }
            }
            catch
            {
                // Fallback: Mengembalikan URL asli apabila terjadi anomali format teks yang tidak terduga
            }

            return url;
        }

        /// <summary>
        /// Mengekstrak ID file secara spesifik dari berbagai variasi tautan Google Drive.
        /// </summary>
        private static string ExtractGoogleDriveFileId(string url)
        {
            // Menangani format: https://drive.google.com/file/d/{ID_FILE}/view
            if (url.Contains("/d/"))
            {
                string[] urlSegments = url.Split("/d/");
                if (urlSegments.Length > 1)
                {
                    string remainingPath = urlSegments[1];
                    string extractedId = remainingPath.Split('/')[0];
                    
                    return extractedId;
                }
            }
            
            // Menangani format: https://drive.google.com/open?id={ID_FILE}
            if (url.Contains("id="))
            {
                string[] querySegments = url.Split("id=");
                if (querySegments.Length > 1)
                {
                    string remainingQuery = querySegments[1];
                    string extractedId = remainingQuery.Split('&')[0];
                    
                    return extractedId;
                }
            }

            return string.Empty;
        }
    }
}
