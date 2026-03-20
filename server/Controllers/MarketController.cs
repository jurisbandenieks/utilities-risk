using Api.Data;
using Api.Dtos;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarketController(AppDbContext db) : ControllerBase
{
    // Returns the latest tick per commodity
    [HttpGet]
    public async Task<IActionResult> GetLatest()
    {
        var latest = await db.MarketPriceTicks
            .GroupBy(m => m.Commodity)
            .Select(g => g.OrderByDescending(m => m.Timestamp).First())
            .Select(m => Map(m))
            .ToListAsync();

        return Ok(latest);
    }

    [HttpGet("{commodity}")]
    public async Task<IActionResult> GetByCommodity(string commodity)
    {
        var tick = await db.MarketPriceTicks
            .Where(m => m.Commodity == commodity)
            .OrderByDescending(m => m.Timestamp)
            .FirstOrDefaultAsync();

        return tick is null ? NotFound() : Ok(Map(tick));
    }

    [HttpGet("{commodity}/history")]
    public async Task<IActionResult> GetHistory(string commodity, [FromQuery] int limit = 50)
    {
        var history = await db.MarketPriceTicks
            .Where(m => m.Commodity == commodity)
            .OrderByDescending(m => m.Timestamp)
            .Take(limit)
            .Select(m => Map(m))
            .ToListAsync();

        return Ok(history);
    }

    [HttpPost("tick")]
    public async Task<IActionResult> AddTick(CreateMarketTickRequest req)
    {
        var tick = new MarketPriceTick
        {
            Id = Guid.NewGuid(),
            Commodity = req.Commodity,
            Price = req.Price,
            ChangePercent = req.ChangePercent,
            Volume = req.Volume,
            Status = req.Status,
            Timestamp = DateTime.UtcNow
        };

        db.MarketPriceTicks.Add(tick);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetByCommodity), new { commodity = tick.Commodity }, Map(tick));
    }

    private static MarketSummaryResponse Map(MarketPriceTick m) =>
        new(m.Commodity, m.Price, m.ChangePercent, m.Volume, m.Status, m.Timestamp);
}
