namespace tkpl.View.User_Page
{
    partial class UserPage
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
            LB_Password = new Label();
            btnToMateri = new Button();
            BtnUser = new Button();
            btnResultQuiz = new Button();
            BtnExit = new Button();
            label1 = new Label();
            dataGridViewReport = new DataGridView();
            label2 = new Label();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).BeginInit();
            SuspendLayout();
            // 
            // LB_Password
            // 
            LB_Password.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LB_Password.Location = new Point(24, 9);
            LB_Password.Name = "LB_Password";
            LB_Password.Size = new Size(244, 53);
            LB_Password.TabIndex = 1;
            LB_Password.Text = "label1";
            LB_Password.Click += label1_Click;
            // 
            // btnToMateri
            // 
            btnToMateri.Location = new Point(296, 959);
            btnToMateri.Name = "btnToMateri";
            btnToMateri.Size = new Size(150, 46);
            btnToMateri.TabIndex = 10;
            btnToMateri.Text = "Materi";
            btnToMateri.UseVisualStyleBackColor = true;
            // 
            // BtnUser
            // 
            BtnUser.Location = new Point(6, 959);
            BtnUser.Name = "BtnUser";
            BtnUser.Size = new Size(150, 46);
            BtnUser.TabIndex = 9;
            BtnUser.Text = "User";
            BtnUser.UseVisualStyleBackColor = true;
            // 
            // btnResultQuiz
            // 
            btnResultQuiz.Location = new Point(587, 959);
            btnResultQuiz.Name = "btnResultQuiz";
            btnResultQuiz.Size = new Size(150, 46);
            btnResultQuiz.TabIndex = 8;
            btnResultQuiz.Text = "Result";
            btnResultQuiz.UseVisualStyleBackColor = true;
            // 
            // BtnExit
            // 
            BtnExit.Location = new Point(862, 959);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(150, 46);
            BtnExit.TabIndex = 7;
            BtnExit.Text = "Exit";
            BtnExit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 19.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 160);
            label1.Name = "label1";
            label1.Size = new Size(244, 64);
            label1.TabIndex = 11;
            label1.Text = "label1";
            // 
            // dataGridViewReport
            // 
            dataGridViewReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReport.Location = new Point(44, 468);
            dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewReport.RowHeadersWidth = 82;
            dataGridViewReport.Size = new Size(938, 395);
            dataGridViewReport.TabIndex = 12;
            dataGridViewReport.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 54);
            label2.Name = "label2";
            label2.Size = new Size(244, 51);
            label2.TabIndex = 13;
            label2.Text = "label1";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.Location = new Point(840, 66);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 46);
            btnLogout.TabIndex = 14;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click_1;
            // 
            // UserPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 1068);
            Controls.Add(btnLogout);
            Controls.Add(label2);
            Controls.Add(dataGridViewReport);
            Controls.Add(label1);
            Controls.Add(btnToMateri);
            Controls.Add(BtnUser);
            Controls.Add(btnResultQuiz);
            Controls.Add(BtnExit);
            Controls.Add(LB_Password);
            Name = "UserPage";
            Text = "UserPage";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReport).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label LB_Password;
        private Button btnToMateri;
        private Button BtnUser;
        private Button btnResultQuiz;
        private Button BtnExit;
        private Label label1;
        private DataGridView dataGridViewReport;
        private Label label2;
        private Button btnLogout;
    }
}