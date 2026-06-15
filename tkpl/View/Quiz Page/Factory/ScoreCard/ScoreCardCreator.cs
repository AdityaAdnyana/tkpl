using System.Windows.Forms;

namespace tkpl.View.Factory.ScoreCard
{
    /// <summary>
    /// Creator abstract class: mendeklarasikan factory method yang mengembalikan objek IScoreCard.
    /// Subclass (ConcreteCreator) menyediakan implementasi factory method ini.
    ///
    /// Tanggung jawab utama Creator bukan hanya membuat produk, melainkan
    /// menyediakan business logic (CreateCard) yang bergantung pada objek Product
    /// yang dikembalikan oleh factory method.
    /// </summary>
    public abstract class ScoreCardCreator
    {
        protected readonly string _questionText;
        protected readonly string _answerText;

        protected ScoreCardCreator(string questionText, string answerText)
        {
            _questionText = questionText;
            _answerText = answerText;
        }

        /// <summary>
        /// Factory Method: subclass harus meng-override method ini untuk mengembalikan
        /// concrete score card product yang sesuai.
        /// </summary>
        public abstract IScoreCard FactoryMethod();

        /// <summary>
        /// Business logic utama yang menggunakan factory method untuk membuat
        /// score card panel siap pakai.
        /// </summary>
        public Panel CreateCard()
        {
            IScoreCard scoreCard = FactoryMethod();
            return scoreCard.GetPanel();
        }
    }
}
