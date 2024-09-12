using MediatR;
using Purchase.Application.Commands.PurchasesCommands.CreateDetailedPurchaseCommand;
using Purchase.Application.Commands.PurchasesCommands.CreatePurchasesCommand;
using Purchase.Application.Commands.PurchasesCommands.DeletePurchasesCommand;
using Purchase.Application.Commands.PurchasesCommands.UpdatePurcahsesCommand;
using Purchase.Application.Interfaces;
using Purchase.Application.Queries.PurchasesQueries.GetPurchaseByIdQuery;
using Purchase.Application.Queries.PurchasesQueries.GetPurchasesQuery;
using Purchase.Infrastructure.Interfaces;
using static Purchase.Application.DTOs.PurchaseDtos;

namespace Purchase.Application.Services
{
    public class PurchasesServices : IPurchasesServices
    {
        private readonly IPurchasesRepositories _purchasesRepositories;
        private readonly IMediator _mediator;

        public PurchasesServices(IPurchasesRepositories purchasesRepositories, IMediator mediator)
        {
            _purchasesRepositories = purchasesRepositories;
            _mediator = mediator;
        }

        public async Task<GetPurchasesDto> CreatePurchaseAsync(CreatePurchasesDto purchases)
        {
            try
            {
                var command = new CreatePurchasesCommand
                {
                    PurchaseCode = purchases.PurchaseCode,
                    PurchaseDate = purchases.PurchaseDate,
                    PurchaseQuantity = purchases.PurchaseQuantity,
                    VendorId = purchases.VendorId,
                    PurchaseTotal = purchases.PurchaseTotal,
                    DiscountId = purchases.DiscountId,
                    DiscountedTotal = purchases.DiscountedTotal,
                    TaxId = purchases.TaxId,
                    TaxedTotal = purchases.TaxedTotal,
                    StatusId = purchases.StatusId,
                    LocationId = purchases.LocationId,
                    CreatedBy = purchases.CreatedBy,
                    UpdatedBy = purchases.CreatedBy,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                var res = await _mediator.Send(command);

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<GetPurchasesDto> CreateDetailedPurchaseAsync(CreateDetailedPurchaseDto purchases)
        {
            try
            {
                var command = new CreateDetailedPurchaseCommand
                {
                    PurchaseCode = purchases.PurchaseCode,
                    PurchaseDate = purchases.PurchaseDate,
                    PurchaseQuantity = purchases.PurchaseQuantity,
                    VendorId = purchases.VendorId,
                    PurchaseTotal = purchases.PurchaseTotal,
                    DiscountId = purchases.DiscountId,
                    DiscountedTotal = purchases.DiscountedTotal,
                    TaxId = purchases.TaxId,
                    TaxedTotal = purchases.TaxedTotal,
                    StatusId = purchases.StatusId,
                    LocationId = purchases.LocationId,
                    CreatedBy = purchases.CreatedBy,
                    UpdatedBy = purchases.CreatedBy,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    PurchaseProducts = purchases.PurchaseProducts
                };

                var res = await _mediator.Send(command);

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> DeletePurchaseAsync(Guid id)
        {
            try
            {
                var command = new DeletePurchasesCommand
                {
                    Id = id
                };

                var res = await _mediator.Send(command);

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<GetPurchasesDto> GetPurchaseByIdAsync(Guid id)
        {
            try
            {
                var purchase = await _mediator.Send(new GetPurchaseByIdQuery { Id = id });

                if (purchase == null)
                {
                    throw new InvalidOperationException($"No Purchase found for id {id}");
                }

                return purchase;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<IEnumerable<GetPurchasesDto>> GetAllPurchasesAsync()
        {
            try
            {
                var res = await _mediator.Send(new GetPurchasesQuery());

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<GetPurchasesDto> UpdatePurchaseAsync(Guid id, UpdatePurchasesDto purchases)
        {
            try
            {
                var oldPurchases = await _purchasesRepositories.GetByIdAsync(id);

                if (oldPurchases == null)
                {
                    throw new InvalidOperationException($"No Purchase Header found for id {id}");
                }

                var command = new UpdatePurchasesCommand
                {
                    PurchaseCode = purchases.PurchaseCode != null ? purchases.PurchaseCode : oldPurchases.PurchaseCode,
                    PurchaseDate = purchases.PurchaseDate != null ? purchases.PurchaseDate : oldPurchases.PurchaseDate,
                    PurchaseQuantity = purchases.PurchaseQuantity != null ? purchases.PurchaseQuantity : oldPurchases.PurchaseQuantity,
                    VendorId = purchases.VendorId != null ? purchases.VendorId : oldPurchases.VendorId,
                    PurchaseTotal = purchases.PurchaseTotal != null ? purchases.PurchaseTotal : oldPurchases.PurchaseTotal,
                    DiscountId = purchases.DiscountId != null ? purchases.DiscountId : oldPurchases.DiscountId,
                    DiscountedTotal = purchases.DiscountedTotal != null ? purchases.DiscountedTotal : oldPurchases.DiscountedTotal,
                    TaxId = purchases.TaxId != null ? purchases.TaxId : oldPurchases.TaxId,
                    TaxedTotal = purchases.TaxedTotal != null ? purchases.TaxedTotal : oldPurchases.TaxedTotal,
                    StatusId = purchases.StatusId != null ? purchases.StatusId : oldPurchases.StatusId,
                    LocationId = purchases.LocationId != null ? purchases.LocationId : oldPurchases.LocationId,
                    UpdatedBy = purchases.UpdatedBy,
                    UpdatedAt = DateTime.Now,
                };

                var res = await _mediator.Send(command);

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
