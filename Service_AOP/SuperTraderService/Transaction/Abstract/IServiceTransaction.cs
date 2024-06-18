using SuperTrader.Core.Results;
using SuperTraderService.Transaction.DTOs;

namespace SuperTraderService.Transaction.Abstract
{
    public interface IServiceTransaction
    {
        Task<IResult> AddTransaction(TransactionDto data);
    }
}
