namespace tkpl.View.User_Page
{
    partial class SigninPage
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
            label1 = new Label();
            TbUsername = new TextBox();
            TbPassword = new TextBox();
            TbConPass = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            CbShowPassword = new CheckBox();
            BtSignIn = new Button();
            BtLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(258, 125);
            label1.Name = "label1";
            label1.Size = new Size(232, 86);
            label1.TabIndex = 0;
            label1.Text = "Sign In";
            // 
            // TbUsername
            // 
            TbUsername.Location = new Point(170, 294);
            TbUsername.Name = "TbUsername";
            TbUsername.Size = new Size(418, 39);
            TbUsername.TabIndex = 1;
            // 
            // TbPassword
            // 
            TbPassword.Location = new Point(170, 396);
            TbPassword.Name = "TbPassword";
            TbPassword.Size = new Size(418, 39);
            TbPassword.TabIndex = 2;
            // 
            // TbConPass
            // 
            TbConPass.Location = new Point(170, 502);
            TbConPass.Name = "TbConPass";
            TbConPass.Size = new Size(418, 39);
            TbConPass.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(170, 259);
            label2.Name = "label2";
            label2.Size = new Size(121, 32);
            label2.TabIndex = 4;
            label2.Text = "Username";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(170, 361);
            label3.Name = "label3";
            label3.Size = new Size(111, 32);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(170, 467);
            label4.Name = "label4";
            label4.Size = new Size(204, 32);
            label4.TabIndex = 6;
            label4.Text = "Confirm Password";
            // 
            // CbShowPassword
            // 
            CbShowPassword.AutoSize = true;
            CbShowPassword.Location = new Point(170, 570);
            CbShowPassword.Name = "CbShowPassword";
            CbShowPassword.Size = new Size(257, 36);
            CbShowPassword.TabIndex = 7;
            CbShowPassword.Text = "Tampilkan Password";
            CbShowPassword.UseVisualStyleBackColor = true;
            CbShowPassword.CheckedChanged += CbShowPassword_CheckedChanged;
            // 
            // BtSignIn
            // 
            BtSignIn.Location = new Point(170, 645);
            BtSignIn.Name = "BtSignIn";
            BtSignIn.Size = new Size(150, 46);
            BtSignIn.TabIndex = 8;
            BtSignIn.Text = "Sing In";
            BtSignIn.UseVisualStyleBackColor = true;
            BtSignIn.Click += BtSignIn_Click;
            // 
            // BtLogin
            // 
            BtLogin.Location = new Point(438, 645);
            BtLogin.Name = "BtLogin";
            BtLogin.Size = new Size(150, 46);
            BtLogin.TabIndex = 9;
            BtLogin.Text = "Login";
            BtLogin.UseVisualStyleBackColor = true;
            BtLogin.Click += BtLogin_Click;
            // 
            // SigninPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 840);
            Controls.Add(BtLogin);
            Controls.Add(BtSignIn);
            Controls.Add(CbShowPassword);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TbConPass);
            Controls.Add(TbPassword);
            Controls.Add(TbUsername);
            Controls.Add(label1);
            Name = "SigninPage";
            Text = "SigninPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TbUsername;
        private TextBox TbPassword;
        private TextBox TbConPass;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox CbShowPassword;
        private Button BtSignIn;
        private Button BtLogin;
    }
}