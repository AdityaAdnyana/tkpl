namespace tkpl.View.Materi_Page
{
    partial class MateriPage
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
            LbTitle = new Label();
            LbMateri = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LbTitle
            // 
            LbTitle.AutoSize = true;
            LbTitle.Font = new Font("Segoe UI", 24F);
            LbTitle.Location = new Point(59, 47);
            LbTitle.Name = "LbTitle";
            LbTitle.Size = new Size(158, 86);
            LbTitle.TabIndex = 0;
            LbTitle.Text = "Title";
            LbTitle.Click += Title_Click;
            // 
            // LbMateri
            // 
            LbMateri.Location = new Point(59, 643);
            LbMateri.Name = "LbMateri";
            LbMateri.Size = new Size(1105, 678);
            LbMateri.TabIndex = 1;
            LbMateri.Text = "Materi";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(59, 249);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 100);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // MateriPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1253, 1562);
            Controls.Add(pictureBox1);
            Controls.Add(LbMateri);
            Controls.Add(LbTitle);
            Name = "MateriPage";
            Text = "MateriPage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LbTitle;
        private Label LbMateri;
        private PictureBox pictureBox1;
    }
}