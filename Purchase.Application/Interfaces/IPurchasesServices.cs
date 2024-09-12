using static Purchase.Application.DTOs.PurchaseDtos;

namespace Purchase.Application.Interfaces
{
    public interface IPurchasesServices
    {
        Task<IEnumerable<GetPurchasesDto>> GetAllPurchasesAsync();
        Task<GetPurchasesDto> GetPurchaseByIdAsync(Guid id);
        Task<GetPurchasesDto> CreatePurchaseAsync(CreatePurchasesDto purchases);
        Task<GetPurchasesDto> CreateDetailedPurchaseAsync(CreateDetailedPurchaseDto purchases);
        Task<GetPurchasesDto> UpdatePurchaseAsync(Guid id, UpdatePurchasesDto purchases);
        Task<bool> DeletePurchaseAsync(Guid id);
    }
}
