using System;
using System.Windows.Forms;
using tkpl.Controller;
using tkpl.View.Materi_Page;
using tkpl.View.User_Page;

namespace tkpl.View
{
    public partial class Homepage : Form
    {
        private readonly HomepageController _controller;

        public Homepage()
        {
            InitializeComponent();
            _controller = new HomepageController(this);
        }

        private void BtnUser_Click_1(object sender, EventArgs e)
        {
            UserPage userProfile = new UserPage();
            userProfile.ShowDialog();
        }


        public Button GetBtnStartLevel1() => btnStartLevel1;
        public Button GetBtnStartLevel2() => btnStartLevel2;
        public Button GetBtnStartLevel3() => btnStartLevel3;
        public Button GetBtnExit() => btnExit;

        private void btnToMateri_Click(object sender, EventArgs e)
        {
            MateriMenuPage materiMenuPage = new MateriMenuPage();
            materiMenuPage.Show();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {

        }
    }

}