namespace tkpl
{
    partial class QuizView
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
            panel3 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel4 = new Panel();
            btSkip = new Button();
            label1 = new Label();
            panel2 = new Panel();
            health = new Label();
            button1 = new Button();
            quizSessionProgressBar = new ProgressBar();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1058, 664);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 55);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1058, 609);
            panel3.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(77, 219);
            flowLayoutPanel1.Margin = new Padding(2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(876, 279);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(btSkip);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 550);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(1058, 59);
            panel4.TabIndex = 2;
            // 
            // btSkip
            // 
            btSkip.Location = new Point(924, 13);
            btSkip.Name = "btSkip";
            btSkip.Size = new Size(112, 34);
            btSkip.TabIndex = 1;
            btSkip.Text = "SKIP";
            btSkip.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(77, 38);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(876, 179);
            label1.TabIndex = 1;
            label1.Text = "Aksara tradisional yang paling banyak digunakan di Indonesia adalah....";
            // 
            // panel2
            // 
            panel2.Controls.Add(health);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(quizSessionProgressBar);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1058, 55);
            panel2.TabIndex = 2;
            // 
            // health
            // 
            health.AutoSize = true;
            health.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            health.ForeColor = Color.FromArgb(192, 0, 0);
            health.Location = new Point(958, 9);
            health.Name = "health";
            health.Size = new Size(78, 38);
            health.TabIndex = 2;
            health.Text = "❤️ 3";
            // 
            // button1
            // 
            button1.Location = new Point(11, 2);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(51, 51);
            button1.TabIndex = 1;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            // 
            // quizSessionProgressBar
            // 
            quizSessionProgressBar.Location = new Point(77, 8);
            quizSessionProgressBar.Margin = new Padding(2);
            quizSessionProgressBar.Name = "quizSessionProgressBar";
            quizSessionProgressBar.Size = new Size(876, 35);
            quizSessionProgressBar.TabIndex = 0;
            // 
            // QuizView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1058, 664);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "QuizView";
            Text = "Quiz";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label label1;
        private Panel panel2;
        private Panel panel4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private ProgressBar quizSessionProgressBar;
        private Label health;
        private Button btSkip;
    }
}