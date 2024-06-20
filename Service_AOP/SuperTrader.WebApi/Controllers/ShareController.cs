using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperTraderService.Portfolio.Abstract;
using SuperTraderService.Portfolio.DTOs;
using SuperTraderService.Share.Abstract;
using SuperTraderService.Share.DTOs;
using SuperTraderService.SharePriceDetail.Abstract;
using SuperTraderService.SharePriceDetail.DTOs;
using IResult = SuperTrader.Core.Results.IResult;

namespace SuperTrader.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : BaseController
    {
        private IServiceShare _serviceShare;
        private readonly IServicePortfolio _servicePortfolio;
        private readonly IServiceSharePriceDetail _serviceSharePriceDetail;

        private readonly int _userId;

        public ShareController(IServiceShare serviceShare,IServicePortfolio servicePortfolio, IServiceSharePriceDetail serviceSharePriceDetail)
        {
            _serviceShare = serviceShare;
            _servicePortfolio = servicePortfolio;
            _serviceSharePriceDetail = serviceSharePriceDetail;


        }
        [HttpPost( "AddShare")]
        [Authorize]
        public async  Task<IResult> AddShare(ShareDto data)
        {
            var tkn = await _serviceShare.AddShare(data);
            return tkn;
        }
        [HttpPost("AddToPortfolios")]
        [Authorize]
        public async Task<IResult> AddToPortfolios(AddShareDto data)
        {
            var tkn = await _servicePortfolio.AddShareToPortfolio(data);
            return tkn;
        }
        [HttpPost("UpdatePrice")]
               
        public async Task<IResult> UpdatePrice(UpdatePriceDTOs data)
        {
            data.UserId = _userId;
            var tkn = await _serviceSharePriceDetail.UpdatSharePriceAsync(data);
            return tkn;
        }
    }
}
