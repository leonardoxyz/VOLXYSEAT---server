using Dapper;
using System.Data;
using VOLXYSEAT.DOMAIN.Models;
using VOLXYSEAT.DOMAIN.Repositories;
using VOLXYSEAT.INFRASTRUCTURE.Data;

namespace VOLXYSEAT.INFRASTRUCTURE.Repositories;
public class TransactionRepository : BaseRepository<Transaction, Guid>, ITransactionRepository
{

    private readonly IDbConnection _dbConnection;
    private readonly DataContext _context;
    public TransactionRepository(DataContext context, IDbConnection dbConnection) : base(context)
    {
        _dbConnection = dbConnection;
        _context = context;
    }
    public async Task<Transaction> GetByClientId(Guid id)
    {
        var query = @"SELECT Id, SubscriptionId, ClientId, IssueDate FROM Transactions WHERE ClientId = @ClientId";
        var parameters = new { ClientId = id };
        var result = await _dbConnection.QueryAsync<Transaction>(query, parameters);
        return result.FirstOrDefault();
    }
}

