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
            panel4 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            panel2 = new Panel();
            button1 = new Button();
            progressBar1 = new ProgressBar();
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
            panel1.Name = "panel1";
            panel1.Size = new Size(693, 389);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(693, 319);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(flowLayoutPanel1);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 124);
            panel4.Name = "panel4";
            panel4.Size = new Size(693, 195);
            panel4.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(693, 195);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Location = new Point(32, 23);
            label1.Name = "label1";
            label1.Size = new Size(628, 70);
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
            panel2.Size = new Size(693, 70);
            panel2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(10, 10);
            button1.Name = "button1";
            button1.Size = new Size(87, 55);
            button1.TabIndex = 1;
            button1.Text = "Home";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(465, 10);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(195, 45);
            progressBar1.TabIndex = 0;
            // 
            // QuizView
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(693, 389);
            Controls.Add(panel1);
            Name = "QuizView";
            Text = "Quiz";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
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
        private ProgressBar progressBar1;
    }
}