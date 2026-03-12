namespace Domain.Models;

public class DomainEvent
{
    public int Id { get; set; }
    public string EventType { get; set; }
    public int AggregateId { get; set; }
    public string Payload { get; set; }
    public bool Processed { get; set; }
    public DateTime CreatedAt { get; set; }
}