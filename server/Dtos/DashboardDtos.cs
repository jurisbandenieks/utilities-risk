namespace Api.Dtos;

public record DashboardSummaryResponse(
    int TotalPositions,
    int ActiveTrades,
    decimal RiskExposure,
    decimal PortfolioPnl);
