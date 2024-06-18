using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperTraderService.Portfolio.Abstract;
using SuperTraderService.Portfolio.DTOs;
using SuperTraderService.Share.Abstract;
using IResult = SuperTrader.Core.Results.IResult;

namespace SuperTrader.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfoliosController : BaseController
    {
        private IServiceShare _serviceShare;
        private readonly IServicePortfolio _servicePortfolio;

        public PortfoliosController(IServiceShare serviceShare,IServicePortfolio servicePortfolio)
        {
            _serviceShare = serviceShare;
            _servicePortfolio = servicePortfolio;
        }
        
        [HttpPost("SellShare")]
        public async Task<IResult> SellShare(SaleSharesDto data)
        {
            var tkn = await _servicePortfolio.SellShare(data);
            return tkn;
        }
        [Authorize]
        [HttpPost("BuyShare")]
        public async Task<IResult> BuyShare(SaleSharesDto data)
        {
            
            
            var tkn = await _servicePortfolio.BuyShare(data);
            return tkn;
        }
    }
}
