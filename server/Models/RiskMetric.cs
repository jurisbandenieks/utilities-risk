namespace Api.Models;

public class RiskMetric
{
    public Guid Id { get; set; }
    public string Label { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public decimal Limit { get; set; }
    public decimal Utilization { get; set; }
    public RiskSeverity Severity { get; set; }
    public DateTime CalculatedAt { get; set; }
}
