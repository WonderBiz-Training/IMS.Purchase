using MediatR;
using Purchase.Domain.Entities;
using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.Commands.PurchaseProductsCommands.UpdatePurchaseProductsCommand
{
    public class UpdatePurchaseProductsCommand : BaseEntity, IRequest<GetPurchaseProductsDto>
    {
        public Guid? PurchaseId { get; set; }

        public Guid? ProductId { get; set; }

        public long? ProductQuantity { get; set; }

        //public long ProductPrice { get; set; }

        public double? ProductTotal { get; set; }

        public Guid? DiscountId { get; set; }

        public double? DiscountedTotal { get; set; }

        public Guid? TaxId { get; set; }

        public double? TaxedTotal { get; set; }
    }
}
