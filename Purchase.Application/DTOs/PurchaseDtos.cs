using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.DTOs
{
    public class PurchaseDtos
    {

        public record CreatePurchasesDto(
             string PurchaseCode,
             Guid VendorId,
             // long ProductId,
             long PurchaseQuantity,
             // long ProductPrice,
             double? PurchaseTotal,
             Guid? DiscountId,
             double? DiscountedTotal,
             Guid? TaxId,
             double? TaxedTotal,
             Guid StatusId,
             Guid LocationId,
             DateTime PurchaseDate,
             Guid CreatedBy
        );

        public record CreateDetailedPurchaseDto(
             string PurchaseCode,
             Guid VendorId,
             // long ProductId,
             long PurchaseQuantity,
             // long ProductPrice,
             double? PurchaseTotal,
             Guid? DiscountId,
             double? DiscountedTotal,
             Guid? TaxId,
             double? TaxedTotal,
             Guid StatusId,
             Guid LocationId,
             DateTime PurchaseDate,
             Guid CreatedBy,
             List<CreatePurchaseProductsDto> PurchaseProducts
        );

        public record GetPurchasesDto(
             Guid Id,
             string PurchaseCode,
             Guid VendorId,
             DateTime PurchaseDate,
             // long ProductId,
             long PurchaseQuantity,
             // long ProductPrice,
             double? PurchaseTotal,
             Guid? DiscountId,
             double? DiscountedTotal,
             Guid? TaxId,
             double? TaxedTotal,
             Guid StatusId,
             Guid LocationId
        );

        public record UpdatePurchasesDto(
             string? PurchaseCode,
             Guid? VendorId,
             // long ProductId,
             long? PurchaseQuantity,
             // long ProductPrice,
             double? PurchaseTotal,
             Guid? DiscountId,
             double? DiscountedTotal,
             Guid? TaxId,
             double? TaxedTotal,
             Guid? StatusId,
             Guid? LocationId,
             DateTime? PurchaseDate,
             Guid UpdatedBy
        );
    }
}
