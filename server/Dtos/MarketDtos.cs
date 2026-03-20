using Api.Models;

namespace Api.Dtos;

public record CreateMarketTickRequest(
    string Commodity,
    decimal Price,
    decimal ChangePercent,
    decimal Volume,
    MarketStatus Status);

public record MarketSummaryResponse(
    string Commodity,
    decimal Price,
    decimal ChangePercent,
    decimal Volume,
    MarketStatus Status,
    DateTime Timestamp);
