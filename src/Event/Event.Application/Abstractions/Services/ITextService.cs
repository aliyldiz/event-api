using Event.Application.DTOs;

namespace Event.Application.Abstractions.Services;

public interface ITextService
{
    string FormatTextFromEvent(IEnumerable<EventDTO> eventItems);
}