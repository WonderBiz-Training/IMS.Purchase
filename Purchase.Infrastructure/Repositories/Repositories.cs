using Microsoft.EntityFrameworkCore;
using Purchase.Infrastructure.Data;
using Purchase.Infrastructure.Interfaces;

namespace Purchase.Infrastructure.Repositories
{
    public class Repositories<T> : IRepositories<T> where T : class
    {
        private readonly PurchaseDbContext _purchaseDbContext;

        public Repositories(PurchaseDbContext purchaseDbContext)
        {
            _purchaseDbContext = purchaseDbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _purchaseDbContext.Set<T>().AddAsync(entity);
                await _purchaseDbContext.SaveChangesAsync();

                return entity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _purchaseDbContext.Remove(entity);

                var row = await _purchaseDbContext.SaveChangesAsync();

                return row > 0;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var res = await _purchaseDbContext.Set<T>().ToListAsync();

                return res;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var res = await _purchaseDbContext.Set<T>().FindAsync(id);

            return res;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _purchaseDbContext.Set<T>().Update(entity);
                await _purchaseDbContext.SaveChangesAsync();

                return entity;
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
