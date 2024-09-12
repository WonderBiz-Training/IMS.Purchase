using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.Interfaces
{
    public interface IPurchaseProductsServices
    {
        Task<IEnumerable<GetPurchaseProductsDto>> GetPurchasesAsync();
        Task<GetPurchaseProductsDto> GetPurchaseByIdAsync(Guid id);
        Task<GetPurchaseProductsDto> CreatePurchaseAsync(CreatePurchaseProductsDto purchase);
        Task<GetPurchaseProductsDto> UpdatePurchaseAsync(Guid id, UpdatePurchaseProductsDto purchase);
        Task<bool> DeletePurchaseAsync(Guid id);
    }
}
