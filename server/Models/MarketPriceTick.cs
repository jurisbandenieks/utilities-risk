namespace Api.Models;

public class MarketPriceTick
{
    public Guid Id { get; set; }
    public string Commodity { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal ChangePercent { get; set; }
    public decimal Volume { get; set; }
    public MarketStatus Status { get; set; }
    public DateTime Timestamp { get; set; }
}
