namespace tkpl.Model
{
    //Dibuat untuk memudahkan penambahan jenis soal baru di masa depan tanpa harus mengubah struktur kelas yang sudah ada.
    internal interface IQuestion
    {
        public string QuestionText { get; set; }
        public bool ValidateAnswer(object answer);
        public string getAnswer();
        public List<string> GetStringOptions();
    }
}
