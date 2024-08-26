using System.Threading.Tasks;
using VOLXYSEAT.DOMAIN.Core;

namespace VOLXYSEAT.DOMAIN.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : Entity
    {
        Task AddAsync(TEntity obj);
        Task<TEntity> GetAsync(TKey id);
        void Update(TEntity obj);
        IUnitOfWork UnitOfWork { get; }
    }
}
