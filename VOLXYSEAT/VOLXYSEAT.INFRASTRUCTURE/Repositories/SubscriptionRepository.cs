using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        private readonly IDbConnection _dbConnection;
        public SubscriptionRepository(DataContext context, IDbConnection dbConnection) : base(context)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Subscription> GetByIdAsync(Guid id)
        {
            var query = "SELECT * FROM Subscriptions WHERE Id = @Id";
            var parameters = new { Id = id };
            var result = await _dbConnection.QuerySingleOrDefaultAsync<Subscription>(query, parameters);
            return result;
        }

        public IEnumerable<Subscription> GetAll()
        {
            return _entities
                .AsNoTracking()
                .ToList();
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
