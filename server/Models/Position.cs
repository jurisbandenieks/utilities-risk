namespace Api.Models;

public class Position
{
    public Guid Id { get; set; }
    public string Commodity { get; set; } = string.Empty;
    public decimal NetQuantity { get; set; }
    public decimal AveragePrice { get; set; }
    public decimal MarkToMarketValue { get; set; }
    public DateTime LastUpdated { get; set; }
}
