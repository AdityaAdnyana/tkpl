using tkpl.Model;

namespace tkpl.Model
{
    // Diubah menjadi generic <T> agar bisa menerima tipe data seperti int atau string.
    public class EssayQuiz<T> : Question<T>, IEssayQuiz
    {

    }
}
