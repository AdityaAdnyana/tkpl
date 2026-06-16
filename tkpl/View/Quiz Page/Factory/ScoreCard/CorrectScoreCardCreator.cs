namespace tkpl.View.Factory.ScoreCard
{
    /// <summary>
    /// Concrete Creator: membuat CorrectScoreCard untuk soal yang dijawab benar.
    /// </summary>
    public class CorrectScoreCardCreator : ScoreCardCreator
    {
        public CorrectScoreCardCreator(string questionText, string answerText, string correctAnswer)
            : base(questionText, answerText, correctAnswer) { }

        public override IScoreCard FactoryMethod()
        {
            return new CorrectScoreCard(_questionText, _answerText, _correctAnswer);
        }
    }
}
