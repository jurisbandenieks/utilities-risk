using Api.Data;
using Api.Dtos;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSummary()
    {
        var totalPositions = await db.Positions.CountAsync();
        var activeTrades = await db.Trades.CountAsync(t => t.Status == TradeStatus.Confirmed);
        var riskExposure = await db.RiskMetrics.SumAsync(r => r.Value);
        var portfolioPnl = await db.Positions.SumAsync(p => p.MarkToMarketValue);

        return Ok(new DashboardSummaryResponse(totalPositions, activeTrades, riskExposure, portfolioPnl));
    }
}
