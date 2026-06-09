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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            AppConfig.LoadConfig();

            LogicLevel levelManager = new LogicLevel();

            Module currentMod = RepoLevel.MasterTable[levelManager._currentModIdx];
            Lesson activeLesson = currentMod.ReadOnlyLessons[levelManager._currentLessIdx];

            QuizView quizView = new QuizView();
            Homepage menuHomepage = new Homepage();

            QuizSessionController sessionController = new QuizSessionController(activeLesson, quizView, levelManager);

            sessionController.StartSession();

            Application.Run(menuHomepage);
        }
    }
}