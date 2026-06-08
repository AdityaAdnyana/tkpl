using System;
using tkpl.Model;

namespace tkpl.Controller
{
    public class LogicLevel
    {
        public int _currentModIdx { get; private set; } = 0;
        public int _currentLessIdx { get; private set; } = 0;
        public int _currentLives { get; set; }

        public LogicLevel()
        {
            _currentLives = CalculateInitialLives();
        }

        private int CalculateInitialLives()
        {
            // Rumus adaptif menghitung nyawa awal berdasarkan total materi
            int totalLessons = RepoLevel.MasterTable[0].ReadOnlyLessons.Count;
            return (int)Math.Ceiling(totalLessons / 3.0);
        }

        public void ForceAdvanceLevel()
        {
            // Maju bab internal state
            if (_currentLessIdx < RepoLevel.MasterTable[_currentModIdx].ReadOnlyLessons.Count - 1)
            {
                _currentLessIdx++;
            }
            else
            {
                _currentModIdx++;
                _currentLessIdx = 0;
            }
        }

        public void ProcessAnswer(string input)
        {
            ForceAdvanceLevel(); // Fallback pemancing sukses
        }
    }
}