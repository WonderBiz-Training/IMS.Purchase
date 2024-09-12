using MediatR;
using Purchase.Application.Commands.PurchaseProductsCommands.CreatePurchaseProductsCommand;
using Purchase.Application.Commands.PurchaseProductsCommands.DeletePurchaseProductsCommand;
using Purchase.Application.Commands.PurchaseProductsCommands.UpdatePurchaseProductsCommand;
using Purchase.Application.Interfaces;
using Purchase.Application.Queries.PurchaseProductsQueries.GetPurchaseProductByIdQuery;
using Purchase.Application.Queries.PurchaseProductsQueries.GetPurchaseProductsQuery;
using Purchase.Infrastructure.Interfaces;
using static Purchase.Application.DTOs.PurchaseProductDtos;

namespace Purchase.Application.Services
{
    public class PurchaseProductsServices : IPurchaseProductsServices
    {
        private readonly IMediator _mediator;
        private readonly IPurchaseProductsRepositories _purchaseRepositories;

        public PurchaseProductsServices(IMediator mediator, IPurchaseProductsRepositories purchaseRepositories)
        {
            _mediator = mediator;
            _purchaseRepositories = purchaseRepositories;
        }

        public async Task<GetPurchaseProductsDto> CreatePurchaseAsync(CreatePurchaseProductsDto purchase)
        {
            try
            {
                var command = new CreatePurchaseProductsCommand
                {
                    PurchaseId = purchase.PurchaseId,
                    ProductId = purchase.ProductId,
                    ProductQuantity = purchase.ProductQuantity,
                    ProductTotal = purchase.ProductQuantity * purchase.ProductTotal,
                    DiscountId = purchase.DiscountId,
                    DiscountedTotal = purchase.ProductTotal - purchase.ProductTotal * 0,
                    TaxId = purchase.TaxId,
                    TaxedTotal = purchase.ProductTotal - purchase.ProductTotal * 0,
                    CreatedBy = purchase.CreatedBy,
                    UpdatedBy = purchase.CreatedBy,
                    CreatedAt = DateTime.Now,
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

        public async Task<bool> DeletePurchaseAsync(Guid id)
        {
            try
            {
                var command = new DeletePurchaseProductsCommand
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

        public async Task<GetPurchaseProductsDto> GetPurchaseByIdAsync(Guid id)
        {
            try
            {
                var purchase = await _mediator.Send(new GetPurchaseProductByIdQuery { Id = id });

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

        public Task<IEnumerable<GetPurchaseProductsDto>> GetPurchasesAsync()
        {
            try
            {
                var res = _mediator.Send(new GetPurchaseProductsQuery());

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public Task<GetPurchaseProductsDto> UpdatePurchaseAsync(Guid id, UpdatePurchaseProductsDto purchase)
        {
            try
            {
                var oldPurchase = _purchaseRepositories.GetByIdAsync(id).Result;

                if (oldPurchase == null)
                {
                    throw new InvalidOperationException($"No Purchase found for id {id}");
                }

                var command = new UpdatePurchaseProductsCommand
                {
                    PurchaseId = purchase.PurchaseId != null ? purchase.PurchaseId : oldPurchase.PurchaseId,
                    ProductId = purchase.ProductId != null ? purchase.ProductId : oldPurchase.ProductId,
                    ProductQuantity = purchase.ProductQuantity != null ? purchase.ProductQuantity : oldPurchase.ProductQuantity,
                    ProductTotal = purchase.ProductTotal != null ? purchase.ProductTotal : oldPurchase.ProductTotal,
                    DiscountId = purchase.DiscountId != null ? purchase.DiscountId : oldPurchase.DiscountId,
                    DiscountedTotal = purchase.DiscountedTotal != null ? purchase.DiscountedTotal : oldPurchase.DiscountedTotal,
                    TaxId = purchase.TaxId != null ? purchase.TaxId : oldPurchase.TaxId,
                    TaxedTotal = purchase.TaxedTotal != null ? purchase.TaxedTotal : oldPurchase.TaxedTotal,
                    UpdatedBy = purchase.UpdatedBy,
                    UpdatedAt = DateTime.Now
                };

                var res = _mediator.Send(command);

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
