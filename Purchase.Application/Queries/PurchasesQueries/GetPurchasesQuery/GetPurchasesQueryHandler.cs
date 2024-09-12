using MediatR;
using Purchase.Infrastructure.Interfaces;
using static Purchase.Application.DTOs.PurchaseDtos;

namespace Purchase.Application.Queries.PurchasesQueries.GetPurchasesQuery
{
    public class GetPurchasesQueryHandler : IRequestHandler<GetPurchasesQuery, IEnumerable<GetPurchasesDto>>
    {
        private readonly IPurchasesRepositories _purchaseHeaderRepositories;

        public GetPurchasesQueryHandler(IPurchasesRepositories purchaseHeaderRepositories)
        {
            _purchaseHeaderRepositories = purchaseHeaderRepositories;
        }

        public async Task<IEnumerable<GetPurchasesDto>> Handle(GetPurchasesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _purchaseHeaderRepositories.GetAllAsync();

                var resDto = res.Select(x => new GetPurchasesDto
                (
                    x.Id,
                    x.PurchaseCode,
                    x.VendorId,
                    x.PurchaseDate,
                    x.PurchaseQuantity,
                    x.PurchaseTotal,
                    x.DiscountId,
                    x.DiscountedTotal,
                    x.TaxId,
                    x.TaxedTotal,
                    x.StatusId,
                    x.LocationId
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
