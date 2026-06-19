using System;
using System.Windows.Forms;
using tkpl.Controller;
using tkpl.Model;
using tkpl.Model.Reading_Material;
using tkpl.View;
using tkpl.View.Materi_Page;
using tkpl.View.User_Page;

namespace tkpl
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            AppConfig.LoadConfig();

<<<<<<< HEAD
            await RepoLevel.FetchLevelsFromApiAsync();
            await RepoUser.FetchUsersFromApiAsync();
            
            await RepoReadingMaterial.FetchMaterialsFromApiAsync();
            await RepoReadingMaterialImage.FetchImagesFromApiAsync();




            QuizView quizView = new QuizView();
            Homepage menuHomepage = new Homepage();
            LoginPage loginPage = new LoginPage();
            //MateriPage materiPage = new MateriPage(1); 
            Application.Run(loginPage);
=======
>>>>>>> aditya-adnyana
        }
    }
}