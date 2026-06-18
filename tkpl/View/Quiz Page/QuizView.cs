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

        /// <summary>
        /// Membersihkan kontrol yang ada di dalam panel jawaban.
        /// Seperti button jawaban atau TextBox.
        /// </summary>
        public void ClearControls()
        {
            Debug.WriteLine("CLEAR CONTROLS EXECUTED");

            answerPanel.Controls.Clear();
        }

        /// <summary>
        /// Menambahkan kontrol ke dalam panel jawaban.
        /// Berfungsi untuk menambahkan tombol jawaban atau TextBox ke dalam tampilan kuis.
        /// </summary>
        public void AddControl(Control ctrl)
        {
            Debug.WriteLine("ADD CONTROL EXECUTED");

            answerPanel.Controls.Add(ctrl);
        }

        /// <summary>
        /// Menambahkan pertanyaan ke label yang ada di tampilan kuis.
        /// </summary>
        public void SetQuestionText(string text)
        {
            Debug.WriteLine("SET QUESTION TEXT EXECUTED");

            questionLabel.Text = text;
        }


        public void InitProgressBar(int maxValue, int currentValue)
        {
            quizSessionProgressBar.Maximum = maxValue;
            UpdateProgressBarValue(currentValue);
        }

        public void UpdateProgressBarValue(int newValue)
        {
            if (newValue <= quizSessionProgressBar.Maximum)
            {
                quizSessionProgressBar.Value = newValue;
            }
        }

        public void UpdateHealthVal(int newValue)
        {
            health.Text = $"❤️ {newValue}";
        }

        /// <summary>
        /// Implementasi ILivesObserver: bereaksi ketika ada notifikasi dari publisher
        /// </summary>
        public void Update(int currentLives)
        {
            UpdateHealthVal(currentLives);
        }

        public event EventHandler SkipClicked
        {
            add { btSkip.Click += value; }
            remove { btSkip.Click -= value; }
        }

        public void ShowInfoMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowWarningMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowErrorMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
