using System;
using System.Collections.Generic;
using tkpl.Model;

public static class RepoLevel
{
    public static List<Module> MasterTable = new List<Module>
    {
        // MODUL 1: Mekanika Klasik
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
            new Lesson("Hukum Dummy I", "Benda cenderung mempertahankan senyumannya.")
            {
                Questions = new List<IQuestion>
                {
                    new EssayQuiz<string> { QuestionText = "Jika pohon tersenyum hal itu disebut?", ExpectedAnswer = "gila" }
                }
            },
            // Bab 3: Hukum Newton II
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
            },
            // Dummy dulu kehabisan bahan soal w
            new Lesson("Dummy Lesson", "Ini adalah pelajaran dummy untuk memastikan program tetap berjalan setelah Bab 3 Modul 1 selesai.")
            {
                Questions = new List<IQuestion>
                {
                    new ObjectiveQuiz<string> { QuestionText = "Soal dummy untuk memastikan program tetap berjalan setelah Bab 3 Modul 1 selesai.", 
                        ExpectedAnswer = "dummy",
                        Options = new List<string> { "dummy", "test", "placeholder", "sample" }
                    }
                }
            },
            new Lesson("Hukum Dummy I", "Benda cenderung mempertahankan senyumannya.")
            {
                Questions = new List<IQuestion>
                {
                    new ObjectiveQuiz<string> { QuestionText = "Jika pohon tersenyum hal itu disebut?",
                        ExpectedAnswer = "gila",
                        Options = new List<string>{"gila","aneh","luar bisa","tidak manuk akal"}
                    }
                }
            },
            new Lesson("Hukum Dummy I", "Benda cenderung mempertahankan senyumannya.")
            {
                Questions = new List<IQuestion>
                {
                    new ObjectiveQuiz<string> { QuestionText = "Jika kursi tersenyum hal itu disebut?",
                        ExpectedAnswer = "gila",
                        Options = new List<string>{"gila","aneh","luar bisa","tidak manuk akal"}
                    }
                }
            },
            new Lesson("Hukum Dummy I", "Benda cenderung mempertahankan senyumannya.")
            {
                Questions = new List<IQuestion>
                {
                    new ObjectiveQuiz<string> { QuestionText = "Jika ada pohon yang mengejar anda sambil tersenyum apa yang harus dilakukan?",
                        ExpectedAnswer = "keren",
                        Options = new List<string>{"Tersenyum balik","Lompat","ngoding","keren"}
                    }
                }
            },
            new Lesson("Hukum Dummy I", "Benda cenderung mempertahankan senyumannya.")
            {
                Questions = new List<IQuestion>
                {
                    new ObjectiveQuiz<string> { QuestionText = "Seberapa cepat pohon yang tersenyum dapat berlari?",
                        ExpectedAnswer = "cepat",
                        Options = new List<string>{"gila","1/aneh","3/luar bisa","cepat"}
                    }
                }
            },
            new Lesson("Hukum Dummy I", "Benda cenderung mempertahankan senyumannya.")
            {
                Questions = new List<IQuestion>
                {
                    new ObjectiveQuiz<string> { QuestionText = "Seberapa besar gaya kinetik yang diperlukan untuk membuat pohon tersenyum?",
                        ExpectedAnswer = "Yang penting usaha",
                        Options = new List<string>{"gila","Yang penting usaha","banyak","Sebanyak banyaknya"}
                    }
                }
            },
            new Lesson("Hukum Dummy I", "Benda cenderung mempertahankan senyumannya.")
            {
                Questions = new List<IQuestion>
                {
                    new ObjectiveQuiz<string> { QuestionText = "Pohon back flip jika tersenyum?",
                        ExpectedAnswer = "bisa saja",
                        Options = new List<string>{"Keren","hah???","bisa saja","tidak manuk akal"}
                    }
                }
            },
            new Lesson("Hukum Dummy I", "Benda cenderung mempertahankan senyumannya.")
            {
                Questions = new List<IQuestion>
                {
                    new ObjectiveQuiz<string> { QuestionText = "Jika pohon tetap diam hal itu disebut?",
                        ExpectedAnswer = "gila",
                        Options = new List<string>{"gila","aneh","luar bisa","tidak manuk akal"}
                    }
                }
            }
        }),

        // MODUL 2: Gelombang & Optik
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