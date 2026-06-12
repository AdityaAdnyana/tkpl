namespace tkpl.Model
{
    //Dibuat untuk memudahkan penambahan jenis soal baru di masa depan tanpa harus mengubah struktur kelas yang sudah ada.
    public interface IQuestion
    {
        public string QuestionText { get; set; }
        public bool ValidateAnswer(object answer);
        string GetExpectedAnswerAsString();
    }
}
