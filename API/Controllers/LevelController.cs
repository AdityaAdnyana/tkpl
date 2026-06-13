using API.Controllers;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class LevelController : Controller
{
    private readonly AppDbContext _context;

    public LevelController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllModules()
    {
        var modules = await _context.Moduls.Include(m => m.Lessons).ToListAsync();
        return Ok(modules);
    }

    // 2. POST ADD NEW MODULE KE DATABASE SQL
    [HttpPost]
    public async Task<ActionResult> AddModule(ModuleModels newModule)
    {
        _context.Moduls.Add(newModule);
        await _context.SaveChangesAsync(); // Menyimpan perubahan ke SQL asli
        return Ok("Modul baru berhasil disimpan ke database SQL!");
    }

    //// ======================================
    //// ============= CRUD Modul =============

    //[HttpGet]
    //public ActionResult<Module[]> GetAllModules()
    //{
    //    return Ok(RepoLevel.MasterTable);
    //}

    //[HttpPost]
    //public ActionResult AddModule(Module newModule)
    //{
    //    RepoLevel.MasterTable.Add(newModule);
    //    return Ok("Modul berhasil ditambahkan!");
    //}

    //[HttpPut("{id}")]
    //public ActionResult UpdateModule(int id, Module updatedModule)
    //{
    //    if (id < 0 || id >= RepoLevel.MasterTable.Count)
    //    {
    //        return NotFound("Indeks modul tidak ditemukan");
    //    }

    //    RepoLevel.MasterTable[id] = updatedModule;
    //    return Ok($"Modul pada indeks {id} berhasil diupdate");
    //}

    //[HttpDelete("{id}")]
    //public ActionResult DeleteModule(int id)
    //{
    //    if (id < 0 || id >= RepoLevel.MasterTable.Count)
    //    {
    //        return NotFound("Indeks tidak valid");
    //    }

    //    RepoLevel.MasterTable.RemoveAt(id);
    //    return Ok("Modul berhasil dihapus");
    //}

    //// =======================================
    //// ============= CRUD Lesson =============

    //[HttpGet("{ModulId}/lessons")]
    //public ActionResult<Lesson> GetAllLesson(int modulId)
    //{
    //    if (modulId < RepoLevel.MasterTable.Count)
    //    {
    //        return Ok(RepoLevel.MasterTable[modulId].ReadOnlyLessons);
    //    }
    //    return NotFound();
    //}

    //[HttpGet("{ModulId}/lessons/{LessonId}")]
    //public ActionResult<Lesson> GetLesson(int modulId, int lessonId)
    //{
    //    if (modulId < RepoLevel.MasterTable.Count &&
    //        lessonId < RepoLevel.MasterTable[modulId].ReadOnlyLessons.Count)
    //    {
    //        return Ok(RepoLevel.MasterTable[modulId].ReadOnlyLessons[lessonId]);
    //    }
    //    return NotFound();
    //}

    //[HttpPost("{modId}/lessons")]
    //public ActionResult AddLesson(int modId, [FromBody] Lesson newLesson)
    //{
    //    if (modId < 0 || modId >= RepoLevel.MasterTable.Count)
    //        return NotFound("Modul tidak ditemukan");

    //    RepoLevel.MasterTable[modId].AddNewLesson(newLesson);

    //    return Ok($"Materi '{newLesson.Title}' berhasil ditambahkan ke modul {RepoLevel.MasterTable[modId].ModuleName}");
    //}

    //[HttpPut("{modId}/lessons/{lessId}")]
    //public ActionResult UpdateLesson(int modId, int lessId, [FromBody] Lesson updatedLesson)
    //{
    //    if (modId < 0 || modId >= RepoLevel.MasterTable.Count)
    //        return NotFound("Modul tidak ditemukan");

    //    bool isSuccess = RepoLevel.MasterTable[modId].UpdateExistingLesson(lessId, updatedLesson);

    //    if (!isSuccess)
    //        return NotFound("Materi tidak ditemukan");

    //    return Ok("Materi berhasil diperbarui.");
    //}

    //[HttpDelete("{modId}/lessons/{lessId}")]
    //public ActionResult DeleteLesson(int modId, int lessId)
    //{
    //    if (modId < 0 || modId >= RepoLevel.MasterTable.Count)
    //        return NotFound("Modul tidak ditemukan");

    //    string deletedTitle = RepoLevel.MasterTable[modId].DeleteExistingLesson(lessId);

    //    if (deletedTitle == null)
    //        return NotFound("Materi tidak ditemukan");

    //    return Ok($"Materi '{deletedTitle}' berhasil dihapus.");
    //}

    // =======================================
}