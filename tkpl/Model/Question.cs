using System.Diagnostics;
namespace tkpl.Model
{
    internal class Question<T> : IQuestion
    {

        public string QuestionText { get; set; } = string.Empty;
        public T ExpectedAnswer { get; set; } = default!; // initialized to satisfy nullable-analysis (CS8618)

        
        public List<string> GetStringOptions()
        {
            // Base class secara default mengembalikan list kosong.
            // Class turunan seperti ObjectiveQuiz akan melakukan override method ini.
            return new List<string>();
        }

        public string getAnswer()
        {
            return "" + ExpectedAnswer;
        }

        // Implementasi IQuestion.ValidateAnswer yang menerima parameter bertipe T.
        public bool ValidateAnswer(T answer)
        {
            return EqualityComparer<T>.Default.Equals(answer, ExpectedAnswer);
        }

        // Implementasi IQuestion.ValidateAnswer yang menerima parameter object.
        // Method konversi. Dieksekusi jika dipanggil dengan parameter bertipe object, misalnya dari UI yang menerima input sebagai string.
        public bool ValidateAnswer(object answer)
        {
            try
            {
                T convertedAnswer = (T)Convert.ChangeType(answer, typeof(T));

                if (convertedAnswer is T typedAnswer) return ValidateAnswer(typedAnswer);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Input tidak valid: " + ex);
            }
            return false;
        }
    }
}
