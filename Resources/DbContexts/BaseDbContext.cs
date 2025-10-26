using Resources.Abstractions.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Resources.DataContexts
{
    public class BaseDbContext<TContext> : DbContext, IBaseDbContext
        where TContext : DbContext
    {
        public BaseDbContext() : base() { }

        public BaseDbContext(DbContextOptions<TContext> options)
            : base(options) { }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
