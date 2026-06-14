using System;
using System.Collections.Generic;
using System.Linq;
using tkpl.Model;

namespace tkpl.Model.Level
{
    public class LevelQuizService
    {
        public const int DIFFICULTY_EASY = 1;
        public const int DIFFICULTY_MEDIUM = 2;
        public const int DIFFICULTY_HARD = 3;

        /// <summary>
        /// Menghasilkan kuis berdasarkan level sesuai dengan komposisi yang ditentukan.
        /// </summary>
        /// <param name="level">Level kuis (1, 2, 3, dst)</param>
        /// <returns>Daftar pertanyaan yang telah disaring dan dipilih</returns>
        public List<IQuestion> GenerateQuizForLevel(int level)
        {
            // Menentukan Modul: Level 1 & 2 -> Modul 0, Level 3 & 4 -> Modul 1
            // Karena level dimulai dari 1, (level - 1) / 2 akan menghasilkan indeks yang benar
            int moduleIndex = (level - 1) / 2;

            if (moduleIndex < 0 || moduleIndex >= RepoLevel.MasterTable.Count)
            {
                throw new ArgumentException($"Modul untuk level {level} tidak ditemukan (Index {moduleIndex} di luar batas MasterTable).");
            }

            Module targetModule = RepoLevel.MasterTable[moduleIndex];
            List<IQuestion> allQuestions = GetAllQuestionsFromModule(targetModule);

            int countEasy = (level % 2 != 0) ? 5 : 3;
            int countMedium = (level % 2 != 0) ? 3 : 5;
            int countHard = 2;

            return BuildQuizComposition(allQuestions, countEasy, countMedium, countHard);
        }

        private List<IQuestion> GetAllQuestionsFromModule(Module module)
        {
            List<IQuestion> questions = new List<IQuestion>();
            foreach (var component in module.ReadOnlyComponents)
            {
                if (component is Lesson lesson)
                {
                    if (lesson.Questions != null)
                    {
                        questions.AddRange(lesson.Questions);
                    }
                }
            }
            return questions;
        }

        private List<IQuestion> BuildQuizComposition(List<IQuestion> allQuestions, int countEasy, int countMedium, int countHard)
        {
            var easyQuestions = allQuestions.Where(q => q.Difficulty == DIFFICULTY_EASY).ToList();
            var mediumQuestions = allQuestions.Where(q => q.Difficulty == DIFFICULTY_MEDIUM).ToList();
            var hardQuestions = allQuestions.Where(q => q.Difficulty == DIFFICULTY_HARD).ToList();

            Random rng = new Random();
            List<IQuestion> selectedQuiz = new List<IQuestion>();

            selectedQuiz.AddRange(GetRandomQuestions(easyQuestions, countEasy, rng));
            selectedQuiz.AddRange(GetRandomQuestions(mediumQuestions, countMedium, rng));
            selectedQuiz.AddRange(GetRandomQuestions(hardQuestions, countHard, rng));

            // Acak urutan pertanyaan agar tidak selalu berurutan mudah -> medium -> sulit
            return selectedQuiz.OrderBy(x => rng.Next()).ToList();
        }

        private IEnumerable<IQuestion> GetRandomQuestions(List<IQuestion> questions, int count, Random rng)
        {
            // Mengambil secara acak sebanyak 'count' (atau jika kurang, ambil semuanya yang tersedia)
            return questions.OrderBy(x => rng.Next()).Take(count);
        }
    }
}
