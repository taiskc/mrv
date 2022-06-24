using Microsoft.EntityFrameworkCore;
using mrv.Models;

namespace mrv.Context
{
    public class LeadRepository : DbContext, ILeadRepository
    {
        public DbSet<Lead> Leads { get; set; }
        public LeadRepository(DbContextOptions<LeadRepository> options)
            : base(options)
        { }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
