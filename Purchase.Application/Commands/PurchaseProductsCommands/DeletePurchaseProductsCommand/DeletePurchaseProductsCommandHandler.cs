using MediatR;
using Purchase.Infrastructure.Interfaces;

namespace Purchase.Application.Commands.PurchaseProductsCommands.DeletePurchaseProductsCommand
{
    public class DeletePurchaseProductsCommandHandler : IRequestHandler<DeletePurchaseProductsCommand, bool>
    {
        private readonly IPurchaseProductsRepositories _purchaseRepositories;

        public DeletePurchaseProductsCommandHandler(IPurchaseProductsRepositories purchaseRepositories)
        {
            _purchaseRepositories = purchaseRepositories;
        }

        public async Task<bool> Handle(DeletePurchaseProductsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var purchase = await _purchaseRepositories.GetByIdAsync(request.Id);

                if (purchase == null)
                {
                    throw new InvalidOperationException($"No Purchase found for id {request.Id}");
                }

                var res = await _purchaseRepositories.DeleteAsync(purchase);

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
