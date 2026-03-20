using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Trade> Trades => Set<Trade>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<RiskMetric> RiskMetrics => Set<RiskMetric>();
    public DbSet<MarketPriceTick> MarketPriceTicks => Set<MarketPriceTick>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Alert> Alerts => Set<Alert>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Trade>(b =>
        {
            b.Property(t => t.Direction).HasConversion<string>();
            b.Property(t => t.Status).HasConversion<string>();
            b.Property(t => t.Price).HasPrecision(18, 4);
            b.Property(t => t.Quantity).HasPrecision(18, 4);
        });

        model.Entity<Position>(b =>
        {
            b.Property(p => p.NetQuantity).HasPrecision(18, 4);
            b.Property(p => p.AveragePrice).HasPrecision(18, 4);
            b.Property(p => p.MarkToMarketValue).HasPrecision(18, 4);
        });

        model.Entity<RiskMetric>(b =>
        {
            b.Property(r => r.Severity).HasConversion<string>();
            b.Property(r => r.Value).HasPrecision(18, 4);
            b.Property(r => r.Limit).HasPrecision(18, 4);
            b.Property(r => r.Utilization).HasPrecision(5, 2);
        });

        model.Entity<MarketPriceTick>(b =>
        {
            b.Property(m => m.Status).HasConversion<string>();
            b.Property(m => m.Price).HasPrecision(18, 4);
            b.Property(m => m.ChangePercent).HasPrecision(10, 4);
            b.Property(m => m.Volume).HasPrecision(18, 2);
            b.HasIndex(m => m.Commodity);
            b.HasIndex(m => m.Timestamp);
        });

        model.Entity<User>(b =>
        {
            b.Property(u => u.Role).HasConversion<string>();
            b.Property(u => u.Status).HasConversion<string>();
            b.HasIndex(u => u.Email).IsUnique();
        });

        model.Entity<Alert>(b =>
        {
            b.Property(a => a.Status).HasConversion<string>();
            b.Property(a => a.Threshold).HasPrecision(18, 4);
        });
    }
}
