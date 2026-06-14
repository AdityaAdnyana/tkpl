using System.Windows.Forms;

namespace tkpl.View.Factory.ImageControl
{
    public abstract class ImageControlCreator
    {
        public abstract Control CreateImageControl(string imagePath);
    }
}
