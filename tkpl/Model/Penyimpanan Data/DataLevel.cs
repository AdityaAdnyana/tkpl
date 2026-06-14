using System;
using System.Collections.Generic;
using System.Text;
using tkpl.Model;


// Struktur Data untuk Level (Modul dan Lesson) menggunakan Composite Pattern
public interface ILevelComponent
{
    string GetTitle();
    int CalculateLives();
    void DisplayStructure(int depth);
}

public class Lesson : ILevelComponent
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

    public string GetTitle() => Title;

    // Leaf memberikan kontribusi dasar (misal: setiap 1 bab bernilai proporsional untuk nyawa)
    public int CalculateLives() => 1;

    public void DisplayStructure(int depth)
    {
        Console.WriteLine(new string('-', depth) + " Lesson: " + Title);
    }
}

// Composite yang bisa berisi Lesson atau bahkan Sub-Module di masa depan. Modul akan menghitung total nyawa berdasarkan komponen-komponen yang ada di dalamnya.
public class Module : ILevelComponent
{
    public string ModuleName { get; set; }
    public int MaxLives { get; private set; }

    private List<ILevelComponent> _components = new List<ILevelComponent>();

    public Module() { }

    public Module(string name)
    {
        ModuleName = name;
    }

    public string GetTitle() => ModuleName;

    // Memberikan akses read-only ke komponen-komponen di dalam modul untuk memastikan enkapsulasi tetap terjaga.
    public IReadOnlyList<ILevelComponent> ReadOnlyComponents => _components;

    // Fungsi Tambah Komponen (Lesson, bisa juga Sub-Module lain di masa depan)
    public void AddComponent(ILevelComponent component)
    {
        _components.Add(component);
        UpdateMaxLives();
    }

    // Fungsi Hapus Komponen
    public void RemoveComponent(ILevelComponent component)
    {
        _components.Remove(component);
        UpdateMaxLives();
    }

    // Menghitung total bobot nyawa berdasarkan komponen-komponen yang ada di dalam modul. Setiap komponen (Lesson) memberikan kontribusi tertentu terhadap jumlah nyawa total.
    public int CalculateLives()
    {
        int totalWeight = 0;
        foreach (var component in _components)
        {
            totalWeight += component.CalculateLives();
        }
        return totalWeight;
    }

    // Setiap 3 poin bobot total dari komponen, modul mendapatkan 1 nyawa. Pembulatan ke atas untuk memastikan modul tetap menantang.
    private void UpdateMaxLives()
    {
        MaxLives = (int)Math.Ceiling(CalculateLives() / 3.0);
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

