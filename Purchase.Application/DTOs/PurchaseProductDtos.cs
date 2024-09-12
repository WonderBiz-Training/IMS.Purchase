namespace Purchase.Application.DTOs
{
    public class PurchaseProductDtos
    {
        public record CreatePurchaseProductsDto(
            Guid PurchaseId,
            Guid ProductId,
            long ProductQuantity,
            // long ProductPrice;
            double? ProductTotal,
            Guid? DiscountId,
            double? DiscountedTotal,
            Guid? TaxId,
            double? TaxedTotal,
            Guid CreatedBy
        );

        public record GetPurchaseProductsDto(
            Guid Id,
            Guid PurchaseId,
            Guid ProductId,
            long ProductQuantity,
            // long ProductPrice;
            double? ProductTotal,
            Guid? DiscountId,
            double? DiscountedTotal,
            Guid? TaxId,
            double? TaxedTotal
        );

        public record UpdatePurchaseProductsDto(
            Guid? PurchaseId,
            Guid? ProductId,
            long? ProductQuantity,
            // long ProductPrice;
            double? ProductTotal,
            Guid? DiscountId,
            double? DiscountedTotal,
            Guid? TaxId,
            double? TaxedTotal,
            Guid UpdatedBy
        );
    }
}
