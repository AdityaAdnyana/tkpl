using System;
using System.Collections.Generic;
using System.Text;

public static class RepoLevel
{
    // Pakai array untuk menyimpan data modul dan pelajaran,
    // karena jumlahnya tetap dan kita tidak perlu operasi dinamis seperti penambahan atau penghapusan.
    public static readonly Module[] MasterTable = {
        new Module("Dasar C#", new Lesson[] {
            new Lesson("Variabel", "Tempat simpan data.", "Keyword variabel tetap?", "const"),
            new Lesson("Data Type", "Int untuk angka.", "Tipe data angka bulat?", "int")
        }, 3),

        new Module("OOP Dasar", new Lesson[] {
            new Lesson("Class", "Blueprint objek.", "Keyword buat objek?", "new")
        }, 5)
    };
}
