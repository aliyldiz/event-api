using Event.Domain.Common;
using Event.Domain.ValueObjects;

namespace Event.Domain.Entities;

public class Event : EntityBase
{
    public string Title { get; set; }
    public DateTimeOffset Date { get; set; }
    public Location Location { get; set; }
}