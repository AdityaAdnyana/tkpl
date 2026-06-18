using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tkpl.Controller;

namespace tkpl.View.Factory.QuizControl
{
    /// <summary>
    /// Concrete Product: menghasilkan daftar Button untuk soal pilihan ganda (objective).
    /// Setiap opsi jawaban ditampilkan sebagai Button terpisah dengan konfigurasi dari AppConfig.
    /// </summary>
    public class ObjectiveQuizControl : IQuizControl
    {
        private readonly List<string> _options;
        private readonly Action<string> _onOptionSelected;

        public ObjectiveQuizControl(List<string> options, Action<string> onOptionSelected)
        {
            _options = options;
            _onOptionSelected = onOptionSelected;
        }

        public List<Control> GetControls()
        {
            var controls = new List<Control>();

            foreach (var option in _options)
            {
                Button answerButton = new Button();
                answerButton.Size = new Size(AppConfig.UI.AnswerButtonWidth, AppConfig.UI.AnswerButtonHeight);
                answerButton.Font = new Font(AppConfig.UI.FontFamily, AppConfig.UI.AnswerButtonFontSize);
                answerButton.Text = option;
                answerButton.UseVisualStyleBackColor = true;
                answerButton.Visible = true;
                answerButton.Click += (sender, e) => _onOptionSelected(option);

                controls.Add(answerButton);
            }

            return controls;
        }
    }
}
