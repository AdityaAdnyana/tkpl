using System.IO;
using System.Text.Json;
using System.Diagnostics;
using tkpl.Model;

namespace tkpl.Controller
{
    public static class AppConfig
    {
        // Menyimpan instance konfigurasi yang aktif
        public static UIConfig UI { get; private set; } = new UIConfig();

        public static void LoadConfig(string filePath = "Config/uiconfig.json")
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    UIConfig deserializedUI = JsonSerializer.Deserialize<UIConfig>(jsonString);
                    if (deserializedUI != null)
                    {
                        UI = deserializedUI;
                    }
                    Debug.WriteLine("Konfigurasi UI berhasil dimuat.");
                }
                else
                {
                    Debug.WriteLine("File uiconfig.json tidak ditemukan. Menggunakan nilai default.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Gagal memuat konfigurasi: {ex.Message}");
            }
        }
    }
}