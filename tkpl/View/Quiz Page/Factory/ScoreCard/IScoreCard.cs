using System.Windows.Forms;

namespace tkpl.View.Factory.ScoreCard
{
    /// <summary>
    /// Product interface: mendefinisikan operasi yang harus diimplementasikan
    /// oleh semua concrete score card products.
    /// </summary>
    public interface IScoreCard
    {
        Panel GetPanel();
    }
}
