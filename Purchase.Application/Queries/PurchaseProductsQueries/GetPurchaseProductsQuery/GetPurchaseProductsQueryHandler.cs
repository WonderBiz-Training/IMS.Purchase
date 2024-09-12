using MediatR;
using Purchase.Infrastructure.Interfaces;
using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.Queries.PurchaseProductsQueries.GetPurchaseProductsQuery
{
    public class GetPurchaseProductsQueryHandler : IRequestHandler<GetPurchaseProductsQuery, IEnumerable<GetPurchaseProductsDto>>
    {
        private readonly IPurchaseProductsRepositories _purchaseRepositories;

        public GetPurchaseProductsQueryHandler(IPurchaseProductsRepositories purchaseRepositories)
        {
            _purchaseRepositories = purchaseRepositories;
        }

        public async Task<IEnumerable<GetPurchaseProductsDto>> Handle(GetPurchaseProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _purchaseRepositories.GetAllAsync();

                var resDto = res.Select(x => new GetPurchaseProductsDto
                (
                    x.Id,
                    x.PurchaseId,
                    x.ProductId,
                    x.ProductQuantity,
                    x.ProductTotal,
                    x.DiscountId,
                    x.DiscountedTotal,
                    x.TaxId,
                    x.TaxedTotal
                )).ToList();

                return resDto;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
