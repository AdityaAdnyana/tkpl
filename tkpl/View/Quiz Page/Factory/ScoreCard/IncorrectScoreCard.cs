using System.Drawing;
using System.Windows.Forms;

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

        public IncorrectScoreCard(string questionText, string answerText)
        {
            _questionText = questionText;
            _answerText = answerText;
        }

        public Panel GetPanel()
        {
            Panel panel = new Panel();
            panel.BackColor = Color.RosyBrown;
            panel.Size = new Size(198, 175);

            Label iconLabel = new Label();
            iconLabel.AutoSize = true;
            iconLabel.ForeColor = Color.Maroon;
            iconLabel.Location = new Point(157, 8);
            iconLabel.Text = "❎";

            Label contentLabel = new Label();
            contentLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contentLabel.Location = new Point(6, 11);
            contentLabel.Size = new Size(156, 118);
            contentLabel.Text = $"{_questionText}\nJawaban: {_answerText}";

            Button checkButton = new Button();
            checkButton.BackColor = Color.FromArgb(128, 64, 64);
            checkButton.Location = new Point(3, 132);
            checkButton.Size = new Size(192, 43);
            checkButton.Text = "Check Answer";
            checkButton.UseVisualStyleBackColor = false;

            panel.Controls.Add(iconLabel);
            panel.Controls.Add(contentLabel);
            panel.Controls.Add(checkButton);

            return panel;
        }
    }
}
