using Microsoft.EntityFrameworkCore;
using KdramaTracker.Models;

namespace KdramaTracker.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Drama> Dramas => Set<Drama>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data con algunos kdramas famosos
        modelBuilder.Entity<Drama>().HasData(
            new Drama { Id = 1, Title = "Crash Landing on You", OriginalTitle = "사랑의 불시착", Year = 2019, Genre = "Romance", Episodes = 16, Status = "Terminado", Rating = 10, Review = "Una obra maestra. La química entre los protagonistas es increíble.", Notes = "Ver con pañuelos a mano", CreatedAt = DateTime.UtcNow },
            new Drama { Id = 2, Title = "Goblin", OriginalTitle = "도깨비", Year = 2016, Genre = "Fantasia", Episodes = 16, Status = "Terminado", Rating = 9, Review = "Hermosa historia de amor y destino.", Notes = "El OST es espectacular", CreatedAt = DateTime.UtcNow },
            new Drama { Id = 3, Title = "My Demon", OriginalTitle = "마이 데몬", Year = 2023, Genre = "Romance", Episodes = 16, Status = "PorVer", Rating = null, Review = null, Notes = "Me lo recomendaron mucho", CreatedAt = DateTime.UtcNow },
            new Drama { Id = 4, Title = "Vincenzo", OriginalTitle = "빈센조", Year = 2021, Genre = "Accion", Episodes = 20, Status = "Viendo", Rating = null, Review = null, Notes = "Voy por el episodio 8, muy bueno", CreatedAt = DateTime.UtcNow }
        );
    }
}
