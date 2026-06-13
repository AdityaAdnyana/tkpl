namespace tkpl.View.Factory.QuizControl
{
    /// <summary>
    /// Creator abstract class: mendeklarasikan factory method yang mengembalikan objek IQuizControl.
    /// Subclass (ConcreteCreator) menyediakan implementasi factory method ini.
    ///
    /// Tanggung jawab utama Creator bukan hanya membuat produk, melainkan
    /// menyediakan business logic (RenderControls) yang bergantung pada objek Product
    /// yang dikembalikan oleh factory method.
    /// </summary>
    public abstract class QuizControlCreator
    {
        /// <summary>
        /// Factory Method: subclass harus meng-override method ini untuk mengembalikan
        /// concrete product yang sesuai. Return type tetap menggunakan abstract product type (IQuizControl).
        /// </summary>
        public abstract IQuizControl FactoryMethod();

        /// <summary>
        /// Business logic utama yang menggunakan factory method untuk membuat
        /// dan menampilkan kontrol quiz ke dalam QuizView.
        /// </summary>
        public void RenderControls(QuizView quizView)
        {
            IQuizControl quizControl = FactoryMethod();

            foreach (var control in quizControl.GetControls())
            {
                quizView.AddControl(control);
            }
        }
    }
}
