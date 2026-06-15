using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LevelModuleDetailController : Controller
    {
        private readonly AppDbContext _context;

        public LevelModuleDetailController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LevelModuleDetailModels>>> GetAll()
        {
            return Ok(await _context.LevelModuleDetails.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Create(LevelModuleDetailModels newDetail)
        {
            _context.LevelModuleDetails.Add(newDetail);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Sukses mencatat detail jembatan modul!", data = newDetail });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, LevelModuleDetailModels updatedDetail)
        {
            // Menyesuaikan pencarian menggunakan nama properti Detail_ID sesuai berkas SQL
            var existing = await _context.LevelModuleDetails.FirstOrDefaultAsync(lmd => lmd.Detail_ID == id);
            if (existing == null) return NotFound("Data detail tidak ditemukan.");

            existing.Module_ID = updatedDetail.Module_ID;
            existing.Level_ID = updatedDetail.Level_ID;

            _context.LevelModuleDetails.Update(existing);
            await _context.SaveChangesAsync();
            return Ok("Data relasi berhasil diperbarui.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var detail = await _context.LevelModuleDetails.FirstOrDefaultAsync(lmd => lmd.Detail_ID == id);
            if (detail == null) return NotFound("Data tidak ditemukan.");

            _context.LevelModuleDetails.Remove(detail);
            await _context.SaveChangesAsync();
            return Ok("Data relasi berhasil dihapus.");
        }
    }
}