using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using tkpl.Model.User;
using System.Collections.Generic;
using System.Net.Http.Json;
using tkpl.Model;
using System.Net.Http.Json;
using System.Threading.Tasks;

public static class RepoUser
{
    public static int idStart = 3;
    public static List<User> UserTable = new List<User>
    {
        new User { id = 1, userName = "admin", password = "admin123" },
        new User { id = 2, userName = "user1", password = "password1" },
        new User { id = 3, userName = "user2", password = "password2" }
    };

    private static readonly HttpClient _httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7021/")
    };

    // Mengambil data level dari API dan mengisi MasterTable. Jika gagal, gunakan data lokal sebagai fallback.
    private static void InitializeFallbackData()
    {
        if (UserTable.Count == 0)
        {
            var fallbackModule = new User("Kana","25N");
            UserTable.Add(fallbackModule);
        }
    }
    public static async Task FetchUsersFromApiAsync()
    {
        try
        {
            var userFromAPIs = await _httpClient.GetFromJsonAsync<List<UserFromAPI>>("Admin");

            if (userFromAPIs != null)
            {
                UserTable.Clear();

                foreach (var apiUser in userFromAPIs)
                {
                    var newModule = new User(apiUser.User_Name, apiUser.password);
                    UserTable.Add(newModule);
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

    public static async Task<bool> RegisterUserAsync(string username, string password)
    {
        try
        {

            var newModule = new User(username, password);

            UserTable.Add(newModule);

            return true;

           
            // return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Gagal mengirim data pendaftaran: {ex.Message}");
            return false;
        }
    }

    public class UserFromAPI
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string password { get; set; }

    }
}


