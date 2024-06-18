using SuperTrader.Core.Results;
using SuperTraderService.SharePriceDetail.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperTraderService.Portfolio.DTOs;

namespace SuperTraderService.Portfolio.Abstract
{
    public  interface IServicePortfolio
    {
        Task<IResult> AddShareToPortfolio(AddShareDto data);
        Task<IResult> SellShare(SaleSharesDto data);
        Task<IResult> BuyShare(SaleSharesDto data);
    }
}
