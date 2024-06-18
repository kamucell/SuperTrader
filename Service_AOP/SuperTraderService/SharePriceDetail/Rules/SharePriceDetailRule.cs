using Data.Entities.Structure;
using Data.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using SuperTrader.Core.Results;
using SuperTraderService.SharePriceDetail.Abstract;
using System.IdentityModel.Tokens.Jwt;

namespace SuperTraderService.SharePriceDetail.Rules
{
    public class SharePriceDetailRule :      ISharePriceDetailRule

    {
        private readonly IRpShareOwner _shareOwner;
        private readonly IRpSharePriceDetail _sharePriceDetail;

        private IHttpContextAccessor _httpContextAccessor { get; }
        public SharePriceDetailRule(IHttpContextAccessor httpContextAccessor, IRpShareOwner shareOwner, IRpSharePriceDetail sharePriceDetail)
        {
            _httpContextAccessor = httpContextAccessor;
            _shareOwner = shareOwner;
            _sharePriceDetail = sharePriceDetail;
        }

        public async Task<IResult> IsTimesUpForUpdatePriceAsync(int shareId)
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First().Value);
            var shareDtl = await _sharePriceDetail.GetLastPriceOfShareAsync(shareId);
            if (!shareDtl.Any()) return new ErrorResult("InvalidShare");
            if (shareDtl.FirstOrDefault().UpdatedBy != userId) return new ErrorResult("DoNotHaveRightUpdateShareInfo");
            if (shareDtl.FirstOrDefault().Date.AddHours(1) > DateTime.Now) return new ErrorResult("YouHaveToWaitForUpdate");
            return new SuccessResult("");
        }
        public async Task<IResult> IsUserShareHolderAsync()
        {
            var userType = await Task.Run(() => (EnumUserType)Convert.ToByte(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Typ)?.Value));
            if (userType == EnumUserType.Seller)
                return new ErrorResult("DoNotHaveRightUpdateShareInfo");

            return new SuccessResult("");
        }
        
    }
}
