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
    public partial class QuizPilihanGanda : Form
    {
        public QuizPilihanGanda()
        {
            InitializeComponent();
        }

        public static void GenerateAnswerButton(string answerText, FlowLayoutPanel c)
        {
            Debug.WriteLine("GENERETE ANSWER EXECUTED");

            Button answerButton = new Button();
            answerButton.Location = new Point(12, 12);
            answerButton.Name = "button1";
            answerButton.Size = new Size(100, 63);
            answerButton.TabIndex = 1;
            answerButton.Text = "Home";
            answerButton.UseVisualStyleBackColor = true;

            try
            {
                if (answerButton != null)
                    c.Controls.Add(answerButton);
            }
            catch (Exception ex)
            {

            }

                
            answerButton.Visible = true;
        }

    }

}
