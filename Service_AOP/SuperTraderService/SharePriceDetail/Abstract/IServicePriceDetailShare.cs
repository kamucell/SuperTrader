using SuperTrader.Core.Results;
using SuperTraderService.SharePriceDetail.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraderService.SharePriceDetail.Abstract
{
    public interface IServiceSharePriceDetail
    {
          Task<IResult> UpdatSharePriceAsync(UpdatePriceDTOs data);
    }
}
