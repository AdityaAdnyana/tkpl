using tkpl.Controller;

namespace tkpl
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            ApplicationConfiguration.Initialize();
            LogicLevel levelManager = new LogicLevel();

            Module currentMod = RepoLevel.MasterTable[levelManager._currentModIdx];
            Lesson activeLesson = currentMod.ReadOnlyLessons[levelManager._currentLessIdx];

            QuizView quizView = new QuizView();
            QuizSessionController sessionController = new QuizSessionController(activeLesson, quizView, levelManager);

            sessionController.StartSession();
            Application.Run();
            //Application.Run(new QuizPilihanGanda());

        }
    }
}