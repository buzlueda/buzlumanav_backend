using Microsoft.AspNetCore.Http;

namespace BuzluManav.Infrastructure.Infrastructure.FileService;
public interface IFileService
{
    Task<string> UploadFileAsync(IFormFile file);
    Task DeleteFileAsync(string filePath);
}