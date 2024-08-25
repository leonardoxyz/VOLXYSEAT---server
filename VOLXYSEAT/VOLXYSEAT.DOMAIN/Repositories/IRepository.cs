using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOLXYSEAT.DOMAIN.Core;

namespace VOLXYSEAT.DOMAIN.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : Entity
    {
        void AddAsync(TEntity obj);
        TEntity GetAsync(TKey id);
        void Update(TEntity obj);
        IUnitOfWork UnitOfWork { get; }
    }
}
