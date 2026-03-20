using Api.Data;
using Api.Dtos;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TradesController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] TradeStatus? status)
    {
        var query = db.Trades.AsQueryable();
        if (status.HasValue)
            query = query.Where(t => t.Status == status.Value);

        var trades = await query
            .OrderByDescending(t => t.CreatedAt)
            .Select(t => Map(t))
            .ToListAsync();

        return Ok(trades);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var trade = await db.Trades.FindAsync(id);
        return trade is null ? NotFound() : Ok(Map(trade));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTradeRequest req)
    {
        var trade = new Trade
        {
            Id = Guid.NewGuid(),
            Commodity = req.Commodity,
            Direction = req.Direction,
            Quantity = req.Quantity,
            Price = req.Price,
            Counterparty = req.Counterparty,
            Status = TradeStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };

        db.Trades.Add(trade);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = trade.Id }, Map(trade));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateTradeRequest req)
    {
        var trade = await db.Trades.FindAsync(id);
        if (trade is null) return NotFound();

        trade.Commodity = req.Commodity;
        trade.Direction = req.Direction;
        trade.Quantity = req.Quantity;
        trade.Price = req.Price;
        trade.Counterparty = req.Counterparty;
        trade.UpdatedAt = DateTime.UtcNow;

        await db.SaveChangesAsync();
        return Ok(Map(trade));
    }

    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> UpdateStatus(Guid id, UpdateTradeStatusRequest req)
    {
        var trade = await db.Trades.FindAsync(id);
        if (trade is null) return NotFound();

        trade.Status = req.Status;
        trade.UpdatedAt = DateTime.UtcNow;

        await db.SaveChangesAsync();
        return Ok(Map(trade));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var trade = await db.Trades.FindAsync(id);
        if (trade is null) return NotFound();

        db.Trades.Remove(trade);
        await db.SaveChangesAsync();
        return NoContent();
    }

    private static TradeResponse Map(Trade t) =>
        new(t.Id, t.Commodity, t.Direction, t.Quantity, t.Price, t.Counterparty, t.Status, t.CreatedAt, t.UpdatedAt);
}
