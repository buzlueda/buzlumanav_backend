using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BuzluManav.Infrastructure.Infrastructure.FileService;
public class FileManager(IConfiguration configuration) : IFileService
{
    private readonly string _uploadFolderPath = configuration["UploadSettings:UploadFolder"]!;
    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file is null || file.Length is 0)
            throw new ArgumentException("File cannot be null or empty");

        var uniqueFileName = GenerateUniqueFileName(file.FileName);
        var filePath = Path.Combine(_uploadFolderPath, uniqueFileName);

        if (!Directory.Exists(_uploadFolderPath))
        {
            Directory.CreateDirectory(_uploadFolderPath);
        }

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var relativePath = $"/uploads/{uniqueFileName}";
        return relativePath;
    }

    public Task DeleteFileAsync(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentException("File path cannot be null or empty");

        var fullPath = Path.Combine(_uploadFolderPath, Path.GetFileName(filePath));

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        return Task.CompletedTask;
    }

    private string GenerateUniqueFileName(string originalFileName)
    {
        var fileExtension = Path.GetExtension(originalFileName);
        var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
        return uniqueFileName;
    }
}
