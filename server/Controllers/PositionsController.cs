using Api.Data;
using Api.Dtos;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionsController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var positions = await db.Positions
            .OrderBy(p => p.Commodity)
            .Select(p => Map(p))
            .ToListAsync();

        return Ok(positions);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var position = await db.Positions.FindAsync(id);
        return position is null ? NotFound() : Ok(Map(position));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePositionRequest req)
    {
        var position = new Position
        {
            Id = Guid.NewGuid(),
            Commodity = req.Commodity,
            NetQuantity = req.NetQuantity,
            AveragePrice = req.AveragePrice,
            MarkToMarketValue = req.MarkToMarketValue,
            LastUpdated = DateTime.UtcNow
        };

        db.Positions.Add(position);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = position.Id }, Map(position));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdatePositionRequest req)
    {
        var position = await db.Positions.FindAsync(id);
        if (position is null) return NotFound();

        position.NetQuantity = req.NetQuantity;
        position.AveragePrice = req.AveragePrice;
        position.MarkToMarketValue = req.MarkToMarketValue;
        position.LastUpdated = DateTime.UtcNow;

        await db.SaveChangesAsync();
        return Ok(Map(position));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var position = await db.Positions.FindAsync(id);
        if (position is null) return NotFound();

        db.Positions.Remove(position);
        await db.SaveChangesAsync();
        return NoContent();
    }

    private static PositionResponse Map(Position p) =>
        new(p.Id, p.Commodity, p.NetQuantity, p.AveragePrice, p.MarkToMarketValue, p.LastUpdated);
}
