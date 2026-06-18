using System;
using System.Drawing;
using System.Windows.Forms;
using tkpl.Model.HomePage;
using tkpl.View.Factory.ScoreCard;

namespace tkpl.View
{
    public partial class QuizSessionResult : Form
    {
        StateMachine stateMachine = new StateMachine();
        public QuizSessionResult()
        {
            InitializeComponent();
            stateMachine.TransitionState("quiz");
        }

        /// <summary>
        /// Membersihkan semua score card yang ada di FlowLayoutPanel
        /// sebelum menambahkan score card baru. Mencegah score card lama
        /// tertumpuk dengan yang baru.
        /// </summary>
        public void ClearScoreCards()
        {
            scoreFlowPanel.Controls.Clear();
        }

        /// <summary>
        /// Menambahkan score card panel yang dibuat oleh ScoreCardCreator (Factory Method Pattern)
        /// ke dalam FlowLayoutPanel untuk ditampilkan.
        /// </summary>
        public void AddScoreCardPanel(Panel panel)
        {
            scoreFlowPanel.Controls.Add(panel);
        }

        /// <summary>
        /// Menampilkan ringkasan hasil sesi quiz: skor, jumlah dijawab, dan persentase progress.
        /// Mengaktifkan panel review agar score card dapat dilihat.
        /// </summary>
        public void SetResult(string scoreText, string answeredText, string skippedText, string sessionTimeText, int progressPercentage, string progressPercentageText)
        {
            totalScoreLabel.Text = scoreText;
            answeredCountLabel.Text = answeredText;
            skippedCountLabel.Text = skippedText;
            sessionTimeLabel.Text = sessionTimeText;

            sessionProgressBar.Maximum = 100;
            sessionProgressBar.Value = progressPercentage;
            progressPercentageLabel.Text = progressPercentageText;

            // Mengaktifkan panel review agar user dapat melihat score cards
            scoreCardPanel.Enabled = true;
        }

        public event EventHandler ReviewClicked
        {
            add { reviewButton.Click += value; }
            remove { reviewButton.Click -= value; }
        }

        public event EventHandler CloseClicked
        {
            add { closeButton.Click += value; }
            remove { closeButton.Click -= value; }
        }

        public event EventHandler ContinueClicked
        {
            add { continueButton.Click += value; }
            remove { continueButton.Click -= value; }
        }

        public void TogglePanelScoreCard()
        {
            scoreCardPanel.Visible = !scoreCardPanel.Visible;
        }
    }
}
