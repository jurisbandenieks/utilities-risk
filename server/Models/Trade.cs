namespace Api.Models;

public class Trade
{
    public Guid Id { get; set; }
    public string Commodity { get; set; } = string.Empty;
    public TradeDirection Direction { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public string Counterparty { get; set; } = string.Empty;
    public TradeStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
