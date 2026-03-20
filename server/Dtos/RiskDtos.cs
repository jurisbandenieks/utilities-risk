using Api.Models;

namespace Api.Dtos;

public record CreateRiskMetricRequest(
    string Label,
    decimal Value,
    decimal Limit);

public record RiskMetricResponse(
    Guid Id,
    string Label,
    decimal Value,
    decimal Limit,
    decimal Utilization,
    RiskSeverity Severity,
    DateTime CalculatedAt);
