using Microsoft.AspNetCore.Http;

namespace Core.Interfaces;

public interface IFilesService
{
    Task<string> SaveImage(IFormFile file);
    Task<string> EditImage(IFormFile newFile, string? oldPath);
    Task DeleteImage(string path);
}
