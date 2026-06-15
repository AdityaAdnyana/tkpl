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
        public void SetResult(int correctAnswers, int totalQuestions)
        {
            lbTotalScoreVal.Text = $"{correctAnswers}/{totalQuestions}";
            lbAnsweredVal.Text = $"{totalQuestions}";

            int percentage = totalQuestions > 0 ? (correctAnswers * 100) / totalQuestions : 0;
            progressValue.Maximum = 100;
            progressValue.Value = percentage;
            lbProgressValue.Text = $"{percentage}%";

            // Mengaktifkan panel review agar user dapat melihat score cards
            panelScoreCard.Enabled = true;
        }

        public Button GetBtReview() => btReview;


        public Button GetBtClose() => btClose;


        public Button GetBtContinue() => btContinue;
        

        public void ToglePanelScoreCard()
        {
            panelScoreCard.Visible = !panelScoreCard.Visible;
        }

        private void QuizSessionResult_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
