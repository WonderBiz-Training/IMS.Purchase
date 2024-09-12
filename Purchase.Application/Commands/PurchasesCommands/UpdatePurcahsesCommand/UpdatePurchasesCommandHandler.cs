using MediatR;
using Purchase.Domain.Entities;
using Purchase.Infrastructure.Interfaces;
using static Purchase.Application.DTOs.PurchaseDtos;

namespace Purchase.Application.Commands.PurchasesCommands.UpdatePurcahsesCommand
{
    public class UpdatePurchasesCommandHandler : IRequestHandler<UpdatePurchasesCommand, GetPurchasesDto>
    {
        private readonly IPurchasesRepositories _purchasesRepositories;

        public UpdatePurchasesCommandHandler(IPurchasesRepositories purchasesRepositories)
        {
            _purchasesRepositories = purchasesRepositories;
        }

        public async Task<GetPurchasesDto> Handle(UpdatePurchasesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var purchases = new Purchases
                {
                    Id = request.Id,
                    PurchaseCode = request.PurchaseCode ?? string.Empty,
                    VendorId = request.VendorId ?? Guid.Empty,
                    PurchaseDate = request.PurchaseDate ?? DateTime.Now,
                    PurchaseQuantity = request.PurchaseQuantity ?? 0,
                    PurchaseTotal = request.PurchaseTotal,
                    DiscountId = request.DiscountId,
                    DiscountedTotal = request.DiscountedTotal,
                    TaxId = request.TaxId,
                    TaxedTotal = request.TaxedTotal,
                    StatusId = request.StatusId ?? Guid.Empty,
                    LocationId = request.LocationId ?? Guid.Empty,
                    CreatedBy = request.CreatedBy,
                    UpdatedBy = request.CreatedBy,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };

                var res = await _purchasesRepositories.UpdateAsync(purchases);

                var resDto = new GetPurchasesDto
                (
                    res.Id,
                    res.PurchaseCode,
                    res.VendorId,
                    res.PurchaseDate,
                    res.PurchaseQuantity,
                    res.PurchaseTotal,
                    res.DiscountId,
                    res.DiscountedTotal,
                    res.TaxId,
                    res.TaxedTotal,
                    res.StatusId,
                    res.LocationId
                );

                return resDto;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
