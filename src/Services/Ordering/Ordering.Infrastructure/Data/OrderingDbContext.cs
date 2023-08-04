using Ordering.Core;
using Microsoft.EntityFrameworkCore;
using Ordering.Core.AggregatesModel.BuyerAggregate;
using Ordering.Core.AggregatesModel.OrderAggregate;

namespace Ordering.Infrastructure.Data;

public class OrderingDbContext: DbContext,IOrderingDbContext
{
    public OrderingDbContext(DbContextOptions<OrderingDbContext> options)    : base(options)
    {
    }

    public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Ordering");

        base.OnModelCreating(modelBuilder);

    }

}

