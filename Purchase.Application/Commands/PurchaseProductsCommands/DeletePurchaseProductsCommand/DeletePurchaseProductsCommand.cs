using MediatR;

namespace Purchase.Application.Commands.PurchaseProductsCommands.DeletePurchaseProductsCommand
{
    public class DeletePurchaseProductsCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
