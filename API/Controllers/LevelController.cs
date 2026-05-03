using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class LevelController : Controller
{
    // ======================================
    // ============= CRUD Modul =============

    [HttpGet]
    public ActionResult<Module[]> GetAllModules()
    {
        return Ok(RepoLevel.MasterTable);
    }

    [HttpPost]
    public ActionResult AddModule(Module newModule)
    {
        RepoLevel.MasterTable.Add(newModule);
        return Ok("Modul berhasil ditambahkan!");
    }



    [HttpPut("{id}")]
    public ActionResult UpdateModule(int id, Module updatedModule)
    {
        if (id < 0 || id >= RepoLevel.MasterTable.Count)
        {
            return NotFound("Indeks modul tidak ditemukan");
        }

        RepoLevel.MasterTable[id] = updatedModule;
        return Ok($"Modul pada indeks {id} berhasil diupdate");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteModule(int id)
    {
        if (id < 0 || id >= RepoLevel.MasterTable.Count)
        {
            return NotFound("Indeks tidak valid");
        }

        RepoLevel.MasterTable.RemoveAt(id);
        return Ok("Modul berhasil dihapus");
    }

    // =======================================
    // ============= CRUD Lesson =============

    [HttpGet("{ModulId}/lessons/{LessonId}")]
    public ActionResult<Lesson> GetLesson(int modulId, int lessonId)
    {
        if (modulId < RepoLevel.MasterTable.Count &&
            lessonId < RepoLevel.MasterTable[modulId].Lessons.Count)
        {
            return Ok(RepoLevel.MasterTable[modulId].Lessons[lessonId]);
        }
        return NotFound();
    }

    [HttpPost("{modId}/lessons")]
    public ActionResult AddLesson(int modId, [FromBody] Lesson newLesson)
    {
        if (modId < 0 || modId >= RepoLevel.MasterTable.Count)
            return NotFound("Modul tidak ditemukan");

        RepoLevel.MasterTable[modId].Lessons.Add(newLesson);
        return Ok($"Materi '{newLesson.Title}' berhasil ditambahkan ke modul {RepoLevel.MasterTable[modId].ModuleName}");
    }

    [HttpPut("{modId}/lessons/{lessId}")]
    public ActionResult UpdateLesson(int modId, int lessId, [FromBody] Lesson updatedLesson)
    {
        if (modId < 0 || modId >= RepoLevel.MasterTable.Count)
            return NotFound("Modul tidak ditemukan");

        var lessons = RepoLevel.MasterTable[modId].Lessons;
        if (lessId < 0 || lessId >= lessons.Count)
            return NotFound("Materi tidak ditemukan");

        lessons[lessId] = updatedLesson;
    return Ok("Materi berhasil diperbarui.");
    }

    [HttpDelete("{modId}/lessons/{lessId}")]
    public ActionResult DeleteLesson(int modId, int lessId)
    {
        if (modId < 0 || modId  >= RepoLevel.MasterTable.Count)
            return NotFound("Modul tidak ditemukan");

        var lessons = RepoLevel.MasterTable[modId].Lessons;
        if (lessId < 0 || lessId >= lessons.Count)
            return NotFound("Materi tidak ditemukan");

        var deletedTitle = lessons[lessId].Title;
    lessons.RemoveAt(lessId);
    return Ok($"Materi '{deletedTitle}' berhasil dihapus.");
    }

    // =======================================
}