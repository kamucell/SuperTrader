using SuperTrader.Core.Results;

namespace SuperTraderService.SharePriceDetail.Rules
{
    public interface ISharePriceDetailRule
    {
        Task<IResult> IsTimesUpForUpdatePriceAsync(int shareId);
        Task<IResult> IsUserShareHolderAsync();
    }
}