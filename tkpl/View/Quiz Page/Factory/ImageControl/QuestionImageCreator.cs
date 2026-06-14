using System;
using System.Drawing;
using System.Windows.Forms;

namespace tkpl.View.Factory.ImageControl
{
    public class QuestionImageCreator : ImageControlCreator
    {
        public override Control CreateImageControl(string imagePath)
        {
            try
            {
                var pictureBox = new PictureBox
                {
                    ImageLocation = imagePath,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 400,
                    Height = 200,
                    Margin = new Padding(10)
                };
                return pictureBox;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Gagal memuat gambar: " + ex.Message);
                return new Label { Text = "Gambar tidak dapat dimuat." };
            }
        }
    }
}
