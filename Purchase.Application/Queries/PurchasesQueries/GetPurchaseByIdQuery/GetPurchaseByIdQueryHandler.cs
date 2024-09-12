using MediatR;
using Purchase.Infrastructure.Interfaces;
using static Purchase.Application.DTOs.PurchaseDtos;

namespace Purchase.Application.Queries.PurchasesQueries.GetPurchaseByIdQuery
{
    public class GetPurchaseByIdQueryHandler : IRequestHandler<GetPurchaseByIdQuery, GetPurchasesDto>
    {
        private readonly IPurchasesRepositories _purchaseRepositories;

        public GetPurchaseByIdQueryHandler(IPurchasesRepositories purchaseRepositories)
        {
            _purchaseRepositories = purchaseRepositories;
        }

        public async Task<GetPurchasesDto> Handle(GetPurchaseByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _purchaseRepositories.GetByIdAsync(request.Id);

                var resDto = new GetPurchasesDto
                (
                    res.Id,
                    res.PurchaseCode,
                    res.VendorId,
                    res.PurchaseDate,
                    res.PurchaseQuantity,
                    res.PurchaseTotal,
                    res.DiscountId,
                    res.DiscountedTotal,
                    res.TaxId,
                    res.TaxedTotal,
                    res.StatusId,
                    res.LocationId
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
