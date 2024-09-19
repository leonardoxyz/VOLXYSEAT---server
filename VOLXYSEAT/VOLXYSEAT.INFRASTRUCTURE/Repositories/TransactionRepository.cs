using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public Transaction GetByClientId(Guid id)
    {
        throw new NotImplementedException();
    }
}
