using tkpl;
using tkpl.Controller;
using tkpl.Model;

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

            TempLessonInit dummyLesson = new();
            StateMachine stateMachine = new StateMachine();
            int a = Convert.ToInt32(Console.ReadLine());
            Application.Run();
            //Application.Run(new QuizPilihanGanda());

        }
    }
}