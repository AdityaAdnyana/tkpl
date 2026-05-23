// See https://aka.ms/new-console-template for more information
using ImplemantasiGenericQuiz;
using tkpl.Model;

public class Program
{
    public static void Main()
    {
        //TempLessonInit dummyLesson = new();
        StateMachine stateMachine = new StateMachine();
        int a = Convert.ToInt32(Console.ReadLine());
        stateMachine.TransitionState("quiz");
        int b = Convert.ToInt32(Console.ReadLine());
    }
}
    
