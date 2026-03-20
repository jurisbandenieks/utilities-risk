using Api.Models;

namespace Api.Dtos;

public record CreateAlertRequest(
    string Type,
    string Message,
    decimal Threshold);

public record UpdateAlertStatusRequest(AlertStatus Status);

public record AlertResponse(
    Guid Id,
    string Type,
    string Message,
    decimal Threshold,
    AlertStatus Status,
    DateTime? TriggeredAt,
    DateTime CreatedAt);
