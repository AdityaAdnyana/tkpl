using System;
using System.Collections.Generic;
using System.Text;

public static class RepoLevel
{
    public static List<Module> MasterTable = new List<Module> {
        new Module("Dasar C#", new List<Lesson> {
            new Lesson("Variabel", "Tempat simpan data.", "Keyword variabel tetap?", "const"),
            new Lesson("Data Type", "Int untuk angka.", "Tipe data angka bulat?", "int")
        }, 3),
        new Module("OOP Dasar", new List<Lesson> {
            new Lesson("Class", "Blueprint objek.", "Keyword buat objek?", "new")
        }, 3)
    };
}
