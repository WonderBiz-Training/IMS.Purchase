using Purchase.Domain.Entities;
using Purchase.Infrastructure.Data;
using Purchase.Infrastructure.Interfaces;

namespace Purchase.Infrastructure.Repositories
{
    public class PurchasesRepositories : Repositories<Purchases>, IPurchasesRepositories
    {
        public PurchasesRepositories(PurchaseDbContext purchaseDbContext) : base(purchaseDbContext)
        {
        }
    }
}
