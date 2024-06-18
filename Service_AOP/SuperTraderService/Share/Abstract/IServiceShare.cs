using SuperTrader.Core.Results;
using SuperTraderService.Share.DTOs;
using SuperTraderService.SharePriceDetail.DTOs;

namespace SuperTraderService.Share.Abstract
{
    public interface IServiceShare
    {
        Task<IResult> AddShare(ShareDto data);
        Task<IResult> UpdateShareAmount(ShareUpdateDto data);
         Task<IDataResult<UpdatePriceDTOs>> GetLastPrice(ShareDto data);
    }
}
