using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tkpl.View.Materi_Page
{
    public partial class MateriPage : Form
    {
        private int currentMaterialId ; 
        public MateriPage(int currentMaterialId)
        {
            InitializeComponent();
            this.currentMaterialId = currentMaterialId;
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void FormMateri_Load(object sender, EventArgs e)
        {
            
            ReadingMaterialDisplay displayData = ReadingMaterialFactory.CreateDisplayMaterial(currentMaterialId);

            
            LbTitle.Text = displayData.Title;
            LbMateri.Text = displayData.Content;

      
            if (displayData.CoverImage != null)
            {
                pictureBox1.Image = displayData.CoverImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Agar gambar proporsional
                pictureBox1.Visible = true;
            }
            else
            {
                pictureBox1.Visible = false; // Sembunyikan PictureBox jika materi tidak ada gambarnya
            }
        }
    }
}
