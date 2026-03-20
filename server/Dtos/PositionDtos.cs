namespace Api.Dtos;

public record CreatePositionRequest(
    string Commodity,
    decimal NetQuantity,
    decimal AveragePrice,
    decimal MarkToMarketValue);

public record UpdatePositionRequest(
    decimal NetQuantity,
    decimal AveragePrice,
    decimal MarkToMarketValue);

public record PositionResponse(
    Guid Id,
    string Commodity,
    decimal NetQuantity,
    decimal AveragePrice,
    decimal MarkToMarketValue,
    DateTime LastUpdated);
