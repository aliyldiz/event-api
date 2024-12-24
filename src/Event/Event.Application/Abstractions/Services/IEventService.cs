using Event.Application.DTOs;
using Event.Application.RequestParameters;

namespace Event.Application.Abstractions.Services;

public interface IEventService
{
    Task CreateEventAsync(CreateEventDTO createEventDTO);
    Task<IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination);
}