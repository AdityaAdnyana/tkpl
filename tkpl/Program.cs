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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            ApplicationConfiguration.Initialize();

            LogicLevel levelManager = LogicLevel.Instance();
            AppConfig.LoadConfig();

            await RepoLevel.FetchLevelsFromApiAsync();

            Module currentMod = RepoLevel.MasterTable[levelManager._currentModIdx];
            Lesson activeLesson = currentMod.ReadOnlyComponents[levelManager._currentLessIdx] as Lesson;
            if (activeLesson == null) throw new InvalidOperationException("Selected component is not a Lesson.");

            QuizView quizView = new QuizView();
            Homepage menuHomepage = new Homepage();

            //QuizView quizView = new QuizView();

            QuizSessionController sessionController = new QuizSessionController(activeLesson, quizView, levelManager);

            Application.Run(menuHomepage);
        }
    }
}