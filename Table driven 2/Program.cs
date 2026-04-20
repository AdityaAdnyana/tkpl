public class Program
{
    public static void Main()
    {
        LogicLevel Level = new LogicLevel();

        Level.DisplayStatus();

        // Simulasi Alur
        Level.ProcessAnswer("const");
        Level.ProcessAnswer("salah");

        // Tiap class udah ada command isi penjelasan masing-masing untuk setiap method/fungsi,
        // jadi tinggal panggil aja sesuai kebutuhan.
        // sama untuk mempermudah waktu merge code

        // Code nya masih sementara belum 100% fix jadi ntar bisa aja berubah 
        // apalagi masih belum nyambungin ke MySQl
    }
}