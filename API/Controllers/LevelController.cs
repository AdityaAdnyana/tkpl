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

    // =========================================================================
    // 1. READ (GET ALL) - Mengambil Semua Modul Lengkap dengan Level & Materi
    // =========================================================================
    [HttpGet]
    public async Task<ActionResult> GetAllModules()
    {
        // Menggunakan .Include dan .ThenInclude untuk menarik data berantai dari SQL
        var modules = await _context.Moduls
            .Include(m => m.Lessons)
                .ThenInclude(l => l.Quizzes)
                    .ThenInclude(q => q.EssayQuizzes)
            .Include(m => m.Lessons)
                .ThenInclude(l => l.Quizzes)
                    .ThenInclude(q => q.ObjectiveQuizzes)
                        .ThenInclude(oq => oq.Options)
            .Include(m => m.Lessons)
                .ThenInclude(l => l.Quizzes)
                    .ThenInclude(q => q.QuizImages)
            .Include(m => m.ReadingMaterials)
                .ThenInclude(r => r.Images)
            .ToListAsync();

        return Ok(modules);
    }

    // =========================================================================
    // 2. READ (GET BY ID) - Mengambil Satu Modul Spesifik Berdasarkan ID
    // =========================================================================
    [HttpGet("{id}")]
    public async Task<ActionResult> GetModuleById(int id)
    {
        var module = await _context.Moduls
            .Include(m => m.Lessons)
            .Include(m => m.ReadingMaterials)
            .FirstOrDefaultAsync(m => m.Module_ID == id);

        if (module == null)
        {
            return NotFound($"Modul dengan ID {id} tidak ditemukan.");
        }

        return Ok(module);
    }

    // =========================================================================
    // 3. CREATE (POST) - Menambahkan Modul Baru (Bisa Sepaket dengan Level)
    // =========================================================================
    [HttpPost]
    public async Task<ActionResult> AddModule(ModuleModels newModule)
    {
        if (newModule == null)
        {
            return BadRequest("Data modul tidak valid.");
        }

        _context.Moduls.Add(newModule);
        await _context.SaveChangesAsync(); // Menyimpan data murni ke MySQL

        return Ok(new { message = "Modul baru berhasil disimpan ke database SQL!", data = newModule });
    }

    // =========================================================================
    // 4. UPDATE (PUT) - Memperbarui Nama Modul Berdasarkan ID
    // =========================================================================
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateModule(int id, ModuleModels updatedModule)
    {
        var existingModule = await _context.Moduls.FindAsync(id);
        if (existingModule == null)
        {
            return NotFound($"Gagal update. Modul dengan ID {id} tidak ditemukan.");
        }

        // Memperbarui nilai properti nama modul
        existingModule.module_name = updatedModule.module_name;

        _context.Moduls.Update(existingModule);
        await _context.SaveChangesAsync();

        return Ok($"Modul dengan ID {id} berhasil diperbarui di database.");
    }

    // =========================================================================
    // 5. DELETE (DELETE) - Menghapus Modul Berdasarkan ID
    // =========================================================================
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteModule(int id)
    {
        var module = await _context.Moduls
            .Include(m => m.ReadingMaterials)
            .Include(m => m.Lessons)
                .ThenInclude(l => l.Quizzes)
            .FirstOrDefaultAsync(m => m.Module_ID == id);

        if (module == null)
        {
            return NotFound($"Gagal hapus. Modul dengan ID {id} tidak ditemukan.");
        }

        if (module.ReadingMaterials != null && module.ReadingMaterials.Count > 0)
        {
            _context.ReadingMaterials.RemoveRange(module.ReadingMaterials);
        }

        if (module.Lessons != null && module.Lessons.Count > 0)
        {
            foreach (var lesson in module.Lessons)
            {
                if (lesson.Quizzes != null && lesson.Quizzes.Count > 0)
                {
                    _context.Quizzes.RemoveRange(lesson.Quizzes);
                }
            }

            _context.Lessons.RemoveRange(module.Lessons);
        }

        _context.Moduls.Remove(module);

        await _context.SaveChangesAsync();

        return Ok($"Modul '{module.module_name}' (ID: {id}) beserta seluruh bab, materi, dan kuis di dalamnya berhasil dihapus.");
    }

    // READ (GET ALL) - Mengambil Data Level Module Detail
    [HttpGet("LevelModuleDetail")]
    public async Task<ActionResult> GetLevelModuleDetails()
    {
        var details = await _context.LevelModuleDetails.ToListAsync();
        return Ok(details);
    }
}