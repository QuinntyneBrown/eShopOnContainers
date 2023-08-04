using Ordering.Core;
using Microsoft.EntityFrameworkCore;
using Ordering.Core.AggregatesModel.BuyerAggregate;
using Ordering.Core.AggregatesModel.OrderAggregate;

namespace Ordering.Core;

public interface IOrderingDbContext
{
    DbSet<Buyer> Buyers { get; set; }
    DbSet<Order> Orders { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}

