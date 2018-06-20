using System.Collections.Generic;
using System.Threading.Tasks;
using GrandXpress.Domain.Entities;

namespace GrandXpress.API.Repositories
{
    public interface ITransactionRepo
    {
        Task<IEnumerable<Transaction>> GetTransactions();
        Task<Transaction> GetTransactionWithReceiverAndSender(int id);
    }
}