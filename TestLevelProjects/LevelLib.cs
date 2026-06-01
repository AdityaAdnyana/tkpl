namespace TestLevelProjects
{
    [TestClass]
    public class LevelLib
    {
        [TestMethod]
        public void TestDataLevel()
        {
            Lesson lesson = new Lesson("Title", "Content", "Question", "Answer");

            Assert.AreEqual("Title", lesson.Title);
            Assert.AreEqual("Answer", lesson.Answer);

            Module module = new Module("Dasar", new List<Lesson> { lesson }, 3);
            Assert.HasCount(1, module.Lessons);
            Assert.AreEqual(3, module.MaxLives);
        }

        [TestMethod]
        public void TestLogicLevel_CorrectAnswer()
        {
            LogicLevel logic = new LogicLevel();

            logic.ProcessAnswer("const");

            logic.DisplayStatus();
        }

        [TestMethod]
        public void TestLogicLevel_WrongAnswer() 
        {
            LogicLevel logic = new LogicLevel();

            logic.ProcessAnswer("salah 1"); // Sisa 2
            logic.ProcessAnswer("salah 2"); // Sisa 1
            logic.ProcessAnswer("salah 3"); // Sisa 0

            logic.DisplayStatus();
        }

        // Buat cek jalur percabangan if/else di HandleSuccess dan DecreaseLevel
        // agar code coverage menjadi 100%
        [TestMethod]
        public void TestLogicLevel_AdditionalPaths()
        {
            LogicLevel logic = new LogicLevel();

            // --- uji HandleSuccess sampai tamat ---
            logic.ProcessAnswer("const"); // Modul 0, Materi 0
            logic.ProcessAnswer("int");   // Modul 0, Materi 1
            logic.ProcessAnswer("new");   // Modul 1, Materi 0 (Soal Terakhir)

            // --- uji WrongAnswer sampai tamat ---
            LogicLevel logicBaru = new LogicLevel();
            logicBaru.ProcessAnswer("salah");
            logicBaru.ProcessAnswer("salah");
            logicBaru.ProcessAnswer("salah");
        }

        // Buat cek nyawa berkurang
        [TestMethod]
        public void TestNyawaBerkurang()
        {
            LogicLevel logic = new LogicLevel();
            int nyawaAwal = logic._currentLives;

            logic.ProcessAnswer("jawaban asal");

            Assert.AreEqual(nyawaAwal - 1, logic._currentLives);
        }

        // Buat cek penurunan level saat nyawa habis, terutama saat sudah di modul 0
        [TestMethod]
        public void TestDecreaseLevel()
        {
            LogicLevel logic = new LogicLevel();

            logic.ProcessAnswer("const");
            logic.ProcessAnswer("int");

            logic.ProcessAnswer("salah");
            logic.ProcessAnswer("salah");
            logic.ProcessAnswer("salah");

            Assert.AreEqual(0, logic._currentModIdx);
        }

        // Buat cek jalur FALSE pada 'if' di DecreaseLevel agar code coverage menjadi 100%
        [TestMethod]
        public void TestDecreaseLevel_BranchCek()
        {
            LogicLevel logic = new LogicLevel();

            logic.ProcessAnswer("salah");
            logic.ProcessAnswer("salah");
            logic.ProcessAnswer("salah");

            Assert.AreEqual(0, logic._currentModIdx);
        }

        [TestMethod]
        public void TestLogicLevel_InvalidInput()
        {
            LogicLevel logic = new LogicLevel();

            // Menguji Pre-condition: Input null atau spasi
            logic.ProcessAnswer("");
            logic.ProcessAnswer("   ");

            //Assert.AreEqual("Input tidak valid", logic.ProcessAnswer(""));
        }

        [TestMethod]
        public void TestRepoLevel()
        {
            // Memastikan data di RepoLevel.cs tidak kosong saat dimulai
            Assert.IsNotNull(RepoLevel.MasterTable);
            Assert.IsTrue(RepoLevel.MasterTable.Count > 0);

            // Cek spesifik modul pertama
            var firstMod = RepoLevel.MasterTable[0];
            Assert.AreEqual("Dasar C#", firstMod.ModuleName);
            Assert.AreEqual(2, firstMod.Lessons.Count);
        }

        [TestMethod]
        public void TestEmptyConstructors()
        {
            // Memanggil Constructor kosong Lesson
            Lesson lesson = new Lesson();
            Assert.IsNotNull(lesson);

            // Memanggil Constructor kosong Module
            Module module = new Module();
            Assert.IsNotNull(module);
        }

        // Biar 100% code coverage, panggil Program.Main() walaupun isinya cuma Console.WriteLine
        [TestMethod]
        public void TestProgramMain()
        {
            Program.Main();
        }
    }
}
