using System.Security.Permissions;

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

        //Report card Settings

        public int ReportCardWidth { get; set; } = 311;
        public int ReportCardHeight { get; set; } = 224;

        public int ReportCardContentWidth { get;set; } = 160;
        public int ReportCardContentHeight { get;set; } = 32;
        public float ReportCardContentFontSize { get; set; } =9f;  
        public string ReportCardContentFontFamily { get; set; } = "Segoe UI";

        // Report module Settings

        public int ReportModuleWidth { get; set; } = 938;
        public int ReportModuleHeight { get; set; } = 70;

        public int ReportModuleContentWidth { get; set; } = 380;
        public int ReportModuleContentHeight { get;set; } = 200;
        public float ReportModuleContentFontSize { get; set; } = 10f;
        public string ReportModuleContentFontFamily { get;set; } = "Segoe UI";

        public int ReportModuleButtonWidth { get; set; } = 150;
        public int ReportModuleButtonHeight { get;set; } = 36;
        public float ReportModuleButtonFontSize { get; set; } = 10f;
        public string ReportModuleButtonFontFamily { get;set; } = "Segoe UI";
    }
}
