using SuperTrader.Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraderService.Portfolio.Rules.Abstract
{
    public interface IPortfolioRule
    {
        Task<IResult> IsNotExistsInUserPortfolio(int  shareId);
        Task<IResult> IsExistsInUserPortfolio(int shareId);
        Task<IResult> IsShareExistInDb(int shareId);
        Task<IResult> IsHaveEnoughBalance(int shareId, decimal amount);
        Task<IResult> IsHaveEnoughAmountInStock(int shareId, decimal amount);
    }
}
