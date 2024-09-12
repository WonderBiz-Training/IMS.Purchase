using MediatR;
using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.Queries.PurchaseProductsQueries.GetPurchaseProductByIdQuery
{
    public class GetPurchaseProductByIdQuery : IRequest<GetPurchaseProductsDto>
    {
        public Guid Id { get; set; }
    }
}
