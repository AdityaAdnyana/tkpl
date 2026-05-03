using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tkpl
{
    public partial class QuizView : Form
    {
        public QuizView()
        {
            InitializeComponent();
        }

        // Method untuk menghasilkan TextBox untuk soal essay.
        public static TextBox GenerateAnswerTextBox()
        {
            Debug.WriteLine("GENERATE ANSWER TEXTBOX EXECUTED");

            TextBox answerTextBox = new TextBox();
            answerTextBox.Name = "essayTextBox";
            answerTextBox.Size = new Size(300, 30);
            answerTextBox.Font = new Font("Arial", 12);

            return answerTextBox;
        }

        // Method untuk menghasilkan tombol jawaban untuk soal pilihan ganda.
        public static Button GenerateAnswerButton(string answerText)
        {
            Debug.WriteLine("GENERETE ANSWER EXECUTED");

            Button answerButton = new Button();
            answerButton.Location = new Point(12, 12);
            answerButton.Name = "button1";
            answerButton.Size = new Size(100, 63);
            answerButton.TabIndex = 1;
            answerButton.Text = answerText;
            answerButton.UseVisualStyleBackColor = true;
            answerButton.Visible = true;

            return answerButton;
        }

        // Method untuk menghasilkan tombol submit untuk soal essay.
        public static Button GenerateSubmitButton()
        {
            Button submitBtn = new Button();
            submitBtn.Text = "Submit Jawaban";
            submitBtn.Size = new Size(120, 40);
            return submitBtn;
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

    }

}
