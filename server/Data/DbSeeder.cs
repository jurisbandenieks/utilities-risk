using Api.Models;

namespace Api.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        var now = DateTime.UtcNow;

        if (!db.Users.Any())
        {
            db.Users.AddRange(
                new User { Id = new Guid("a0eebc99-9c0b-4ef8-bb6d-6bb9bd380a11"), Name = "Sarah Mitchell", Email = "smitchell@utilrisk.com", Role = UserRole.RiskManager, Status = UserStatus.Active, CreatedAt = now },
                new User { Id = new Guid("b0eebc99-9c0b-4ef8-bb6d-6bb9bd380a12"), Name = "James Hartley", Email = "jhartley@utilrisk.com", Role = UserRole.Trader, Status = UserStatus.Active, CreatedAt = now },
                new User { Id = new Guid("c0eebc99-9c0b-4ef8-bb6d-6bb9bd380a13"), Name = "Elena Vasquez", Email = "evasquez@utilrisk.com", Role = UserRole.ComplianceOfficer, Status = UserStatus.Active, CreatedAt = now },
                new User { Id = new Guid("d0eebc99-9c0b-4ef8-bb6d-6bb9bd380a14"), Name = "Tom Brennan", Email = "tbrennan@utilrisk.com", Role = UserRole.Admin, Status = UserStatus.Inactive, CreatedAt = now }
            );
        }

        if (!db.Trades.Any())
        {
            db.Trades.AddRange(
                new Trade { Id = new Guid("10000001-0000-0000-0000-000000000001"), Commodity = "Natural Gas", Direction = TradeDirection.Buy, Quantity = 10000, Price = 2.84m, Counterparty = "Vertex Energy", Status = TradeStatus.Confirmed, CreatedAt = now.AddHours(-3) },
                new Trade { Id = new Guid("10000001-0000-0000-0000-000000000002"), Commodity = "Electricity", Direction = TradeDirection.Sell, Quantity = 50, Price = 45.20m, Counterparty = "NextEra", Status = TradeStatus.Confirmed, CreatedAt = now.AddHours(-2) },
                new Trade { Id = new Guid("10000001-0000-0000-0000-000000000003"), Commodity = "Crude Oil", Direction = TradeDirection.Buy, Quantity = 1000, Price = 78.34m, Counterparty = "BP Trading", Status = TradeStatus.Pending, CreatedAt = now.AddHours(-1) },
                new Trade { Id = new Guid("10000001-0000-0000-0000-000000000004"), Commodity = "Carbon Credits", Direction = TradeDirection.Buy, Quantity = 500, Price = 68.75m, Counterparty = "Shell Energy", Status = TradeStatus.Pending, CreatedAt = now.AddMinutes(-30) },
                new Trade { Id = new Guid("10000001-0000-0000-0000-000000000005"), Commodity = "Coal API2", Direction = TradeDirection.Sell, Quantity = 2000, Price = 115.00m, Counterparty = "Glencore", Status = TradeStatus.Cancelled, CreatedAt = now.AddDays(-1) }
            );
        }

        if (!db.Positions.Any())
        {
            db.Positions.AddRange(
                new Position { Id = new Guid("20000002-0000-0000-0000-000000000001"), Commodity = "Natural Gas", NetQuantity = 25000, AveragePrice = 2.79m, MarkToMarketValue = 71000m, LastUpdated = now },
                new Position { Id = new Guid("20000002-0000-0000-0000-000000000002"), Commodity = "Electricity (PJM)", NetQuantity = -150, AveragePrice = 46.10m, MarkToMarketValue = -1350m, LastUpdated = now },
                new Position { Id = new Guid("20000002-0000-0000-0000-000000000003"), Commodity = "Crude Oil (WTI)", NetQuantity = 3500, AveragePrice = 77.50m, MarkToMarketValue = 294000m, LastUpdated = now },
                new Position { Id = new Guid("20000002-0000-0000-0000-000000000004"), Commodity = "Carbon Credits", NetQuantity = 1200, AveragePrice = 65.00m, MarkToMarketValue = 45000m, LastUpdated = now },
                new Position { Id = new Guid("20000002-0000-0000-0000-000000000005"), Commodity = "Coal (API2)", NetQuantity = -500, AveragePrice = 117.00m, MarkToMarketValue = -10000m, LastUpdated = now }
            );
        }

        if (!db.RiskMetrics.Any())
        {
            db.RiskMetrics.AddRange(
                new RiskMetric { Id = new Guid("30000003-0000-0000-0000-000000000001"), Label = "Value at Risk (1d, 95%)", Value = 2400000m, Limit = 5000000m, Utilization = 48, Severity = RiskSeverity.Low, CalculatedAt = now },
                new RiskMetric { Id = new Guid("30000003-0000-0000-0000-000000000002"), Label = "Credit Exposure", Value = 18700000m, Limit = 25000000m, Utilization = 75, Severity = RiskSeverity.Medium, CalculatedAt = now },
                new RiskMetric { Id = new Guid("30000003-0000-0000-0000-000000000003"), Label = "Commodity Delta", Value = 9100000m, Limit = 10000000m, Utilization = 91, Severity = RiskSeverity.High, CalculatedAt = now },
                new RiskMetric { Id = new Guid("30000003-0000-0000-0000-000000000004"), Label = "Open Position Limit", Value = 105, Limit = 150, Utilization = 70, Severity = RiskSeverity.Medium, CalculatedAt = now },
                new RiskMetric { Id = new Guid("30000003-0000-0000-0000-000000000005"), Label = "Counterparty Limit", Value = 3200000m, Limit = 8000000m, Utilization = 40, Severity = RiskSeverity.Low, CalculatedAt = now }
            );
        }

        if (!db.MarketPriceTicks.Any())
        {
            db.MarketPriceTicks.AddRange(
                new MarketPriceTick { Id = new Guid("40000004-0000-0000-0000-000000000001"), Commodity = "Natural Gas", Price = 2.84m, ChangePercent = 1.43m, Volume = 2100000, Status = MarketStatus.Active, Timestamp = now },
                new MarketPriceTick { Id = new Guid("40000004-0000-0000-0000-000000000002"), Commodity = "Electricity (PJM)", Price = 45.20m, ChangePercent = -0.88m, Volume = 850000, Status = MarketStatus.Active, Timestamp = now },
                new MarketPriceTick { Id = new Guid("40000004-0000-0000-0000-000000000003"), Commodity = "Crude Oil (WTI)", Price = 78.34m, ChangePercent = 0.62m, Volume = 4500000, Status = MarketStatus.Active, Timestamp = now },
                new MarketPriceTick { Id = new Guid("40000004-0000-0000-0000-000000000004"), Commodity = "Coal (API2)", Price = 115.00m, ChangePercent = -2.10m, Volume = 320000, Status = MarketStatus.Halted, Timestamp = now },
                new MarketPriceTick { Id = new Guid("40000004-0000-0000-0000-000000000005"), Commodity = "Carbon Credits", Price = 68.75m, ChangePercent = 3.20m, Volume = 1200000, Status = MarketStatus.Active, Timestamp = now }
            );
        }

        if (!db.Alerts.Any())
        {
            db.Alerts.AddRange(
                new Alert { Id = new Guid("50000005-0000-0000-0000-000000000001"), Type = "Risk Limit", Message = "Commodity Delta approaching limit", Threshold = 9000000m, Status = AlertStatus.Triggered, TriggeredAt = now.AddMinutes(-15), CreatedAt = now.AddDays(-1) },
                new Alert { Id = new Guid("50000005-0000-0000-0000-000000000002"), Type = "Market Price", Message = "Natural Gas price spike detected", Threshold = 2.80m, Status = AlertStatus.Active, CreatedAt = now.AddHours(-2) },
                new Alert { Id = new Guid("50000005-0000-0000-0000-000000000003"), Type = "Credit Exposure", Message = "Counterparty limit 75% utilized", Threshold = 18000000m, Status = AlertStatus.Active, CreatedAt = now.AddHours(-1) }
            );
        }

        await db.SaveChangesAsync();
    }
}
