using MediatR;
using Purchase.Infrastructure.Interfaces;
using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.Commands.PurchaseProductsCommands.CreatePurchaseProductsCommand
{
    public class CreatePurchaseProductsCommandHandler : IRequestHandler<CreatePurchaseProductsCommand, GetPurchaseProductsDto>
    {
        private readonly IPurchaseProductsRepositories _purchaseRepositories;

        public CreatePurchaseProductsCommandHandler(IPurchaseProductsRepositories purchaseRepositories)
        {
            _purchaseRepositories = purchaseRepositories;
        }

        public async Task<GetPurchaseProductsDto> Handle(CreatePurchaseProductsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var purchase = new Domain.Entities.PurchaseProducts
                {
                    PurchaseId = request.PurchaseId,
                    ProductId = request.ProductId,
                    ProductQuantity = request.ProductQuantity,
                    ProductTotal = request.ProductTotal,
                    DiscountId = request.DiscountId,
                    DiscountedTotal = request.DiscountedTotal,
                    TaxId = request.TaxId,
                    TaxedTotal = request.TaxedTotal,
                    CreatedBy = request.CreatedBy,
                    UpdatedBy = request.UpdatedBy,
                    CreatedAt = request.CreatedAt,
                    UpdatedAt = request.UpdatedAt,
                };

                var res = await _purchaseRepositories.CreateAsync(purchase);

                var resDto = new GetPurchaseProductsDto(
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
