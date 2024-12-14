using Microsoft.AspNetCore.Http;

namespace Core.Models;

public class CourseModelCreate
{
    public string Name { get; set; } = null!;
    public IFormFile? Image { get; set; }
    public string? Description { get; set; }
    public string Language { get; set; } = null!;
    public decimal Price { get; set; }
    public int Discount { get; set; }
    public double Rating { get; set; }
    public int LevelId { get; set; }
    public int CategoryId { get; set; }
    public bool IsCertificate { get; set; }
}
