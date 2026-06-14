using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static API.Model.ReadingMaterial;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizImageController : Controller
    {
        private readonly AppDbContext _context;

        public QuizImageController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL - Mengambil semua data gambar kuis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizImageModels>>> GetAllImages()
        {
            var images = await _context.QuizImages.ToListAsync();
            return Ok(images);
        }

        // GET BY ID - Mengambil satu gambar kuis spesifik
        [HttpGet("{id}")]
        public async Task<ActionResult<QuizImageModels>> GetImageById(int id)
        {
            var image = await _context.QuizImages.FindAsync(id);

            if (image == null)
            {
                return NotFound($"Gambar dengan ID {id} tidak ditemukan.");
            }

            return Ok(image);
        }

        // GET BY QUIZ ID - Mengambil semua gambar yang menempel pada satu kuis tertentu
        [HttpGet("quiz/{quizId}")]
        public async Task<ActionResult<IEnumerable<QuizImageModels>>> GetImagesByQuizId(int quizId)
        {
            var images = await _context.QuizImages
                .Where(qi => qi.Quiz_ID == quizId)
                .ToListAsync();

            return Ok(images);
        }

        // CREATE (POST) - Menyimpan URL gambar diagram/rumus baru
        [HttpPost]
        public async Task<ActionResult> AddQuizImage(QuizImageModels newImage)
        {
            if (newImage == null)
            {
                return BadRequest("Data gambar tidak valid.");
            }

            _context.QuizImages.Add(newImage);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Gambar diagram/rumus berhasil disimpan!", data = newImage });
        }

        // UPDATE (PUT) - Memperbarui URL gambar berdasarkan ID
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateQuizImage(int id, QuizImageModels updatedImage)
        {
            var existingImage = await _context.QuizImages.FindAsync(id);
            if (existingImage == null)
            {
                return NotFound($"Gagal update. Gambar dengan ID {id} tidak ditemukan.");
            }

            existingImage.Image_Url = updatedImage.Image_Url;
            existingImage.Quiz_ID = updatedImage.Quiz_ID;

            _context.QuizImages.Update(existingImage);
            await _context.SaveChangesAsync();

            return Ok($"Gambar dengan ID {id} berhasil diperbarui.");
        }

        // DELETE - Menghapus data gambar dari database
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuizImage(int id)
        {
            var image = await _context.QuizImages.FindAsync(id);
            if (image == null)
            {
                return NotFound($"Gagal hapus. Gambar dengan ID {id} tidak ditemukan.");
            }

            _context.QuizImages.Remove(image);
            await _context.SaveChangesAsync();

            return Ok($"Gambar dengan ID {id} berhasil dihapus dari database.");
        }
    }
}