namespace Api.Models;

public class Alert
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public decimal Threshold { get; set; }
    public AlertStatus Status { get; set; }
    public DateTime? TriggeredAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
