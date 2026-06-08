<<<<<<< HEAD
using System;
using System.Windows.Forms;
=======
using ImplemantasiGenericQuiz;
using tkpl;
>>>>>>> 4c32809ec46ab2b446569c15c969ae2f9f2371c8
using tkpl.Controller;
using tkpl.Model;

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

<<<<<<< HEAD
            Module currentMod = RepoLevel.MasterTable[levelManager._currentModIdx];
            Lesson activeLesson = currentMod.ReadOnlyLessons[levelManager._currentLessIdx];
=======
            TempLessonInit dummyLesson = new();
            StateMachine stateMachine = new StateMachine();
            int a = Convert.ToInt32(Console.ReadLine());
            Application.Run();
            //Application.Run(new QuizPilihanGanda());
>>>>>>> 4c32809ec46ab2b446569c15c969ae2f9f2371c8

            QuizView quizView = new QuizView();

            QuizSessionController sessionController = new QuizSessionController(activeLesson, quizView, levelManager);

            sessionController.StartSession();

            Application.Run(quizView);
        }
    }
}