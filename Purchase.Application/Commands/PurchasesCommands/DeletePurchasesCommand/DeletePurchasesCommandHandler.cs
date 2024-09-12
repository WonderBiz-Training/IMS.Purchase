using MediatR;
using Purchase.Infrastructure.Interfaces;

namespace Purchase.Application.Commands.PurchasesCommands.DeletePurchasesCommand
{
    public class DeletePurchasesCommandHandler : IRequestHandler<DeletePurchasesCommand, bool>
    {
        private readonly IPurchasesRepositories _purchasesRepositories;

        public DeletePurchasesCommandHandler(IPurchasesRepositories purchasesRepositories)
        {
            _purchasesRepositories = purchasesRepositories;
        }

        public async Task<bool> Handle(DeletePurchasesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var purchase = await _purchasesRepositories.GetByIdAsync(request.Id);

                if (purchase == null)
                {
                    throw new InvalidOperationException($"No Purchase Header found for id {request.Id}");
                }

                var res = await _purchasesRepositories.DeleteAsync(purchase);

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
