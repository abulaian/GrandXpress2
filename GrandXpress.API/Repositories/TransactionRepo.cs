using GrandXpress.Data.Entities;
using GrandXpress.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandXpress.API.Repositories
{
    public class TransactionRepo : ITransactionRepo
    {
        private TransactionDbContext _ctx;

        public TransactionRepo(TransactionDbContext ctx)
        {
            _ctx = ctx;
            _ctx.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
        }
        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await _ctx.Transactions.Select(t=>t).ToListAsync();
        }
        public async Task<Transaction> GetTransactionWithReceiverAndSender(int id)
        {
            return await _ctx.Transactions
                .Include(t=>t.Sender)
                .Include(t=>t.Receiver)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
        //public Task<IEnumerable<Receivers>> GetReceiversBy(int senderId)
        //{
        //    return await _ctx.Senders.Where(s => s.Id == senderId)
        //          .Select(s => s.Receivers).ToListAsync();
        //}
    }
}
