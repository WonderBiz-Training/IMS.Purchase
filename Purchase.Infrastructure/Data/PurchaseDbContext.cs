using Microsoft.EntityFrameworkCore;
using Purchase.Domain.Entities;

namespace Purchase.Infrastructure.Data
{
    public class PurchaseDbContext : DbContext
    {
        public PurchaseDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PurchaseProducts> PurchaseProducts { get; set; }
        public DbSet<Purchases> Purchases { get; set; }

    }
}
