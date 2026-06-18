using API.Controllers;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static API.Model.ReadingMaterial;

[ApiController]
public class ReadingMaterialController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReadingMaterialController(AppDbContext context)
    {
        _context = context;
    }

    // reading_material — Ambil semua materi bacaan beserta gambarnya
    [HttpGet("reading_material")]
    public async Task<ActionResult> GetAllReadingMaterials()
    {
        var materials = await _context.ReadingMaterials
            .Include(r => r.Images)
            .Select(r => new
            {
                Reading_Material_ID = r.Reading_Material_ID,
                Module_ID = r.Module_ID,
                title = r.Title,
                string_material = r.String_Material,
                Images = r.Images.Select(i => new
                {
                    Reading_Material_Image_ID = i.Reading_Material_Image_ID,
                    Reading_Material_ID = i.Reading_Material_ID,
                    image_url = i.Image_Url
                }).ToList()
            })
            .ToListAsync();

        return Ok(materials);
    }

    // reading_material — Ambil satu materi bacaan berdasarkan ID
    [HttpGet("reading_material/{id}")]
    public async Task<ActionResult> GetReadingMaterialById(int id)
    {
        var material = await _context.ReadingMaterials
            .Include(r => r.Images)
            .Where(r => r.Reading_Material_ID == id)
            .Select(r => new
            {
                Reading_Material_ID = r.Reading_Material_ID,
                Module_ID = r.Module_ID,
                title = r.Title,
                string_material = r.String_Material,
                Images = r.Images.Select(i => new
                {
                    Reading_Material_Image_ID = i.Reading_Material_Image_ID,
                    Reading_Material_ID = i.Reading_Material_ID,
                    image_url = i.Image_Url
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (material == null)
        {
            return NotFound(new { message = $"Materi dengan ID {id} tidak ditemukan." });
        }

        return Ok(material);
    }

    // reading_material_image — Ambil semua gambar materi bacaan
    [HttpGet("reading_material_image")]
    public async Task<ActionResult> GetAllReadingMaterialImages()
    {
        var images = await _context.ReadingMaterialImages
            .Select(i => new
            {
                Reading_Material_Image_ID = i.Reading_Material_Image_ID,
                Reading_Material_ID = i.Reading_Material_ID,
                image_url = i.Image_Url
            })
            .ToListAsync();

        return Ok(images);
    }
}
