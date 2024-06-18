using System.IdentityModel.Tokens.Jwt;
using SuperTraderService.Portfolio.Abstract;
using SuperTrader.Core.Results;
using SuperTrader.Core.AOF;
using SuperTrader.Core.Rule;
using SuperTrader.Core.Validation;
using SuperTraderService.Share.DTOs.Validation;
using SuperTraderService.Share.DTOs;
using AutoMapper;
using SuperTraderService.Portfolio.Rules.Abstract;
using SuperTraderService.Portfolio.Events;
using SuperTraderService.Portfolio.DTOs;
using SuperTraderService.Transaction.Abstract;
using SuperTraderService.Share.Abstract;
using Data.Repository.Abstract;
using SuperTraderService.Portfolio.DTOs.Validation;
using Microsoft.AspNetCore.Http;
using Data.Entities;
using Data.Entities.Structure;

namespace SuperTraderService.Portfolio
{
    public class ServicePortfolio: IServicePortfolio
    {
        private readonly IServiceShare _serviceShare;
        private readonly IRpPortfolio _rpPortfolio;
        private readonly IPortfolioRule _rule;
        private readonly IMapper _mapper;
        private readonly IServiceTransaction _serviceTransaction;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly int _userId;

        public ServicePortfolio(IServiceShare serviceShare, IRpPortfolio rpPortfolio, IPortfolioRule rule, IMapper mapper, 
            IServiceTransaction serviceTransaction,
            IHttpContextAccessor httpContextAccessor)
        {
            
            _serviceShare = serviceShare;
            _rpPortfolio = rpPortfolio;
            _rule = rule;
            _mapper = mapper;
            _serviceTransaction = serviceTransaction;
            _httpContextAccessor = httpContextAccessor;
            _userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.First().Value);
        }
        [ValidationAspect(typeof(ShareDtoValidator), Priority = 1)]
        [EventInvokerAspect(typeof(AddShareToPortfolio))]
         
        public async Task<IResult> AddShareToPortfolio(AddShareDto data)
        {
            var result = await new RuleEnginee().ValidateAsync(
                _rule.IsShareExistInDb(data.ShareId),
                _rule.IsNotExistsInUserPortfolio(data.ShareId));

            if (!result.Success) return result;
           
            
            var dataShare = _mapper.Map<Data.Entities.Portfolio>(data);

            var entData = await _rpPortfolio.AddAsync(dataShare);


            return new SuccessDataResult<AddShareDto>(_mapper.Map<AddShareDto>(entData));
        }

 

        [ValidationAspect(typeof(SaleSharesDtoValidator), Priority = 1)]
        [EventInvokerAspect(typeof(SellOrBuyEvent))]
        [TransactionScopeAspect]
        public async Task<IResult> SellShare(SaleSharesDto data)
        {
            
            var result = await new RuleEnginee().ValidateAsync(
                            _rule.IsShareExistInDb(data.ShareId),
                                       _rule.IsExistsInUserPortfolio(data.ShareId),
                                       _rule.IsHaveEnoughBalance(data.ShareId,data.Amount));
            if (!result.Success) return result;

            var dtPorft= await UpdateTransactionandPortfolio(data, _userId,EnumTransactionType.Sell);
            return new SuccessDataResult<SaleSharesDto>(_mapper.Map<SaleSharesDto>(dtPorft));
        }


        
        [ValidationAspect(typeof(SaleSharesDtoValidator), Priority = 1)]
        [EventInvokerAspect(typeof(SellOrBuyEvent))]
        public async Task<IResult> BuyShare(SaleSharesDto data)
        {
            var result = await new RuleEnginee().ValidateAsync(
                _rule.IsShareExistInDb(data.ShareId),
                            _rule.IsExistsInUserPortfolio(data.ShareId),
                            _rule.IsHaveEnoughAmountInStock(data.ShareId,data.Amount)
                );
            
            if (!result.Success) return result;
            var dtPorft = await UpdateTransactionandPortfolio(data, _userId, EnumTransactionType.Buy);
            return new SuccessDataResult<SaleSharesDto>(_mapper.Map<SaleSharesDto>(dtPorft));
        }
        [TransactionScopeAspect]
        private async Task<Data.Entities.Portfolio> UpdateTransactionandPortfolio(SaleSharesDto data, int userId,
            EnumTransactionType transactionType)
        {
            var entData = await _serviceShare.UpdateShareAmount(new ShareUpdateDto()
            {
                Amount = ((transactionType == EnumTransactionType.Sell) ? 1 : -1) * data.Amount,
                Id = data.ShareId
            });

            var dtSharePrice = await _serviceShare.GetLastPrice(new ShareDto() { Id = data.ShareId });
            await _serviceTransaction.AddTransaction(new Transaction.DTOs.TransactionDto()
            {
                Amount = ((transactionType == EnumTransactionType.Sell) ? -1 : 1) * data.Amount,
                ShareId = data.ShareId,
                TransactionType = Data.Entities.Structure.EnumTransactionType.Buy,
                Price = dtSharePrice.Data.Price,
                UserId = _userId
            });

            var dtPorft = await _rpPortfolio.GetAsync(f => f.UserId == _userId && f.ShareId == data.ShareId);
            dtPorft.Quantity += ((transactionType == EnumTransactionType.Sell) ? -1 : 1) * data.Amount;
            await _rpPortfolio.UpdateAsync(dtPorft);
            return dtPorft;
        }

    }
}
