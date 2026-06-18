using API.Controllers;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

 
    public class LoginRequest
    {
        public string User_Name { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllUsers()
    {
        var users = await _context.Users
            .Select(u => new { u.User_ID, u.User_Name, u.Current_Level_ID })
            .ToListAsync();
        return Ok(users);
    }

   
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.User_Name) || string.IsNullOrWhiteSpace(request.password))
        {
            return BadRequest(new { message = "Username dan password tidak boleh kosong." });
        }

        // Cek apakah username sudah ada
        bool usernameExists = await _context.Users.AnyAsync(u => u.User_Name == request.User_Name);
        if (usernameExists)
        {
            return Conflict(new { message = "Username sudah digunakan. Silakan pilih username lain." });
        }

        var newUser = new UserModels
        {
            User_Name = request.User_Name,
            password = request.password,
            Current_Level_ID = null
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Registrasi berhasil!", user_id = newUser.User_ID, user_name = newUser.User_Name });
    }

   
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.User_Name) || string.IsNullOrWhiteSpace(request.password))
        {
            return BadRequest(new { message = "Username dan password tidak boleh kosong." });
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.User_Name == request.User_Name && u.password == request.password);

        if (user == null)
        {
            return Unauthorized(new { message = "Username atau password salah." });
        }

        return Ok(new
        {
            user_id = user.User_ID,
            user_name = user.User_Name,
            current_level_id = user.Current_Level_ID
        });
    }

    [HttpPut("{id}/level")]
    public async Task<ActionResult> UpdateUserLevel(int id, [FromBody] int newLevelId)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound(new { message = $"User dengan ID {id} tidak ditemukan." });
        }

        user.Current_Level_ID = newLevelId;
        await _context.SaveChangesAsync();

        return Ok(new { message = $"Level user berhasil diperbarui menjadi {newLevelId}." });
    }
}
