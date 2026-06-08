using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Controller
{
    public class LogicLevel
    {
        public int _currentModIdx { get; set; } = 0;
        public int _currentLessIdx { get; set; } = 0;
        public int _currentLives { get; set; }

        // Konstruktor untuk inisialisasi level pertama dan nyawa awal
        public LogicLevel()
        {
            if (RepoLevel.MasterTable.Count > 0)
            {
                ResetLives(); // Code reuse untuk reset nyawa saat memulai game
            }
        }

        // Ini buat reset nyawa saat pindah modul baru (level) atau saat memulai game
        private void ResetLives()
        {
            _currentLives = RepoLevel.MasterTable[_currentModIdx].MaxLives;
        }

        // --- DESIGN BY CONTRACT: PRE-CONDITION ---
        // Fungsi untuk memproses jawaban user
        public string ProcessAnswer(string input) // Ganti void jadi string
        {
            // Pre-condition: Validasi input tidak boleh kosong atau hanya spasi
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Input tidak valid!"; // Gunakan return
            }

            // Ambil data modul dan materi saat ini
            Module currentMod = RepoLevel.MasterTable[_currentModIdx];
            Lesson currentLess = currentMod.ReadOnlyLessons[_currentLessIdx];

            // Logika untuk memeriksa jawaban (Post-Condition)
            if (currentLess.Questions != null && currentLess.Questions.Count > 0)
            {
                // Ambil soal pertama (indeks 0) dari bab ini sebagai sampel kuis teks
                var currentQuestion = currentLess.Questions[0];

                // Gunakan fungsi ValidateAnswer bawaan interface IQuestion (Post-Condition)
                if (currentQuestion.ValidateAnswer(input))
                {
                    HandleSuccess();
                    return "Benar!";
                }
                else
                {
                    HandleFailure();
                    return "Salah!";
                }
            }

            return "Tidak ada soal di materi ini!";
        }

        // Logika Perpindahan Level (Post-Condition)
        public void HandleSuccess()
        {
            // Logika Perpindahan Level (Post-Condition)
            if (_currentLessIdx < RepoLevel.MasterTable[_currentModIdx].ReadOnlyLessons.Count - 1)
            {
                _currentLessIdx++;
            }
            else if (_currentModIdx < RepoLevel.MasterTable.Count - 1)
            {
                _currentModIdx++;
                _currentLessIdx = 0;
                ResetLives(); // Code reuse untuk reset nyawa saat pindah modul baru
            }
            else
            {
                _currentModIdx++;
                return;
            }
        }

        // Logika kalo gagalan (Post-Condition)
        public void HandleFailure()
        {
            _currentLives--;
            Console.WriteLine($"Salah! Nyawa sisa: {_currentLives}");

            if (_currentLives <= 0)
            {
                Console.WriteLine("NYAWA HABIS! Kembali ke modul sebelumnya.");
                DecreaseLevel();
            }
        }

        // Logika untuk menurunkan level (Post-Condition)
        private void DecreaseLevel()
        {
            // Design by Contract: Mencegah index negatif
            if (_currentModIdx > 0)
            {
                _currentModIdx--;
            }
            _currentLessIdx = 0;
            ResetLives(); // Code reuse untuk reset nyawa saat kembali ke modul sebelumnya
            DisplayStatus();
        }

        // Tambahkan ini di dalam class LogicLevel (file LogicLevel.cs)
        public void ForceAdvanceLevel()
        {
            HandleSuccess();
        }

        // Fungsi untuk menampilkan status saat ini
        public void DisplayStatus()
        {
            // Ambil data modul dan materi saat ini
            var mod = RepoLevel.MasterTable[_currentModIdx];
            var les = mod.ReadOnlyLessons[_currentLessIdx];
            Console.WriteLine($"[MODUL: {mod.ModuleName}] | [MATERI: {les.Title}]");
            Console.WriteLine($"Isi: {les.Content}");
            Console.WriteLine($"Tanya: {les.Questions} (Nyawa: {_currentLives})");
        }
    }
}
