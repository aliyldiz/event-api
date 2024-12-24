using Event.Application.Abstractions.Services;
using Event.Application.DTOs;
using Event.Application.RequestParameters;
using Event.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Event.Persistence.Services;

public class EventService : IEventService
{
    private readonly ApplicationDbContext _context;
    public EventService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task CreateEventAsync(CreateEventDTO createEventDTO)
    {
        if (createEventDTO is not null)
        {
            var newEvent = new Domain.Entities.Event
            {
                Title = createEventDTO.Title,
                Date = createEventDTO.Date,
                Location = createEventDTO.Location
            };
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
        }
        else
            throw new NullReferenceException();
    }
    public async Task<IEnumerable<EventDTO>> GetAllEventsAsync(Pagination pagination)
    {
        return await _context.Events
            .AsNoTracking()
            .Select(e => new EventDTO
            {
                Title = e.Title,
                Date = e.Date,
                Location = e.Location
            })
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();
    }
}