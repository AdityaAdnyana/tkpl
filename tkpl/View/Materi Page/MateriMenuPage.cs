using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tkpl.View.User_Page;

namespace tkpl.View.Materi_Page
{
    public partial class MateriMenuPage : Form
    {
        public MateriMenuPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStartLevel1_Click(object sender, EventArgs e)
        {
            MateriPage materiPage = new MateriPage(1); // 1 adalah ID materi pertama
            materiPage.Show();
            this.Hide();
        }

        private void btnToMateri_Click(object sender, EventArgs e)
        {

        }

        private void btnMateriLevel2_Click(object sender, EventArgs e)
        {
            MateriPage materiPage = new MateriPage(2); // 2 adalah ID materi kedua
            materiPage.Show();
            this.Hide();
        }

        private void btnMateriLevel3_Click(object sender, EventArgs e)
        {
            MateriPage materiPage = new MateriPage(3); // 3 adalah ID materi ketiga
            materiPage.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UserPage userPage = new UserPage();
            userPage.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.FormClosed += (s, args) => this.Close();
            homepage.Show();
            this.Hide();
        }
    }
}
