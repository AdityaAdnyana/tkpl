using System.Drawing;
using System.Windows.Forms;
using tkpl.Controller;

namespace tkpl.View.Factory.ScoreCard
{
    /// <summary>
    /// Concrete Product: score card panel untuk soal yang dijawab salah.
    /// Ditampilkan dengan warna merah (RosyBrown) dan ikon ❎.
    /// </summary>
    public class IncorrectScoreCard : IScoreCard
    {
        private readonly string _questionText;
        private readonly string _answerText;
        private readonly string _correctAnswer;

        public IncorrectScoreCard(string questionText, string answerText, string correctAnswer)
        {
            _questionText = questionText;
            _answerText = answerText;
            _correctAnswer = correctAnswer;
        }

        public Panel GetPanel()
        {
            var ui = AppConfig.UI;
            Panel panel = new Panel();
            panel.BackColor = Color.RosyBrown;
            panel.Size = new Size(ui.ScoreCardWidth, ui.ScoreCardHeight);

            Label iconLabel = new Label();
            iconLabel.AutoSize = true;
            iconLabel.ForeColor = Color.Maroon;
            iconLabel.Location = new Point(157, 8);
            iconLabel.Text = "❎";

            Label contentLabel = new Label();
            contentLabel.Font = new Font(ui.ScoreCardContentFontFamily, ui.ScoreCardContentFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            contentLabel.Location = new Point(6, 11);
            contentLabel.Size = new Size(ui.ScoreCardContentWidth, ui.ScoreCardContentHeight);
            contentLabel.Text = $"{_questionText}\nJawaban: {_answerText}";

            Button checkButton = new Button();
            checkButton.BackColor = Color.FromArgb(128, 64, 64);
            checkButton.Font = new Font(ui.ScoreCardButtonFontFamily, ui.ScoreCardButtonFontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkButton.Location = new Point(3, 132);
            checkButton.Size = new Size(ui.ScoreCardButtonWidth, ui.ScoreCardButtonHeight);
            checkButton.Text = "Periksa Jawaban";
            checkButton.UseVisualStyleBackColor = false;
            bool isShowingAnswer = false;
            checkButton.Click += (sender, e) =>
            {
                if (!isShowingAnswer)
                {
                    contentLabel.Text = $"Jawaban Sebenarnya:\n{_correctAnswer}";
                    checkButton.Text = "Lihat Soal";
                }
                else
                {
                    contentLabel.Text = $"{_questionText}\nJawaban: {_answerText}";
                    checkButton.Text = "Periksa Jawaban";
                }
                isShowingAnswer = !isShowingAnswer;
            };

            panel.Controls.Add(iconLabel);
            panel.Controls.Add(contentLabel);
            panel.Controls.Add(checkButton);

            return panel;
        }
    }
}
