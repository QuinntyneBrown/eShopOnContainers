using Identity.Core;
using Microsoft.EntityFrameworkCore;
using Identity.Core.AggregatesModel.UserAggregate;

namespace Identity.Core;

public interface IIdentityDbContext
{
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}

