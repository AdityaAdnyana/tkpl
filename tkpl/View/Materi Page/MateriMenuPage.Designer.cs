namespace tkpl.View.Materi_Page
{
    partial class MateriMenuPage
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
            btnMateriLevel3 = new Button();
            btnMateriLevel2 = new Button();
            btnMateriLevel1 = new Button();
            btnToMateri = new Button();
            btnUser = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // btnMateriLevel3
            // 
            btnMateriLevel3.Location = new Point(356, 436);
            btnMateriLevel3.Name = "btnMateriLevel3";
            btnMateriLevel3.Size = new Size(286, 46);
            btnMateriLevel3.TabIndex = 8;
            btnMateriLevel3.Text = "Materi Level3";
            btnMateriLevel3.UseVisualStyleBackColor = true;
            btnMateriLevel3.Click += btnMateriLevel3_Click;
            // 
            // btnMateriLevel2
            // 
            btnMateriLevel2.Location = new Point(356, 238);
            btnMateriLevel2.Name = "btnMateriLevel2";
            btnMateriLevel2.Size = new Size(286, 46);
            btnMateriLevel2.TabIndex = 7;
            btnMateriLevel2.Text = "Materi Level2";
            btnMateriLevel2.UseVisualStyleBackColor = true;
            btnMateriLevel2.Click += btnMateriLevel2_Click;
            // 
            // btnMateriLevel1
            // 
            btnMateriLevel1.Location = new Point(356, 55);
            btnMateriLevel1.Name = "btnMateriLevel1";
            btnMateriLevel1.Size = new Size(286, 46);
            btnMateriLevel1.TabIndex = 6;
            btnMateriLevel1.Text = "Materi Level1";
            btnMateriLevel1.UseVisualStyleBackColor = true;
            btnMateriLevel1.Click += btnStartLevel1_Click;
            // 
            // btnToMateri
            // 
            btnToMateri.Location = new Point(429, 825);
            btnToMateri.Name = "btnToMateri";
            btnToMateri.Size = new Size(150, 46);
            btnToMateri.TabIndex = 11;
            btnToMateri.Text = "Materi";
            btnToMateri.UseVisualStyleBackColor = true;
            btnToMateri.Click += btnToMateri_Click;
            // 
            // btnUser
            // 
            btnUser.Location = new Point(22, 825);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(150, 46);
            btnUser.TabIndex = 10;
            btnUser.Text = "User";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += btnUser_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(878, 825);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 46);
            btnBack.TabIndex = 9;
            btnBack.Text = "back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // MateriMenuPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 907);
            Controls.Add(btnToMateri);
            Controls.Add(btnUser);
            Controls.Add(btnBack);
            Controls.Add(btnMateriLevel3);
            Controls.Add(btnMateriLevel2);
            Controls.Add(btnMateriLevel1);
            Name = "MateriMenuPage";
            Text = "MateriMenuPage";
            ResumeLayout(false);
        }

        #endregion

        private Button btnMateriLevel3;
        private Button btnMateriLevel2;
        private Button btnMateriLevel1;
        private Button btnToMateri;
        private Button btnUser;
        private Button btnBack;
    }
}