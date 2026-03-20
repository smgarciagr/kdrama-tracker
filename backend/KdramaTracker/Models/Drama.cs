namespace KdramaTracker.Models;

public class Drama
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? OriginalTitle { get; set; }
    public int? Year { get; set; }
    public string Genre { get; set; } = string.Empty;
    public int Episodes { get; set; }
    public string Status { get; set; } = "PorVer"; // PorVer | Viendo | Terminado
    public int? Rating { get; set; }               // 1–10
    public string? Review { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
