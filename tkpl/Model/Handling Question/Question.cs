using System.Diagnostics;
namespace tkpl.Model
{
    public class Question<T> : IQuestion
    {

        public int Difficulty { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public T ExpectedAnswer { get; set; } = default!; // initialized to satisfy nullable-analysis (CS8618)

        // Implementasi IQuestion.ValidateAnswer yang menerima parameter bertipe T.
        public bool ValidateAnswer(T answer)
        {
            return EqualityComparer<T>.Default.Equals(answer, ExpectedAnswer);
        }

        // Implementasi IQuestion.ValidateAnswer yang menerima parameter object.
        // Method konversi. Dieksekusi jika dipanggil dengan parameter bertipe object, misalnya dari UI yang menerima input sebagai string.
        public bool ValidateAnswer(object answer)
        {
            try
            {
                T convertedAnswer = (T)Convert.ChangeType(answer, typeof(T));

                if (convertedAnswer is T typedAnswer) return ValidateAnswer(typedAnswer);
            }
            catch (FormatException)
            {
                // Membuat dan melempar error spesifik jika format gagal dikonversi
                string errorMsg = $"Format jawaban tidak sesuai! Harap masukkan nilai dalam bentuk {typeof(T).Name}.";
                Debug.WriteLine(errorMsg);

                // Throw digunakan agar error ini melompat naik untuk ditangkap oleh antarmuka (GUI)
                throw new FormatException(errorMsg);
            }
            catch (Exception ex)
            {
                // Menangkap kegagalan sistem umum lainnya
                Debug.WriteLine("Input tidak valid: " + ex.Message);
                throw new Exception("Terjadi kesalahan sistem saat memproses jawaban: " + ex.Message);
            }
            return false;
        }
    }
}
