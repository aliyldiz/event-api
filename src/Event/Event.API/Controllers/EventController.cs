using Event.Application.Abstractions.Services;
using Event.Application.Abstractions.Services.Concrete;
using Event.Application.DTOs;
using Event.Application.RequestParameters;
using Microsoft.AspNetCore.Mvc;

namespace Event.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;
    private readonly ExportService _exportService;
    
    public EventController(IEventService eventService, ExportService exportService)
    {
        _eventService = eventService;
        _exportService = exportService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllEventsAsync([FromQuery] Pagination pagination)
    {
        var events = await _eventService.GetAllEventsAsync(pagination);
        return Ok(events);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEventAsync(CreateEventDTO createEventDTO)
    {
        await _eventService.CreateEventAsync(createEventDTO);
        return Ok();
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> ExportEventsAsync([FromQuery] Pagination pagination, string path)
    {
        var events = await _eventService.GetAllEventsAsync(pagination);
        await _exportService.ExportEventsAsync(events, path);
        return Ok();
    }
}