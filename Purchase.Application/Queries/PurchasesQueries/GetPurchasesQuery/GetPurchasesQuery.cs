using MediatR;
using static Purchase.Application.DTOs.PurchaseDtos;

namespace Purchase.Application.Queries.PurchasesQueries.GetPurchasesQuery
{
    public class GetPurchasesQuery : IRequest<IEnumerable<GetPurchasesDto>>
    {
    }
}
