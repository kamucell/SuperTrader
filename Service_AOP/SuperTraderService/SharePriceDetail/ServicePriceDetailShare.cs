using AutoMapper;
using Azure.Identity;
using Data.Entities;
using Data.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using SuperTrader.Core.Results;
using SuperTrader.Core.Rule;
using SuperTraderService.Share.Abstract;
using SuperTraderService.SharePriceDetail.Abstract;
using SuperTraderService.SharePriceDetail.DTOs;
using SuperTraderService.SharePriceDetail.Rules;
using System.Data;

namespace SuperTraderService.SharePriceDetail
{
    public class ServicePriceDetailShare : IServiceSharePriceDetail
    {
        private readonly IRpSharePriceDetail _rpPriceDetail;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISharePriceDetailRule _rule;
        private readonly int _userId;

        public ServicePriceDetailShare(ISharePriceDetailRule rule,IRpSharePriceDetail rpPriceDetail,IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _rule = rule;
            _rpPriceDetail = rpPriceDetail;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First().Value);
        }

        

        public async Task<IResult> UpdatSharePriceAsync(UpdatePriceDTOs data)
        {
            var result = await new RuleEnginee().ValidateAsync(
                _rule.IsUserShareHolderAsync(),
                _rule.IsTimesUpForUpdatePriceAsync(data.ShareId));
            
            if (!result.Success) return result;
            data.UserId = _userId;
            
            await _rpPriceDetail.AddAsync(_mapper.Map<Data.Entities.SharePriceDetail>(data));
            return new  SuccessResult();
        }
    }
}
