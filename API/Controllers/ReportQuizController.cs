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
        public int Level_ID { get; set; }
        public string User_Answer { get; set; } = string.Empty;
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
                r.User_Answer
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
            Level_ID = request.Level_ID,
            User_Answer = request.User_Answer
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
            Level_ID = r.Level_ID,
            User_Answer = r.User_Answer
        }).ToList();

        _context.ReportQuizzes.AddRange(newReports);
        await _context.SaveChangesAsync();

        return Ok(new { message = $"{newReports.Count} report berhasil disimpan ke database." });
    }
}
