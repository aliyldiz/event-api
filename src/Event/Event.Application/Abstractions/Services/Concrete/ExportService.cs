using Event.Application.DTOs;

namespace Event.Application.Abstractions.Services.Concrete;

public class ExportService
{
    private readonly ITextService _textService;
    private readonly IFileService _fileService;
    public ExportService(ITextService textService, IFileService fileService)
    {
        _textService = textService;
        _fileService = fileService;
    }
    public async Task ExportEventsAsync(IEnumerable<EventDTO> eventItems, string path)
    {
        var formattedText = _textService.FormatTextFromEvent(eventItems);
        await _fileService.SaveTextAsync(formattedText, path);
    }
}