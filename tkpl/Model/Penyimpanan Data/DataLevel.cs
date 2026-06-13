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
        RecalculateLives();
    }

    public IReadOnlyList<Lesson> ReadOnlyLessons => Lessons;

    // Fungsi Tambah Lesson
    public void AddNewLesson(Lesson newLesson)
    {
        Lessons.Add(newLesson);
        RecalculateLives();
    }

    // Fungsi Update Lesson
    public bool UpdateExistingLesson(int index, Lesson updatedLesson)
    {
        if (index < 0 || index >= Lessons.Count) return false;

        Lessons[index] = updatedLesson;
        return true;
    }

    // Fungsi Delete Lesson
    public string DeleteExistingLesson(int index)
    {
        if (index < 0 || index >= Lessons.Count) return null;

        var deletedTitle = Lessons[index].Title;
        Lessons.RemoveAt(index);
        RecalculateLives();
        return deletedTitle;
    }

    // Helper privat untuk hitung ulang nyawa agar tidak DRY
    private void RecalculateLives()
    {
        MaxLives = (int)Math.Ceiling(Lessons.Count / 3.0);
    }
}

