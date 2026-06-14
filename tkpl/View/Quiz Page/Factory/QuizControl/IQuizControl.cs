using System.Collections.Generic;
using System.Windows.Forms;

namespace tkpl.View.Factory.QuizControl
{
    /// <summary>
    /// Product interface: mendefinisikan operasi yang harus diimplementasikan
    /// oleh semua concrete quiz control products.
    /// </summary>
    public interface IQuizControl
    {
        List<Control> GetControls();
    }
}
