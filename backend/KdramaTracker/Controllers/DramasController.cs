using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KdramaTracker.Data;
using KdramaTracker.Models;

namespace KdramaTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DramasController : ControllerBase
{
    private readonly AppDbContext _db;

    public DramasController(AppDbContext db) => _db = db;

    // GET api/dramas?status=Viendo&genre=Romance&search=goblin
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? status,
        [FromQuery] string? genre,
        [FromQuery] string? search)
    {
        var query = _db.Dramas.AsQueryable();

        if (!string.IsNullOrWhiteSpace(status))
            query = query.Where(d => d.Status == status);

        if (!string.IsNullOrWhiteSpace(genre))
            query = query.Where(d => d.Genre == genre);

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(d =>
                d.Title.Contains(search) ||
                (d.OriginalTitle != null && d.OriginalTitle.Contains(search)));

        var dramas = await query.OrderByDescending(d => d.CreatedAt).ToListAsync();
        return Ok(dramas);
    }

    // GET api/dramas/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var drama = await _db.Dramas.FindAsync(id);
        return drama is null ? NotFound() : Ok(drama);
    }

    // POST api/dramas
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Drama drama)
    {
        drama.CreatedAt = DateTime.UtcNow;
        _db.Dramas.Add(drama);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = drama.Id }, drama);
    }

    // PUT api/dramas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Drama drama)
    {
        if (id != drama.Id) return BadRequest();
        drama.UpdatedAt = DateTime.UtcNow;
        _db.Entry(drama).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE api/dramas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var drama = await _db.Dramas.FindAsync(id);
        if (drama is null) return NotFound();
        _db.Dramas.Remove(drama);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // GET api/dramas/genres
    [HttpGet("genres")]
    public async Task<IActionResult> GetGenres()
    {
        var genres = await _db.Dramas.Select(d => d.Genre).Distinct().OrderBy(g => g).ToListAsync();
        return Ok(genres);
    }

    // GET api/dramas/stats
    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var stats = new
        {
            Total      = await _db.Dramas.CountAsync(),
            PorVer     = await _db.Dramas.CountAsync(d => d.Status == "PorVer"),
            Viendo     = await _db.Dramas.CountAsync(d => d.Status == "Viendo"),
            Terminado  = await _db.Dramas.CountAsync(d => d.Status == "Terminado"),
            PromedioRating = await _db.Dramas
                .Where(d => d.Rating != null)
                .AverageAsync(d => (double?)d.Rating) ?? 0
        };
        return Ok(stats);
    }
}
