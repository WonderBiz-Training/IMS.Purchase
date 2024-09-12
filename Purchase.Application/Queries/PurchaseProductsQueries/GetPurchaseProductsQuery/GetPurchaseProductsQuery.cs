using MediatR;
using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.Queries.PurchaseProductsQueries.GetPurchaseProductsQuery
{
    public class GetPurchaseProductsQuery : IRequest<IEnumerable<GetPurchaseProductsDto>>
    {
    }
}
