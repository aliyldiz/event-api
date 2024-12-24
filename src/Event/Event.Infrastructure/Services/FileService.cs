using Event.Application.Abstractions.Services;

namespace Event.Infrastructure.Services;

public class FileService : IFileService
{
    public async Task SaveTextAsync(string text, string path)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            await File.WriteAllTextAsync(text, text);       
        }
        catch (Exception e)
        {
            System.Console.WriteLine($"An error occured while saving the file. Error: {e.Message}");
        }
    }
}