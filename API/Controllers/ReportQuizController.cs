using API.Controllers;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static API.Model.QuizModel;

[ApiController]
[Route("[controller]")]
public class ReportQuizController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReportQuizController(AppDbContext context)
    {
        _context = context;
    }

   
    public class ReportQuizRequest
    {
        public int User_ID { get; set; }

        public string? Lesson_Title { get; set; }
        public string? Question_Text { get; set; }
        public string? Correct_Answer { get; set; }
        public string? User_Answer { get; set; }
        public decimal? Score_Weight { get; set; }
        public string? Is_Correct { get; set; }
    }

    // GET /ReportQuiz/{userId} — Ambil semua report kuis milik satu user
    [HttpGet("{userId}")]
    public async Task<ActionResult> GetReportsByUser(int userId)
    {
        var reports = await _context.ReportQuizzes
            .Where(r => r.User_ID == userId)
            .Select(r => new
            {
                r.Report_Quiz_ID,
                r.User_ID,
                r.Quiz_ID,
                r.Level_ID,
                r.Lesson_Title,
                r.Question_Text,
                r.Correct_Answer,
                r.User_Answer,
                r.Score_Weight,
                r.Is_Correct
            })
            .ToListAsync();

        return Ok(reports);
    }

    // POST /ReportQuiz — Simpan satu item report kuis ke database
    [HttpPost]
    public async Task<ActionResult> SaveReport([FromBody] ReportQuizRequest request)
    {
        if (request == null)
        {
            return BadRequest(new { message = "Data report tidak valid." });
        }

        var newReport = new ReportQuizModels
        {
            User_ID = request.User_ID,
            Quiz_ID = null,
            Level_ID = null,
            Lesson_Title = request.Lesson_Title,
            Question_Text = request.Question_Text,
            Correct_Answer = request.Correct_Answer,
            User_Answer = request.User_Answer,
            Score_Weight = request.Score_Weight,
            Is_Correct = request.Is_Correct
        };

        _context.ReportQuizzes.Add(newReport);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Report berhasil disimpan.", report_id = newReport.Report_Quiz_ID });
    }

    // POST /ReportQuiz/batch — Simpan banyak report sekaligus (batch)
    [HttpPost("batch")]
    public async Task<ActionResult> SaveReportsBatch([FromBody] List<ReportQuizRequest> requests)
    {
        if (requests == null || requests.Count == 0)
        {
            return BadRequest(new { message = "Tidak ada data report yang dikirim." });
        }

        var newReports = requests.Select(r => new ReportQuizModels
        {
            User_ID = r.User_ID,
            Quiz_ID = null,
            Level_ID = null,
            Lesson_Title = r.Lesson_Title,
            Question_Text = r.Question_Text,
            Correct_Answer = r.Correct_Answer,
            User_Answer = r.User_Answer,
            Score_Weight = r.Score_Weight,
            Is_Correct = r.Is_Correct
        }).ToList();

        _context.ReportQuizzes.AddRange(newReports);
        await _context.SaveChangesAsync();

        return Ok(new { message = $"{newReports.Count} report berhasil disimpan ke database." });
    }
}
