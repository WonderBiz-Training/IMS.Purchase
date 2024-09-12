using MediatR;
using Purchase.Domain.Entities;
using Purchase.Infrastructure.Interfaces;
using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.Commands.PurchaseProductsCommands.UpdatePurchaseProductsCommand
{
    public class UpdatePurchaseProductsCommandHandler : IRequestHandler<UpdatePurchaseProductsCommand, GetPurchaseProductsDto>
    {
        private readonly IPurchaseProductsRepositories _purchaseRepositories;

        public UpdatePurchaseProductsCommandHandler(IPurchaseProductsRepositories purchaseRepositories)
        {
            _purchaseRepositories = purchaseRepositories;
        }

        public async Task<GetPurchaseProductsDto> Handle(UpdatePurchaseProductsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var purchase = new PurchaseProducts
                {
                    PurchaseId = request.PurchaseId ?? Guid.Empty,
                    ProductId = request.ProductId ?? Guid.Empty,
                    ProductQuantity = request.ProductQuantity ?? 0,
                    ProductTotal = request.ProductTotal,
                    DiscountId = request.DiscountId,
                    DiscountedTotal = request.DiscountedTotal,
                    UpdatedBy = request.UpdatedBy,
                    UpdatedAt = request.UpdatedAt,
                };

                var res = await _purchaseRepositories.UpdateAsync(purchase);

                var resDto = new GetPurchaseProductsDto
                (
                    res.Id,
                    res.PurchaseId,
                    res.ProductId,
                    res.ProductQuantity,
                    res.ProductTotal,
                    res.DiscountId,
                    res.DiscountedTotal,
                    res.TaxId,
                    res.TaxedTotal
                );

                return resDto;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
