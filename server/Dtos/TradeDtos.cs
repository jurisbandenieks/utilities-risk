using Api.Models;

namespace Api.Dtos;

public record CreateTradeRequest(
    string Commodity,
    TradeDirection Direction,
    decimal Quantity,
    decimal Price,
    string Counterparty);

public record UpdateTradeRequest(
    string Commodity,
    TradeDirection Direction,
    decimal Quantity,
    decimal Price,
    string Counterparty);

public record UpdateTradeStatusRequest(TradeStatus Status);

public record TradeResponse(
    Guid Id,
    string Commodity,
    TradeDirection Direction,
    decimal Quantity,
    decimal Price,
    string Counterparty,
    TradeStatus Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
