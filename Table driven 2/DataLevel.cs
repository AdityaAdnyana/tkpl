using System;
using System.Collections.Generic;
using System.Text;

// Pakai struct untuk menyimpan data yang lebih sederhana dan immutable,
// karena kita hanya perlu menyimpan informasi tentang pelajaran dan modul tanpa perilaku kompleks.
public struct Lesson
{
    public string Title;
    public string Content;
    public string Question;
    public string Answer;

    public Lesson(string title, string content, string question, string answer)
    {
        // Hasil Rombakan dari Bagian Quiz dan Penambahan Quiz
        Title = title;
        Content = content;
        Question = question;
        Answer = answer;
    }
}

// Pakai struct untuk menyimpan data modul yang terdiri dari beberapa pelajaran dan jumlah nyawa maksimal,
// karena kita hanya perlu menyimpan informasi tentang modul tanpa perilaku kompleks. ya biar simple lah
public struct Module
{
    public string ModuleName;
    public Lesson[] Lessons;
    public int MaxLives;

    public Module(string name, Lesson[] lessons, int lives)
    {
        ModuleName = name;
        Lessons = lessons;
        MaxLives = lives;
    }
}