namespace tkpl.View.Factory.ScoreCard
{
    /// <summary>
    /// Concrete Creator: membuat SkippedScoreCard untuk soal yang dilewati.
    /// </summary>
    public class SkippedScoreCardCreator : ScoreCardCreator
    {
        public SkippedScoreCardCreator(string questionText, string answerText)
            : base(questionText, answerText) { }

        public override IScoreCard FactoryMethod()
        {
            return new SkippedScoreCard(_questionText, _answerText);
        }
    }
}
