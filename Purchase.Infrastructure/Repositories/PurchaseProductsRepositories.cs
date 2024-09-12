using Purchase.Domain.Entities;
using Purchase.Infrastructure.Data;
using Purchase.Infrastructure.Interfaces;

namespace Purchase.Infrastructure.Repositories
{
    public class PurchaseProductsRepositories : Repositories<PurchaseProducts>, IPurchaseProductsRepositories
    {
        public PurchaseProductsRepositories(PurchaseDbContext purchaseDbContext) : base(purchaseDbContext)
        {
        }
    }
}
