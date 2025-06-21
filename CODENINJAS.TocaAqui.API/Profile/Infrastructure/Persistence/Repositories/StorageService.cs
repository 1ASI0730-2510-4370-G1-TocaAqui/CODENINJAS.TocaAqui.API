using CODENINJAS.TocaAqui.API.Profile.Domain.Repositories;

namespace CODENINJAS.TocaAqui.API.Profile.Infrastructure.Persistence.Repositories;

public class StorageService : IStorageService
{
    private readonly string _basePath;

    public StorageService(IWebHostEnvironment env)
    {
        _basePath = Path.Combine(env.WebRootPath, "uploads");
        Directory.CreateDirectory(_basePath);
    }

    public async Task<string> UploadFileAsync(byte[] fileBytes, string fileName, string contentType)
    {
        var fullPath = Path.Combine(_basePath, fileName);

        await File.WriteAllBytesAsync(fullPath, fileBytes);

        return $"/uploads/{fileName}";
    }

    public async Task DeleteFileAsync(string fileUrl)
    {
        var fileName = Path.GetFileName(fileUrl);
        var path = Path.Combine(_basePath, fileName);

        if (File.Exists(path))
        {
            await Task.Run(() => File.Delete(path));
        }
    }
}
