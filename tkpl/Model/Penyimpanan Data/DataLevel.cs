using System;
using System.Collections.Generic;
using System.Text;
using tkpl.Model;

public class Lesson
{
    public string Title { get; set; }
    public string Content { get; set; }
    public List<IQuestion> Questions { get; set; } = new List<IQuestion>();
    public Lesson() { }

    public Lesson(string title, string content)
    {
        Title = title;
        Content = content;
    }
}

public class Module
{
    public string ModuleName { get; set; }
    private List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public int MaxLives { get; set; }
    public Module() { }

    public Module(string name, List<Lesson> lessons)
    {
        ModuleName = name;
        Lessons = lessons;

        // Math.Ceiling() agar pembagian menghasilkan pembulatan ke atas
        // (misal jika ada 1 atau 2 lesson, user tetap mendapatkan minimal 1 nyawa, bukan 0 akibat pembulatan integer biasa)
        MaxLives = (int)Math.Ceiling(Lessons.Count / 3.0);
    }

    // Properti Read-Only untuk mengakses data lesson dari luar class
    public IReadOnlyList<Lesson> ReadOnlyLessons => Lessons;
}

