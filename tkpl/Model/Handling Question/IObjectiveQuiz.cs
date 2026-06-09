using System.Collections.Generic;

namespace tkpl.Model
{
    // Mewarisi IQuestion dan menambahkan jaminan ketersediaan metode GetStringOptions
    public interface IObjectiveQuiz : IQuestion
    {
        List<string> GetStringOptions();
    }
}