using Microsoft.EntityFrameworkCore;
using mrv.Models;

namespace mrv.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Product>? Products { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }

        async Task<int> IApplicationContext.SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
