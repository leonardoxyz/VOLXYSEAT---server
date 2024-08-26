using Microsoft.EntityFrameworkCore;
using VOLXYSEAT.DOMAIN.Core;
using VOLXYSEAT.DOMAIN.Repositories;
using VOLXYSEAT.INFRASTRUCTURE.Data;

namespace VOLXYSEAT.INFRASTRUCTURE.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity
    {
        protected readonly DataContext _dataContext;
        protected readonly DbSet<TEntity> _entities;
        public virtual IUnitOfWork UnitOfWork => _dataContext;

        public BaseRepository(DataContext context)
        {
            _dataContext = context ?? throw new ArgumentNullException(nameof(context));
            _entities = _dataContext.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            await _entities.AddAsync(obj);
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual void Update(TEntity obj)
        {
            _entities.Update(obj);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
