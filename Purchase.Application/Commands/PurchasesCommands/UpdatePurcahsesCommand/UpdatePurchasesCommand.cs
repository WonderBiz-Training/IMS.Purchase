using MediatR;
using Purchase.Domain.Entities;
using static Purchase.Application.DTOs.PurchaseDtos;

namespace Purchase.Application.Commands.PurchasesCommands.UpdatePurcahsesCommand
{
    public class UpdatePurchasesCommand : BaseEntity, IRequest<GetPurchasesDto>
    {
        public string? PurchaseCode { get; set; }

        public Guid? VendorId { get; set; }

        //public long ProductId { get; set; }

        public long? PurchaseQuantity { get; set; }

        //public long ProductPrice { get; set; }

        public double? PurchaseTotal { get; set; }

        public Guid? DiscountId { get; set; }

        public double? DiscountedTotal { get; set; }

        public Guid? TaxId { get; set; }

        public double? TaxedTotal { get; set; }

        public Guid? StatusId { get; set; }

        public Guid? LocationId { get; set; }

        public DateTime? PurchaseDate { get; set; } = DateTime.Now;
    }
}
