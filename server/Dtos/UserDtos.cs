using Api.Models;

namespace Api.Dtos;

public record CreateUserRequest(
    string Name,
    string Email,
    UserRole Role);

public record UpdateUserRequest(
    string Name,
    string Email,
    UserRole Role,
    UserStatus Status);

public record UserResponse(
    Guid Id,
    string Name,
    string Email,
    UserRole Role,
    UserStatus Status,
    DateTime CreatedAt);
