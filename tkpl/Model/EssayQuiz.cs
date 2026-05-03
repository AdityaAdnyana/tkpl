namespace tkpl.Model
{
    //Dibuat bertipe string karena input dari texbox di UI sudah pasti berupa string.
    internal class EssayQuiz : Question<string>
    {
        // Essay tidak memiliki opsi (Options), jadi GetStringOptions() 
        // akan otomatis mengembalikan list kosong dari base class Question<T>
    }
}
