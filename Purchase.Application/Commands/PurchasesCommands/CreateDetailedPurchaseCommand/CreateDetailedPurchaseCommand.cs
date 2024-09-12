using MediatR;
using Purchase.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using static Purchase.Application.DTOs.PurchaseDtos;
using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.Commands.PurchasesCommands.CreateDetailedPurchaseCommand
{
    public class CreateDetailedPurchaseCommand : BaseEntity, IRequest<GetPurchasesDto>
    {
        [Required(ErrorMessage = "Purchase Code is required")]
        public required string PurchaseCode { get; set; }

        [Required(ErrorMessage = "VendorId is required")]
        public Guid VendorId { get; set; }

        //public long ProductId { get; set; }

        [Required(ErrorMessage = "Purchase Quantity is required")]
        public long PurchaseQuantity { get; set; }

        //public long ProductPrice { get; set; }

        public double? PurchaseTotal { get; set; }

        public Guid? DiscountId { get; set; }

        public double? DiscountedTotal { get; set; }

        public Guid? TaxId { get; set; }

        public double? TaxedTotal { get; set; }

        [Required(ErrorMessage = "Status Id is required")]
        public Guid StatusId { get; set; }

        [Required(ErrorMessage = "Location Id is required")]
        public Guid LocationId { get; set; }

        [Required(ErrorMessage = "Purchase Date and Time is required")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public List<CreatePurchaseProductsDto> PurchaseProducts { get; set; } = new List<CreatePurchaseProductsDto>();
    }
}
