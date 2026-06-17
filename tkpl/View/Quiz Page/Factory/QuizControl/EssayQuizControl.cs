using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tkpl.Controller;

namespace tkpl.View.Factory.QuizControl
{
    /// <summary>
    /// Concrete Product: menghasilkan TextBox dan Button submit untuk soal essay.
    /// Konfigurasi ukuran dan font diambil dari AppConfig.
    /// </summary>
    public class EssayQuizControl : IQuizControl
    {
        private readonly Action<string> _onAnswerSubmitted;

        public EssayQuizControl(Action<string> onAnswerSubmitted)
        {
            _onAnswerSubmitted = onAnswerSubmitted;
        }

        public List<Control> GetControls()
        {
            var controls = new List<Control>();

            TextBox answerTextBox = new TextBox();
            answerTextBox.Name = "essayTextBox";
            answerTextBox.Size = new Size(AppConfig.UI.TextBoxWidth, AppConfig.UI.TextBoxHeight);
            answerTextBox.Font = new Font(AppConfig.UI.FontFamily, AppConfig.UI.FontSize);

            Button submitButton = new Button();
            submitButton.Text = "Submit Jawaban";
            submitButton.Size = new Size(AppConfig.UI.SubmitButtonWidth, AppConfig.UI.SubmitButtonHeight);
            submitButton.Font = new Font(AppConfig.UI.FontFamily, AppConfig.UI.SubmitButtonFontSize);
            submitButton.Click += (sender, e) => _onAnswerSubmitted(answerTextBox.Text);

            controls.Add(answerTextBox);
            controls.Add(submitButton);

            return controls;
        }
    }
}
