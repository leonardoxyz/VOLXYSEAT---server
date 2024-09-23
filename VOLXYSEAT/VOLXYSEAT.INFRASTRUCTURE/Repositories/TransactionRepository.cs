﻿using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using VOLXYSEAT.DOMAIN.Models;
using VOLXYSEAT.DOMAIN.Repositories;
using VOLXYSEAT.INFRASTRUCTURE.Data;

namespace VOLXYSEAT.INFRASTRUCTURE.Repositories;
public class TransactionRepository : BaseRepository<Transaction, Guid>, ITransactionRepository
{

    private readonly DataContext _context;
    public TransactionRepository(DataContext context, IDbConnection dbConnection) : base(context)
    {
        _context = context;
    }
    public async Task<Transaction> GetByClientId(Guid id)
    {
        var transaction = await _context.Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.ClientId == id);

        return transaction;
    }
}

