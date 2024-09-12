using MediatR;
using static Purchase.Application.DTOs.PurchaseDtos;

namespace Purchase.Application.Queries.PurchasesQueries.GetPurchaseByIdQuery
{
    public class GetPurchaseByIdQuery : IRequest<GetPurchasesDto>
    {
        public Guid Id { get; set; }
    }
}
