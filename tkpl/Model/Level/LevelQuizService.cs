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
            if (!RepoLevel.LevelToModuleMap.TryGetValue(level, out int targetModuleId))
            {
                throw new ArgumentException($"Mapping modul untuk level {level} tidak ditemukan dalam database.");
            }

            Module targetModule = RepoLevel.MasterTable.FirstOrDefault(m => m.ModuleId == targetModuleId);

            if (targetModule == null)
            {
                throw new ArgumentException($"Modul dengan ID {targetModuleId} untuk level {level} tidak ditemukan dalam MasterTable.");
            }
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
