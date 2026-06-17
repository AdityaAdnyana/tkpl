using System;
using System.Drawing;
using System.Windows.Forms;
using tkpl.View.Factory.ScoreCard;

namespace tkpl.View
{
    public partial class QuizSessionResult : Form
    {
        public QuizSessionResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Membersihkan semua score card yang ada di FlowLayoutPanel
        /// sebelum menambahkan score card baru. Mencegah score card lama
        /// tertumpuk dengan yang baru.
        /// </summary>
        public void ClearScoreCards()
        {
            fLScore.Controls.Clear();
        }

        /// <summary>
        /// Menambahkan score card panel yang dibuat oleh ScoreCardCreator (Factory Method Pattern)
        /// ke dalam FlowLayoutPanel untuk ditampilkan.
        /// </summary>
        public void AddScoreCardPanel(Panel panel)
        {
            fLScore.Controls.Add(panel);
        }

        /// <summary>
        /// Menampilkan ringkasan hasil sesi quiz: skor, jumlah dijawab, dan persentase progress.
        /// Mengaktifkan panel review agar score card dapat dilihat.
        /// </summary>
        public void SetResult(decimal totalScore, decimal maxScore, int answeredQuestions, int skippedQuestions, TimeSpan sessionTime)
        {
            lbTotalScoreVal.Text = $"{totalScore:0.##}/{maxScore:0.##}";
            lbAnsweredVal.Text = $"{answeredQuestions}";
            lbSkippedVal.Text = $"{skippedQuestions}";
            
            // Format time as "mm:ss" if more than 60s, or just "ss s"
            if (sessionTime.TotalMinutes >= 1)
                lbSessionTimeVal.Text = $"{(int)sessionTime.TotalMinutes}m {sessionTime.Seconds}s";
            else
                lbSessionTimeVal.Text = $"{sessionTime.Seconds}s";

            int percentage = maxScore > 0 ? (int)((totalScore * 100) / maxScore) : 0;
            progressValue.Maximum = 100;
            progressValue.Value = percentage;
            lbProgressValue.Text = $"{percentage}%";

            // Mengaktifkan panel review agar user dapat melihat score cards
            panelScoreCard.Enabled = true;
        }

        public event EventHandler OnReviewClicked
        {
            add { btReview.Click += value; }
            remove { btReview.Click -= value; }
        }

        public event EventHandler OnCloseClicked
        {
            add { btClose.Click += value; }
            remove { btClose.Click -= value; }
        }

        public event EventHandler OnContinueClicked
        {
            add { btContinue.Click += value; }
            remove { btContinue.Click -= value; }
        }

        public void TogglePanelScoreCard()
        {
            panelScoreCard.Visible = !panelScoreCard.Visible;
        }
    }
}
