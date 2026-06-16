namespace tkpl.View.Factory.ScoreCard
{
    /// <summary>
    /// Concrete Creator: membuat IncorrectScoreCard untuk soal yang dijawab salah.
    /// </summary>
    public class IncorrectScoreCardCreator : ScoreCardCreator
    {
        public IncorrectScoreCardCreator(string questionText, string answerText, string correctAnswer)
            : base(questionText, answerText, correctAnswer) { }

        public override IScoreCard FactoryMethod()
        {
            return new IncorrectScoreCard(_questionText, _answerText, _correctAnswer);
        }
    }
}
