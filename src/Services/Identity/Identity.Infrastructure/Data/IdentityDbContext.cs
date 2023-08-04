using Identity.Core;
using Microsoft.EntityFrameworkCore;
using Identity.Core.AggregatesModel.UserAggregate;

namespace Identity.Infrastructure.Data;

public class IdentityDbContext: DbContext,IIdentityDbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)    : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Identity");

        base.OnModelCreating(modelBuilder);

    }

}

