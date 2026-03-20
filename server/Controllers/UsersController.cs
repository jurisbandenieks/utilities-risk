using Api.Data;
using Api.Dtos;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] UserRole? role, [FromQuery] UserStatus? status)
    {
        var query = db.Users.AsQueryable();
        if (role.HasValue) query = query.Where(u => u.Role == role.Value);
        if (status.HasValue) query = query.Where(u => u.Status == status.Value);

        var users = await query
            .OrderBy(u => u.Name)
            .Select(u => Map(u))
            .ToListAsync();

        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await db.Users.FindAsync(id);
        return user is null ? NotFound() : Ok(Map(user));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest req)
    {
        if (await db.Users.AnyAsync(u => u.Email == req.Email))
            return Conflict(new { message = "Email already in use." });

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = req.Name,
            Email = req.Email,
            Role = req.Role,
            Status = UserStatus.Active,
            CreatedAt = DateTime.UtcNow
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, Map(user));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateUserRequest req)
    {
        var user = await db.Users.FindAsync(id);
        if (user is null) return NotFound();

        if (await db.Users.AnyAsync(u => u.Email == req.Email && u.Id != id))
            return Conflict(new { message = "Email already in use." });

        user.Name = req.Name;
        user.Email = req.Email;
        user.Role = req.Role;
        user.Status = req.Status;

        await db.SaveChangesAsync();
        return Ok(Map(user));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await db.Users.FindAsync(id);
        if (user is null) return NotFound();

        db.Users.Remove(user);
        await db.SaveChangesAsync();
        return NoContent();
    }

    private static UserResponse Map(User u) =>
        new(u.Id, u.Name, u.Email, u.Role, u.Status, u.CreatedAt);
}
