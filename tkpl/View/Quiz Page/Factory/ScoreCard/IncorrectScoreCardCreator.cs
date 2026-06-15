namespace tkpl.View.Factory.ScoreCard
{
    /// <summary>
    /// Concrete Creator: membuat IncorrectScoreCard untuk soal yang dijawab salah.
    /// </summary>
    public class IncorrectScoreCardCreator : ScoreCardCreator
    {
        public IncorrectScoreCardCreator(string questionText, string answerText)
            : base(questionText, answerText) { }

        public override IScoreCard FactoryMethod()
        {
            return new IncorrectScoreCard(_questionText, _answerText);
        }
    }
}
