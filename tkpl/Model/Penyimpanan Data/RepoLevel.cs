using System;
using System.Collections.Generic;
using tkpl.Model;

public static class RepoLevel
{
    public static List<Module> MasterTable = new List<Module>
    {
        // MODUL 1: Mekanika Klasik (Modul Utama)
        new Module("Mekanika Klasik", new List<Lesson>
        {
            // Bab 1: Kinematika
            new Lesson("Kinematika", "Studi tentang gerak benda tanpa mempedulikan penyebabnya.")
            {
                Questions = new List<IQuestion>
                {
                    new EssayQuiz<string> { QuestionText = "Satuan internasional dari kecepatan?", ExpectedAnswer = "m/s" }
                }
            },
            // Bab 2: Hukum Newton I
            new Lesson("Hukum Newton I", "Benda cenderung mempertahankan keadaannya (Inersia).")
            {
                Questions = new List<IQuestion>
                {
                    new EssayQuiz<string> { QuestionText = "Sifat kecenderungan benda mempertahankan posisinya disebut?", ExpectedAnswer = "inersia" }
                }
            },
            // Bab 3: Hukum Newton II (Bab Terakhir Modul 1)
            new Lesson("Hukum Newton II", "Percepatan sebanding dengan gaya dan berbanding terbalik dengan massa (F=ma).")
            {
                Questions = new List<IQuestion>
                {
                    new ObjectiveQuiz<int> 
                    { 
                        QuestionText = "Gaya yang diperlukan untuk menggerakkan 1kg benda sebesar 1m/s² adalah ... Newton", 
                        ExpectedAnswer = 1, 
                        Options = new List<int> { 1, 2, 3, 4 } 
                    }
                }
            }
        }),

        // MODUL 2: Gelombang & Optik (Modul Tambahan)
        new Module("Gelombang & Optik", new List<Lesson>
        {
            new Lesson("Frekuensi", "Jumlah getaran yang terjadi dalam satu detik.")
            {
                Questions = new List<IQuestion>
                {
                    new EssayQuiz<string> { QuestionText = "Satuan internasional dari frekuensi?", ExpectedAnswer = "hertz" }
                }
            }
        })
    };
}