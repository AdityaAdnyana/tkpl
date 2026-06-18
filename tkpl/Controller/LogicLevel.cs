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
        public int CurrentLives { get; private set; }
        private static LogicLevel _instance;

        private readonly List<ILivesObserver> _observers = new();

        private LogicLevel()
        {
            CurrentLives = 3;
        }

        public static LogicLevel Instance()
        {
            if (_instance == null)
            {
                _instance = new LogicLevel();
            }
            return _instance;
        }

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
                observer.Update(CurrentLives);
            }
        }

        /// <summary>
        /// Mengurangi nyawa sebanyak 1 dan memberitahu semua observer.
        /// Enkapsulasi state change agar mutasi hanya terjadi lewat method ini.
        /// </summary>
        public void DecreaseLives()
        {
            CurrentLives--;
            NotifyObservers();
        }

        public void ResetLives(int totalQuestions)
        {
            CurrentLives = Math.Max(1, totalQuestions / 3);
            NotifyObservers();
        }
    }
}       