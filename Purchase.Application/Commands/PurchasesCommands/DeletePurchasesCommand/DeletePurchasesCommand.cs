using MediatR;

namespace Purchase.Application.Commands.PurchasesCommands.DeletePurchasesCommand
{
    public class DeletePurchasesCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
