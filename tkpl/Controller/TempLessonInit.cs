using tkpl.Model;
namespace tkpl.Controller
{
    internal class TempLessonInit
    {
        public TempLessonInit() { 
            Lesson currentLesson = new();

            // Contoh Soal Essay
            EssayQuiz question1 = new EssayQuiz 
            { 
                QuestionText = "Siapakah penemu bola lampu?", 
                ExpectedAnswer = "Thomas Alva Edison"
            };

            // Contoh Soal Pilihan Ganda
            ObjectiveQuiz<String> question2 = new ObjectiveQuiz<String>
            {
                QuestionText = "Orang pertama yang mencapai bulan?",
                ExpectedAnswer = "Neil Armstrong",
                Options = new List<string> { "Neil Armstrong", "Leonardo Davinci", "Einstein", "Cipto" }
            };

            // Contoh Soal Pilihan Ganda dengan tipe data integer
            ObjectiveQuiz<int> question3 = new ObjectiveQuiz<int>
            {
                QuestionText = "Berapakah hasil dari 2 + 2?",
                ExpectedAnswer = 4,
                Options = new List<int> { 1, 2, 3, 4 }
            };

            EssayQuiz question4 = new EssayQuiz
            {
                QuestionText = "Berapakah hasil dari 1 + 2?",
                ExpectedAnswer = "3"
            };

            currentLesson.questions.Add(question1);
            currentLesson.questions.Add(question2);
            currentLesson.questions.Add(question3);
            currentLesson.questions.Add(question4);

            QuizView quizView = new QuizView();
            QuizSessionController sessionController = new QuizSessionController(currentLesson, quizView);
            sessionController.StartSession();
        }
    }
}