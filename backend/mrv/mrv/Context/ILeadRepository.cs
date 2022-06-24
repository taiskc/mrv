using Microsoft.EntityFrameworkCore;
using mrv.Models;

namespace mrv.Context
{
    public interface ILeadRepository
    {
        DbSet<Lead> Leads { get; set; }
        Task<int> SaveChanges();
    }
}