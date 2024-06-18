using Data.Entities.Structure;
using Data.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using SuperTrader.Core.Results;
using System.IdentityModel.Tokens.Jwt;
using SuperTraderService.Share.Rules.Abstract;

namespace SuperTraderService.Share.Rules
{
    public class ShareRule : IShareRule
    {
        private readonly IRpShareOwner _shareOwner;
        private readonly IRpShare _IRpShare;

        private IHttpContextAccessor _httpContextAccessor { get; }
        public ShareRule( IRpShareOwner shareOwner,IRpShare share, IHttpContextAccessor httpContextAccessor)
        {
           _httpContextAccessor = httpContextAccessor;
            _shareOwner = shareOwner;
            _IRpShare = share;
        }

        public async Task<IResult> IsExistInDB(string  shareCode)
        {
            var shr = await _IRpShare.GetAsync(f => f.Code == shareCode);
            if (shr != null)
                return new ErrorResult("ShareCodeExists");

            return new SuccessResult("");
        }
        public async Task<IResult> IsUserShareHolderAsync()
        {
            var userType = (EnumUserType)Convert.ToByte(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Typ).Value);
            if (userType == EnumUserType.Seller)
                return new ErrorResult("DoNotHaveRightUpdateShareInfo");
            

            return new SuccessResult("");
        }
       
    }
}
