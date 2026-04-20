using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tkpl
{
    public partial class QuizPilihanGanda : Form
    {
        public QuizPilihanGanda()
        {
            InitializeComponent();
        }

        public void GenerateAnswerButton(string answerText)
        {
            Button answerButton = new Button();
            answerButton.Text = answerText;
            answerButton.Width = 200;
            answerButton.Height = 50;
            flowLayoutPanel1.Controls.Add(answerButton);
        }

    }

}
