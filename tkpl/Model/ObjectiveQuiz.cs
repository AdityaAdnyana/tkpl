namespace tkpl.Model
{
    internal class ObjectiveQuiz<T> : Question<T>
    {
        public List<T> Options { get; set; } = new List<T>();

        public List<string> GetStringOptions()
        {
            List<string> strOptions = new List<string>();
            foreach (var opt in Options)
            {
                if (opt != null)
                {
                    strOptions.Add(opt.ToString());
                }
                else
                {
                    strOptions.Add("");
                }
            }
            return strOptions;
        }
    }
}
