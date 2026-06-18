namespace tkpl.View
{
    partial class Homepage
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
            btnStartLevel1 = new Button();
            btnExit = new Button();
            btnResultQuiz = new Button();
            btnUser = new Button();
            btnStartLevel2 = new Button();
            btnStartLevel3 = new Button();
            btnToMateri = new Button();
            SuspendLayout();
            // 
            // btnStartLevel1
            // 
            btnStartLevel1.Location = new Point(434, 117);
            btnStartLevel1.Name = "btnStartLevel1";
            btnStartLevel1.Size = new Size(150, 46);
            btnStartLevel1.TabIndex = 0;
            btnStartLevel1.Text = "Level1";
            btnStartLevel1.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(877, 879);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(150, 46);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnResultQuiz
            // 
            btnResultQuiz.Location = new Point(602, 879);
            btnResultQuiz.Name = "btnResultQuiz";
            btnResultQuiz.Size = new Size(150, 46);
            btnResultQuiz.TabIndex = 2;
            btnResultQuiz.Text = "Result";
            btnResultQuiz.UseVisualStyleBackColor = true;
            // 
            // btnUser
            // 
            BtnUser.Location = new Point(21, 879);
            BtnUser.Name = "BtnUser";
            BtnUser.Size = new Size(150, 46);
            BtnUser.TabIndex = 3;
            BtnUser.Text = "User";
            BtnUser.UseVisualStyleBackColor = true;
            BtnUser.Click += BtnUser_Click_1;
            btnUser.Location = new Point(21, 879);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(150, 46);
            btnUser.TabIndex = 3;
            btnUser.Text = "User";
            btnUser.UseVisualStyleBackColor = true;
            // 
            // btnStartLevel2
            // 
            btnStartLevel2.Location = new Point(565, 341);
            btnStartLevel2.Name = "btnStartLevel2";
            btnStartLevel2.Size = new Size(150, 46);
            btnStartLevel2.TabIndex = 4;
            btnStartLevel2.Text = "Level2";
            btnStartLevel2.UseVisualStyleBackColor = true;
            // 
            // btnStartLevel3
            // 
            btnStartLevel3.Location = new Point(283, 495);
            btnStartLevel3.Name = "btnStartLevel3";
            btnStartLevel3.Size = new Size(150, 46);
            btnStartLevel3.TabIndex = 5;
            btnStartLevel3.Text = "Level3";
            btnStartLevel3.UseVisualStyleBackColor = true;
            btnStartLevel3.Click += btnStartLevel3_Click;
            // 
            // btnToMateri
            // 
            btnToMateri.Location = new Point(311, 879);
            btnToMateri.Name = "btnToMateri";
            btnToMateri.Size = new Size(150, 46);
            btnToMateri.TabIndex = 6;
            btnToMateri.Text = "Materi";
            btnToMateri.UseVisualStyleBackColor = true;
            btnToMateri.Click += btnToMateri_Click;
            // 
            // Homepage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 960);
            Controls.Add(btnToMateri);
            Controls.Add(btnStartLevel3);
            Controls.Add(btnStartLevel2);
            Controls.Add(btnUser);
            Controls.Add(btnResultQuiz);
            Controls.Add(btnExit);
            Controls.Add(btnStartLevel1);
            Name = "Homepage";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private Button btnStartLevel1;
        private Button btnExit;
        private Button btnResultQuiz;
        private Button btnUser;
        private Button btnStartLevel2;
        private Button btnStartLevel3;
        private Button btnToMateri;


    }
}