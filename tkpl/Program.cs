using System;
using System.Windows.Forms;
using tkpl.Controller;
using tkpl.Model;
using tkpl.View;

namespace tkpl
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            AppConfig.LoadConfig();

            await RepoLevel.FetchLevelsFromApiAsync();

            QuizView quizView = new QuizView();
            Homepage menuHomepage = new Homepage();
            Application.Run(menuHomepage);
        }
    }
}