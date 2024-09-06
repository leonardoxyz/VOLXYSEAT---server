using Azure.Core;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOLXYSEAT.DOMAIN.Exceptions;
using VOLXYSEAT.DOMAIN.Models;
using VOLXYSEAT.DOMAIN.Repositories;
using VOLXYSEAT.INFRASTRUCTURE.Data;

namespace VOLXYSEAT.INFRASTRUCTURE.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription, Guid>, ISubscriptionRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly DataContext _context;
        public SubscriptionRepository(DataContext context, IDbConnection dbConnection) : base(context)
        {
            _dbConnection = dbConnection;
            _context = context;
        }

        public async Task<Subscription> GetByIdAsync(Guid id)
        {
            var query = "SELECT s.*, sp.* FROM Subscriptions s LEFT JOIN SubscriptionProperties sp ON s.Id = sp.SubscriptionId WHERE s.Id = @Id";
            var parameters = new { Id = id };
            var result = await _dbConnection.QueryAsync<Subscription, SubscriptionProperties, Subscription>(
            query,
            (subscription, properties) =>
            {
                subscription.SubscriptionProperties = properties;
                properties.Subscription = subscription;
                return subscription;
            },
            new { Id = id },
            splitOn: "SubscriptionId"
            );
            return result.SingleOrDefault();
        }

        public async Task AddAsync(Subscription subscription)
        {
            if (subscription == null) throw new VolxyseatDomainException(nameof(subscription));

            await _context.Set<Subscription>().AddAsync(subscription);
            await _context.SaveChangesAsync();
        }


        public virtual void Update(Subscription obj)
        {
            _entities.Update(obj);
        }

        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            var sql = @"
            SELECT s.*, sp.*
            FROM Subscriptions s
            LEFT JOIN SubscriptionProperties sp ON s.Id = sp.SubscriptionId";

            var result = await _dbConnection.QueryAsync<Subscription, SubscriptionProperties, Subscription>(
                sql,
                (subscription, properties) =>
                {
                    subscription.SubscriptionProperties = properties;
                    properties.Subscription = subscription;
                    return subscription;
                },
                splitOn: "SubscriptionId"
            );

            return result;
        }
    }
}
