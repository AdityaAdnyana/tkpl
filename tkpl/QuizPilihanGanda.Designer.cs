namespace tkpl
{
    partial class QuizPilihanGanda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btAnswerA = new Button();
            btAnswerB = new Button();
            btAnswerC = new Button();
            btAnswerD = new Button();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(38, 26);
            label1.Name = "label1";
            label1.Size = new Size(724, 81);
            label1.TabIndex = 1;
            label1.Text = "Aksara tradisional yang paling banyak digunakan di Indonesia adalah....";
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(progressBar1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 81);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 81);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 369);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(flowLayoutPanel1);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 144);
            panel4.Name = "panel4";
            panel4.Size = new Size(800, 225);
            panel4.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btAnswerA);
            flowLayoutPanel1.Controls.Add(btAnswerB);
            flowLayoutPanel1.Controls.Add(btAnswerC);
            flowLayoutPanel1.Controls.Add(btAnswerD);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 225);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btAnswerA
            // 
            btAnswerA.Location = new Point(3, 3);
            btAnswerA.Name = "btAnswerA";
            btAnswerA.Size = new Size(214, 110);
            btAnswerA.TabIndex = 0;
            btAnswerA.Text = "A. Aksara Jawa";
            btAnswerA.UseVisualStyleBackColor = true;
            // 
            // btAnswerB
            // 
            btAnswerB.Location = new Point(223, 3);
            btAnswerB.Name = "btAnswerB";
            btAnswerB.Size = new Size(207, 110);
            btAnswerB.TabIndex = 1;
            btAnswerB.Text = "B. Aksara Bali";
            btAnswerB.UseVisualStyleBackColor = true;
            // 
            // btAnswerC
            // 
            btAnswerC.Location = new Point(436, 3);
            btAnswerC.Name = "btAnswerC";
            btAnswerC.Size = new Size(214, 110);
            btAnswerC.TabIndex = 2;
            btAnswerC.Text = "C. Aksara China";
            btAnswerC.UseVisualStyleBackColor = true;
            // 
            // btAnswerD
            // 
            btAnswerD.Location = new Point(3, 119);
            btAnswerD.Name = "btAnswerD";
            btAnswerD.Size = new Size(207, 113);
            btAnswerD.TabIndex = 3;
            btAnswerD.Text = "D. Aksara Sunda";
            btAnswerD.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(537, 12);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(225, 52);
            progressBar1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(100, 63);
            button1.TabIndex = 1;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = true;
            // 
            // QuizPilihanGanda
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "QuizPilihanGanda";
            Text = "Quiz";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label label1;
        private Panel panel2;
        private Panel panel4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btAnswerA;
        private Button btAnswerB;
        private Button btAnswerC;
        private Button btAnswerD;
        private Button button1;
        private ProgressBar progressBar1;
    }
}