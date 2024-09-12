using MediatR;
using Purchase.Domain.Entities;
using Purchase.Infrastructure.Interfaces;
using static Purchase.Application.DTOs.PurchaseDtos;

namespace Purchase.Application.Commands.PurchasesCommands.CreateDetailedPurchaseCommand
{
    public class CreateDetailedPurchaseCommandHandler : IRequestHandler<CreateDetailedPurchaseCommand, GetPurchasesDto>
    {
        private readonly IPurchasesRepositories _purchasesRepositories;

        public CreateDetailedPurchaseCommandHandler(IPurchasesRepositories purchasesRepositories)
        {
            _purchasesRepositories = purchasesRepositories;
        }

        public async Task<GetPurchasesDto> Handle(CreateDetailedPurchaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var purchases = new Purchases
                {
                    PurchaseCode = request.PurchaseCode,
                    VendorId = request.VendorId,
                    PurchaseDate = request.PurchaseDate,
                    PurchaseQuantity = request.PurchaseQuantity,
                    PurchaseTotal = request.PurchaseTotal,
                    DiscountId = request.DiscountId,
                    DiscountedTotal = request.DiscountedTotal,
                    TaxId = request.TaxId,
                    TaxedTotal = request.TaxedTotal,
                    StatusId = request.StatusId,
                    LocationId = request.LocationId,
                    CreatedBy = request.CreatedBy,
                    UpdatedBy = request.CreatedBy,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    PurchaseProduct = request.PurchaseProducts.Select(x => new PurchaseProducts
                    {
                        ProductId = x.ProductId,
                        ProductQuantity = x.ProductQuantity,
                    }).ToList(),
                };


                var res = await _purchasesRepositories.CreateAsync(purchases);

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
