using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using tkpl.Controller;
using tkpl.Model.HomePage;
using tkpl.Model.Observer;

namespace tkpl
{
    public partial class QuizView : Form, ILivesObserver
    {
        StateMachine stateMachine = new StateMachine(); 
        public QuizView()
        {
            InitializeComponent();
            stateMachine.TransitionState("quiz");
        }

        // Method untuk membersihkan kontrol yang ada di dalam FlowLayoutPanel.
        // Seperti button jawaban atau TextBox
        public void ClearControls()
        {
            Debug.WriteLine("CLEAR CONTROLS EXECUTED");

            flowLayoutPanel1.Controls.Clear();
        }

        // Method untuk menambahkan kontrol ke dalam FlowLayoutPanel
        // Berfungsi untuk menambahkan tombol jawaban atau TextBox ke dalam tampilan kuis.
        public void AddControl(Control ctrl)
        {
            Debug.WriteLine("ADD CONTROL EXECUTED");


            flowLayoutPanel1.Controls.Add(ctrl);
        }

        // Menambahkan pertanyaan ke label yang ada di tampilan kuis.
        public void SetQuestionText(string text)
        {
            Debug.WriteLine("SET QUESTION TEXT EXECUTED");

            label1.Text = text;
        }


        public void InitProgressBar(int maxVal, int curVal)
        {
            quizSessionProgressBar.Maximum = maxVal;
            UpdateProgressBarValue(curVal);

        }

        public void UpdateProgressBarValue(int newVal)
        {
            if (newVal <= quizSessionProgressBar.Maximum)
            {
                quizSessionProgressBar.Value = newVal;
                if (newVal > 0)
                {
                    quizSessionProgressBar.Value = newVal - 1;
                    quizSessionProgressBar.Value = newVal;
                }
            }
        }

        public void UpdateHealthVal(int newVal)
        {
            health.Text = $"❤️ {newVal}";
        }

        // Implementasi ILivesObserver: bereaksi ketika ada notifikasi dari publisher
        public void Update(int currentLives)
        {
            UpdateHealthVal(currentLives);
        }

        public Button GetBtSkip()
        {
            return btSkip;
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QuizView_Load(object sender, EventArgs e)
        {

        }
    }

}
