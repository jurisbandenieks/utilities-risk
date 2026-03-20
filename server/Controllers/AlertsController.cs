using Api.Data;
using Api.Dtos;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertsController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] AlertStatus? status)
    {
        var query = db.Alerts.AsQueryable();
        if (status.HasValue)
            query = query.Where(a => a.Status == status.Value);

        var alerts = await query
            .OrderByDescending(a => a.CreatedAt)
            .Select(a => Map(a))
            .ToListAsync();

        return Ok(alerts);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var alert = await db.Alerts.FindAsync(id);
        return alert is null ? NotFound() : Ok(Map(alert));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAlertRequest req)
    {
        var alert = new Alert
        {
            Id = Guid.NewGuid(),
            Type = req.Type,
            Message = req.Message,
            Threshold = req.Threshold,
            Status = AlertStatus.Active,
            CreatedAt = DateTime.UtcNow
        };

        db.Alerts.Add(alert);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = alert.Id }, Map(alert));
    }

    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> UpdateStatus(Guid id, UpdateAlertStatusRequest req)
    {
        var alert = await db.Alerts.FindAsync(id);
        if (alert is null) return NotFound();

        alert.Status = req.Status;
        if (req.Status == AlertStatus.Triggered)
            alert.TriggeredAt = DateTime.UtcNow;

        await db.SaveChangesAsync();
        return Ok(Map(alert));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var alert = await db.Alerts.FindAsync(id);
        if (alert is null) return NotFound();

        db.Alerts.Remove(alert);
        await db.SaveChangesAsync();
        return NoContent();
    }

    private static AlertResponse Map(Alert a) =>
        new(a.Id, a.Type, a.Message, a.Threshold, a.Status, a.TriggeredAt, a.CreatedAt);
}
