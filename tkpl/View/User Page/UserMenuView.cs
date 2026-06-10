using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tkpl.Controller;

namespace tkpl.View.User_Page
{
    public partial class UserMenuView : Form
    {
        public UserMenuView()
        {
            InitializeComponent();
        }

        public static Label GenerateLabel(string insert)
        {
            Debug.WriteLine("GENERATE ANSWER TEXTBOX EXECUTED");

            Label LabelBox = new Label();
            
            //LabelBox.Name = "essayTextBox";
            // Mengambil ukuran dan font dari konfigurasi runtime
            LabelBox.Size = new Size(AppConfig.UI.TextBoxWidth, AppConfig.UI.TextBoxHeight);
            LabelBox.Font = new Font(AppConfig.UI.FontFamily, AppConfig.UI.FontSize);
            LabelBox.Text = insert;

            return LabelBox;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
