using System;
using System.Collections.Generic;
using System.Text;
using tkpl.Model;


// Struktur Data untuk Level (Modul dan Lesson) menggunakan Composite Pattern
public interface ILevelComponent
{
    string GetTitle();
    void DisplayStructure(int depth);
}

public class Lesson : ILevelComponent
{
    public string Title { get; set; }
    public string Content { get; set; }
    public List<IQuestion> Questions { get; set; } = new List<IQuestion>();

    public Lesson(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public string GetTitle() => Title;

    public void DisplayStructure(int depth)
    {
        Console.WriteLine(new string('-', depth) + " Lesson: " + Title);
    }
}

// Composite yang bisa berisi Lesson atau bahkan Sub-Module di masa depan.
// Modul akan menghitung total nyawa berdasarkan komponen-komponen yang ada di dalamnya.
public class Module : ILevelComponent
{
    public int ModuleId { get; set; }
    public string ModuleName { get; set; }

    private List<ILevelComponent> _components = new List<ILevelComponent>();

    public Module(int moduleId, string moduleName)
    {
        ModuleId = moduleId;
        ModuleName = moduleName;
    }

    public string GetTitle() => ModuleName;

    // Memberikan akses read-only ke komponen-komponen di dalam modul untuk memastikan enkapsulasi tetap terjaga.
    public IReadOnlyList<ILevelComponent> ReadOnlyComponents => _components;

    // Fungsi Tambah Komponen (Lesson, bisa juga Sub-Module lain di masa depan)
    public void AddComponent(ILevelComponent component)
    {
        _components.Add(component);
    }

    public void DisplayStructure(int depth)
    {
        Console.WriteLine(new string('=', depth) + " Module: " + ModuleName);
        foreach (var component in _components)
        {
            component.DisplayStructure(depth + 2);
        }
    }
}

