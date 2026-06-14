using System;
using System.Windows.Forms;
using tkpl.Controller;

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

        private void btnStartLevel1_Click(object sender, EventArgs e)
        {
            _controller.LoadQuizSession(0, 0);
        }

        private void btnStartLevel2_Click(object sender, EventArgs e)
        {
            _controller.LoadQuizSession(0, 1);
        }

        private void btnStartLevel3_Click(object sender, EventArgs e)
        {
            _controller.LoadQuizSession(0, 2);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _controller.ExitApplication();
        }
    }
}