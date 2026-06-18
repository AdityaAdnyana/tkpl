namespace tkpl.Model
{
    public class UIConfig
    {
        // QuizControl Settings
        public int AnswerButtonWidth { get; set; } = 100;
        public int AnswerButtonHeight { get; set; } = 80;
        public float AnswerButtonFontSize { get; set; } = 12f;

        public int TextBoxWidth { get; set; } = 300;
        public int TextBoxHeight { get; set; } = 30;

        public int SubmitButtonWidth { get; set; } = 120;
        public int SubmitButtonHeight { get; set; } = 80;
        public float SubmitButtonFontSize { get; set; } = 12f;

        public string FontFamily { get; set; } = "Times New Roman";
        public float FontSize { get; set; } = 12f;

        // ScoreCard Settings
        public int ScoreCardWidth { get; set; } = 198;
        public int ScoreCardHeight { get; set; } = 175;

        public int ScoreCardContentWidth { get; set; } = 156;
        public int ScoreCardContentHeight { get; set; } = 118;
        public float ScoreCardContentFontSize { get; set; } = 8f;
        public string ScoreCardContentFontFamily { get; set; } = "Segoe UI";

        public int ScoreCardButtonWidth { get; set; } = 192;
        public int ScoreCardButtonHeight { get; set; } = 43;
        public float ScoreCardButtonFontSize { get; set; } = 9f;
        public string ScoreCardButtonFontFamily { get; set; } = "Segoe UI";
    }
}
