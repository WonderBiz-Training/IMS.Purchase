using MediatR;
using Purchase.Infrastructure.Interfaces;
using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.Queries.PurchaseProductsQueries.GetPurchaseProductByIdQuery
{
    public class GetPurchaseProductByIdQueryHandler : IRequestHandler<GetPurchaseProductByIdQuery, GetPurchaseProductsDto>
    {
        private readonly IPurchaseProductsRepositories _purchaseRepositories;

        public GetPurchaseProductByIdQueryHandler(IPurchaseProductsRepositories purchaseRepositories)
        {
            _purchaseRepositories = purchaseRepositories;
        }

        public async Task<GetPurchaseProductsDto> Handle(GetPurchaseProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _purchaseRepositories.GetByIdAsync(request.Id);

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
