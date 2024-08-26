using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOLXYSEAT.DOMAIN.Models;
using VOLXYSEAT.DOMAIN.Repositories;
using VOLXYSEAT.INFRASTRUCTURE.Data;

namespace VOLXYSEAT.INFRASTRUCTURE.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription, Guid>, ISubscriptionRepository
    {
        public SubscriptionRepository(DataContext context) : base(context) { }

        public async Task<Subscription> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public IEnumerable<Subscription> GetAll()
        {
            return _entities.ToList();
        }

        public void AddAsync(Subscription obj)
        {
            _entities.AddAsync(obj);
        }

        public virtual void Update(Subscription obj)
        {
            _entities.Update(obj);
        }
    }
}
