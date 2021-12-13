using Microsoft.EntityFrameworkCore;
using PaymentProject.Core.Data;

namespace PaymentProject.Infrastructure.Data;

public class PaymentDbContext : DbContext
{
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Order> Orders { get; set; }
    // public string? DbPath { get; }

    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
    {

    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlite($"Data Source={DbPath}");
}