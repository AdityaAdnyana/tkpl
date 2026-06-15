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

        public Button GetBtnStartLevel1() => btnStartLevel1;
        public Button GetBtnStartLevel2() => btnStartLevel2;
        public Button GetBtnStartLevel3() => btnStartLevel3;
        public Button GetBtnExit() => btnExit;
    }
}