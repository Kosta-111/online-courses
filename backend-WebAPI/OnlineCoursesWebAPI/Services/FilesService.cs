using Core.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace OnlineCoursesWebAPI.Services;

public class FilesService(IWebHostEnvironment env) : IFilesService
{
    private readonly string folderName = "images";

    private readonly Dictionary<string, int> sizes = new()
    {
        {"small", 30 },
        {"medium", 60 },
        {"large", 1000 }
    };

    public async Task<string> SaveImage(IFormFile file)
    {        
        var name = Guid.NewGuid().ToString();
        var ext = Path.GetExtension(file.FileName);
        var fileName = name + ext;

        using var stream = file.OpenReadStream();
        using Image image = Image.Load(stream);
        await ResizeAndWrite(image, fileName);
        return fileName;
    }

    private async Task ResizeAndWrite(Image image, string fileName)
    {
        var folderPath = Path.Combine(env.WebRootPath, folderName);
        var ratio = (double)image.Width / image.Height;

        foreach (var size in sizes)
        {
            var (height, width) = image.Height > size.Value
                ? (size.Value, (int)(size.Value * ratio))
                : (image.Height, image.Width);

            var fullPath = Path.Combine(folderPath, size.Key, fileName);

            await image.Clone(p => p.Resize(width, height))
                .SaveAsync(fullPath);
        }
    }

    public async Task<string> EditImage(IFormFile newFile, string? oldPath)
    {
        if (oldPath is not null)
            DeleteImage(oldPath);

        return await SaveImage(newFile);
    }

    public void DeleteImage(string path)
    {
        var folderPath = Path.Combine(env.WebRootPath, folderName);
        foreach (var size in sizes)
        {
            var fullPath = Path.Combine(folderPath, size.Key, path);
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
