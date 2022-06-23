using Microsoft.EntityFrameworkCore;
using mrv.Models;

namespace mrv.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}