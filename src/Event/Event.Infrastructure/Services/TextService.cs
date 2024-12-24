using System.Text;
using Event.Application.Abstractions.Services;
using Event.Application.DTOs;

namespace Event.Infrastructure.Services;

public class TextService : ITextService
{
    public string FormatTextFromEvent(IEnumerable<EventDTO> eventItems)
    {
        if (eventItems is null)
            throw new ArgumentNullException(nameof(eventItems));
        StringBuilder sb = new();
        foreach (var eventItem in eventItems)
        {
            if (eventItem is not null)
                sb.AppendLine($"Evet: {eventItem.Title} - Location: {eventItem.Location.City} - Date: {eventItem.Date.ToString("HH:mm - dd/MM/yyyy")}");
        }
        return sb.ToString().TrimEnd();
    }
}