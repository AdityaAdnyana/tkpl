using System;
using System.Collections.Generic;
using tkpl.Model;
using tkpl.Model.Observer;

namespace tkpl.Controller
{
    /// <summary>
    /// Concrete Publisher (Subject) dalam Observer Pattern.
    /// Mengelola daftar observer dan memberitahu mereka saat nyawa berubah.
    /// Ref: https://refactoring.guru/design-patterns/observer
    /// </summary>
    public class LogicLevel : ILivesSubject
    {
        public int _currentModIdx { get; private set; } = 0;
        public int _currentLessIdx { get; private set; } = 0;
        public int _currentLives { get; private set; }
        private static LogicLevel _instance;

        // Daftar observer yang terdaftar untuk menerima notifikasi perubahan nyawa
        private readonly List<ILivesObserver> _observers = new();

        private LogicLevel()
        {
            _currentLives = CalculateInitialLives();
        }

        public static LogicLevel Instance()
        {
            if (_instance == null)
            {
                _instance = new LogicLevel();
            }
            return _instance;
        }

        // =====================================================================
        // Observer Pattern — Subscription Management
        // =====================================================================

        /// <summary>
        /// Mendaftarkan observer baru ke daftar subscriber.
        /// </summary>
        public void Subscribe(ILivesObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        /// <summary>
        /// Menghapus observer dari daftar subscriber.
        /// </summary>
        public void Unsubscribe(ILivesObserver observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// Memberitahu semua observer yang terdaftar tentang perubahan nyawa.
        /// </summary>
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_currentLives);
            }
        }

        // =====================================================================
        // Business Logic
        // =====================================================================

        /// <summary>
        /// Mengurangi nyawa sebanyak 1 dan memberitahu semua observer.
        /// Enkapsulasi state change agar mutasi hanya terjadi lewat method ini.
        /// </summary>
        public void DecreaseLives()
        {
            _currentLives--;
            NotifyObservers();
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
            ForceAdvanceLevel();
        }
    }
}