using SuperTraderService.Portfolio.Rules.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperTrader.Core.Results;
using Data.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Data.Entities.Structure;
using Microsoft.IdentityModel.JsonWebTokens;

namespace SuperTraderService.Portfolio.Rules
{
    public class PortfolioRule: IPortfolioRule
    {
        private readonly IRpPortfolio _rpProfolio;
        private readonly IRpShare _share;
        private IHttpContextAccessor _httpContextAccessor { get; }
        public PortfolioRule(IRpPortfolio rpProfolio, IRpShare share, IHttpContextAccessor httpContextAccessor)
        {
            _rpProfolio = rpProfolio;
            _share = share;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IResult> IsNotExistsInUserPortfolio(int shareId)
        {
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First().Value);
            var dtProfolio =  await _rpProfolio.GetAsync(x => x.UserId == userId && x.ShareId == shareId);
            if (dtProfolio is not null) return new ErrorResult("ShareDoExistInPortfolio");
            return new SuccessResult();
        }

        public async Task<IResult> IsShareExistInDb(int shareId)
        {
            var dtShare = await _share.GetAsync(x => x.Id == shareId);
            if (dtShare is null) return new ErrorResult("ShareDoNotExistInDB");
            return new SuccessResult();
        }

        public async Task<IResult> IsHaveEnoughBalance(int shareId,decimal amount)
        {
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First().Value);
            var dtProfolio = await _rpProfolio.GetAsync(x => x.UserId == userId && x.ShareId == shareId);
            if(dtProfolio.Quantity -amount<0 ) return new ErrorResult("DoNotHaveEnoughBalanceForSale");
            return new SuccessResult();
        }
        public async Task<IResult> IsHaveEnoughAmountInStock(int shareId, decimal amount)
        {
            var dtProfolio = await _share.GetAsync(x => x.Id == shareId);
            if (dtProfolio.Remain < amount) return new ErrorResult("DoNotHaveEnoughAmountInStock");
            return new SuccessResult();
        }
        public async Task<IResult> IsExistsInUserPortfolio(int shareId)
        {
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First().Value);
            var dtProfolio = await _rpProfolio.GetAsync(x => x.UserId == userId && x.ShareId == shareId);
            if (dtProfolio is null) return new ErrorResult("ShareDoNotExistInPortfolio");
            return new SuccessResult();
        }

    }
}
