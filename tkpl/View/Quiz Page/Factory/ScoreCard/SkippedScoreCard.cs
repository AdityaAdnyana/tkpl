using System.Drawing;
using System.Windows.Forms;

namespace tkpl.View.Factory.ScoreCard
{
    /// <summary>
    /// Concrete Product: score card panel untuk soal yang dilewati (skipped).
    /// Ditampilkan dengan warna abu-abu (LightGray) dan ikon ⏹️.
    /// </summary>
    public class SkippedScoreCard : IScoreCard
    {
        private readonly string _questionText;
        private readonly string _answerText;
        private readonly string _correctAnswer;

        public SkippedScoreCard(string questionText, string answerText, string correctAnswer)
        {
            _questionText = questionText;
            _answerText = answerText;
            _correctAnswer = correctAnswer;
        }

        public Panel GetPanel()
        {
            Panel panel = new Panel();
            panel.BackColor = Color.LightGray;
            panel.Size = new Size(198, 175);

            Label iconLabel = new Label();
            iconLabel.AutoSize = true;
            iconLabel.ForeColor = Color.DimGray;
            iconLabel.Location = new Point(157, 8);
            iconLabel.Text = "⏹️";

            Label contentLabel = new Label();
            contentLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contentLabel.Location = new Point(6, 11);
            contentLabel.Size = new Size(156, 118);
            contentLabel.Text = $"{_questionText}\nJawaban: {_answerText}";

            Button checkButton = new Button();
            checkButton.BackColor = Color.Silver;
            checkButton.Location = new Point(3, 132);
            checkButton.Size = new Size(192, 43);
            checkButton.Text = "Check Answer";
            checkButton.UseVisualStyleBackColor = false;
            bool isShowingAnswer = false;
            checkButton.Click += (sender, e) =>
            {
                if (!isShowingAnswer)
                {
                    contentLabel.Text = $"Jawaban Sebenarnya:\n{_correctAnswer}";
                    checkButton.Text = "Show Question";
                }
                else
                {
                    contentLabel.Text = $"{_questionText}\nJawaban: {_answerText}";
                    checkButton.Text = "Check Answer";
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
