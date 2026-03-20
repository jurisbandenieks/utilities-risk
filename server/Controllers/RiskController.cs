using Api.Data;
using Api.Dtos;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RiskController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] RiskSeverity? severity)
    {
        var query = db.RiskMetrics.AsQueryable();
        if (severity.HasValue)
            query = query.Where(r => r.Severity == severity.Value);

        var metrics = await query
            .OrderByDescending(r => r.Utilization)
            .Select(r => Map(r))
            .ToListAsync();

        return Ok(metrics);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var metric = await db.RiskMetrics.FindAsync(id);
        return metric is null ? NotFound() : Ok(Map(metric));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRiskMetricRequest req)
    {
        var utilization = req.Limit > 0 ? Math.Round(req.Value / req.Limit * 100, 2) : 0;
        var severity = utilization >= 90 ? RiskSeverity.High
                     : utilization >= 70 ? RiskSeverity.Medium
                     : RiskSeverity.Low;

        var metric = new RiskMetric
        {
            Id = Guid.NewGuid(),
            Label = req.Label,
            Value = req.Value,
            Limit = req.Limit,
            Utilization = utilization,
            Severity = severity,
            CalculatedAt = DateTime.UtcNow
        };

        db.RiskMetrics.Add(metric);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = metric.Id }, Map(metric));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, CreateRiskMetricRequest req)
    {
        var metric = await db.RiskMetrics.FindAsync(id);
        if (metric is null) return NotFound();

        metric.Label = req.Label;
        metric.Value = req.Value;
        metric.Limit = req.Limit;
        metric.Utilization = req.Limit > 0 ? Math.Round(req.Value / req.Limit * 100, 2) : 0;
        metric.Severity = metric.Utilization >= 90 ? RiskSeverity.High
                        : metric.Utilization >= 70 ? RiskSeverity.Medium
                        : RiskSeverity.Low;
        metric.CalculatedAt = DateTime.UtcNow;

        await db.SaveChangesAsync();
        return Ok(Map(metric));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var metric = await db.RiskMetrics.FindAsync(id);
        if (metric is null) return NotFound();

        db.RiskMetrics.Remove(metric);
        await db.SaveChangesAsync();
        return NoContent();
    }

    private static RiskMetricResponse Map(RiskMetric r) =>
        new(r.Id, r.Label, r.Value, r.Limit, r.Utilization, r.Severity, r.CalculatedAt);
}
