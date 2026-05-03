using System;
using System.Collections.Generic;
using System.Text;

using System;

public class LogicLevel
{
    private int _currentModIdx = 0;
    private int _currentLessIdx = 0;
    private int _currentLives;

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
    public void ProcessAnswer(string input)
    {
        // Pre-condition: Validasi input tidak boleh kosong atau hanya spasi
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input tidak valid!");
            return;
        }

        // Ambil data modul dan materi saat ini
        Module currentMod = RepoLevel.MasterTable[_currentModIdx];
        Lesson currentLess = currentMod.Lessons[_currentLessIdx];

        // Logika untuk memeriksa jawaban (Post-Condition)
        if (input.ToLower() == currentLess.Answer.ToLower())
        {
            Console.WriteLine("Sangat Bagus!");
            HandleSuccess();
        }
        else
        {
            HandleFailure();
        }
    }

    // Logika Perpindahan Level (Post-Condition)
    private void HandleSuccess()
    {
        // Logika Perpindahan Level (Post-Condition)
        if (_currentLessIdx < RepoLevel.MasterTable[_currentModIdx].Lessons.Count - 1)
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
            Console.WriteLine("TAMAT! Kamu hebat.");
            return;
        }
        DisplayStatus();
    }

    // Logika kalo gagalan (Post-Condition)
    private void HandleFailure()
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

    // Fungsi untuk menampilkan status saat ini
    public void DisplayStatus()
    {
        // Ambil data modul dan materi saat ini
        var mod = RepoLevel.MasterTable[_currentModIdx];
        var les = mod.Lessons[_currentLessIdx];
        Console.WriteLine($"[MODUL: {mod.ModuleName}] | [MATERI: {les.Title}]");
        Console.WriteLine($"Isi: {les.Content}");
        Console.WriteLine($"Tanya: {les.Question} (Nyawa: {_currentLives})");
    }
}
