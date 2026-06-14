namespace tkpl.View.User_Page
{
    partial class LoginPage
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
            Label = new Label();
            TbUsername = new TextBox();
            TbPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BtnLogin = new Button();
            BtnSignIn = new Button();
            CbShowPss = new CheckBox();
            SuspendLayout();
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.Font = new Font("Segoe UI", 24F);
            Label.Location = new Point(274, 108);
            Label.Name = "Label";
            Label.Size = new Size(195, 86);
            Label.TabIndex = 0;
            Label.Text = "Login";
            Label.Click += label1_Click_1;
            // 
            // TbUsername
            // 
            TbUsername.Location = new Point(134, 257);
            TbUsername.Name = "TbUsername";
            TbUsername.Size = new Size(465, 39);
            TbUsername.TabIndex = 1;
            // 
            // TbPassword
            // 
            TbPassword.Location = new Point(134, 362);
            TbPassword.Name = "TbPassword";
            TbPassword.Size = new Size(465, 39);
            TbPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 222);
            label1.Name = "label1";
            label1.Size = new Size(121, 32);
            label1.TabIndex = 4;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(134, 327);
            label2.Name = "label2";
            label2.Size = new Size(111, 32);
            label2.TabIndex = 5;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // BtnLogin
            // 
            BtnLogin.Location = new Point(134, 484);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(150, 46);
            BtnLogin.TabIndex = 7;
            BtnLogin.Text = "Login";
            BtnLogin.UseVisualStyleBackColor = true;
            BtnLogin.Click += button1_Click;
            // 
            // BtnSignIn
            // 
            BtnSignIn.Location = new Point(449, 484);
            BtnSignIn.Name = "BtnSignIn";
            BtnSignIn.Size = new Size(150, 46);
            BtnSignIn.TabIndex = 8;
            BtnSignIn.Text = "Sign In";
            BtnSignIn.UseVisualStyleBackColor = true;
            BtnSignIn.Click += BtnSignIn_Click;
            // 
            // CbShowPss
            // 
            CbShowPss.AutoSize = true;
            CbShowPss.Location = new Point(134, 431);
            CbShowPss.Name = "CbShowPss";
            CbShowPss.Size = new Size(267, 36);
            CbShowPss.TabIndex = 9;
            CbShowPss.Text = "Perlihatkan Password";
            CbShowPss.UseVisualStyleBackColor = true;
            CbShowPss.CheckedChanged += CbShowPss_CheckedChanged;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 938);
            Controls.Add(CbShowPss);
            Controls.Add(BtnSignIn);
            Controls.Add(BtnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TbPassword);
            Controls.Add(TbUsername);
            Controls.Add(Label);
            Name = "LoginPage";
            Text = "LoginPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label;
        private TextBox TbUsername;
        private TextBox TbPassword;
        private Label label1;
        private Label label2;
        private Button BtnLogin;
        private Button BtnSignIn;
        private CheckBox CbShowPss;
    }
}