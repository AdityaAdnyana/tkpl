using System.Diagnostics;

namespace tkpl.Model
{
<<<<<<< HEAD:tkpl/Model/Handling Question/ObjectiveQuiz.cs
    public class ObjectiveQuiz<T> : Question<T>, IObjectiveQuiz
=======
    public class ObjectiveQuiz<T> : Question<T>
>>>>>>> aditya-adnyana:tkpl/Model/ObjectiveQuiz.cs
    {
        public List<T> Options { get; set; } = new List<T>();

        public List<string> GetStringOptions()
        {
            List<string> strOptions = new List<string>();
            foreach (var opt in Options)
            {
                if (opt != null)
                {
                    strOptions.Add(opt.ToString());
                }
                else
                {
                    //Jika input opsi jawaban null, maaka soal tidak akan masuk ke dalam list
                    Debug.WriteLine("Warning: Input tidak boleh null.");
                }
            }
            return strOptions;
        }
    }
}
