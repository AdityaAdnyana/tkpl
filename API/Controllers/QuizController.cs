using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static API.Model.QuizModel;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : Controller
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> AddQuiz(QuizModels newQuiz)
        {
            if (newQuiz == null)
            {
                return BadRequest("Data kuis tidak valid.");
            }

            _context.Quizzes.Add(newQuiz);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Kuis baru berhasil disimpan ke database SQL!", data = newQuiz });
        }
    }
}
