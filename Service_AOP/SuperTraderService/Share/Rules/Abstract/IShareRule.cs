using SuperTrader.Core.Results;

namespace SuperTraderService.Share.Rules.Abstract
{
    public interface IShareRule
    {
        Task<IResult> IsExistInDB(string shareCode);
        Task<IResult> IsUserShareHolderAsync();
    }
}