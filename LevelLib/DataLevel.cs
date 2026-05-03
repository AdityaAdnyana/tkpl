using System;
using System.Collections.Generic;
using System.Text;

public class Lesson
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public Lesson() { }

    public Lesson(string title, string content, string question, string answer)
    {
        Title = title;
        Content = content;
        Question = question;
        Answer = answer;
    }
}

public class Module
{
    public string ModuleName { get; set; }
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public int MaxLives { get; set; }
    public Module() { }

    public Module(string name, List<Lesson> lessons, int lives)
    {
        ModuleName = name;
        Lessons = lessons;
        MaxLives = lives;
    }
}