using SuperTrader.Core.Results;
using SuperTrader.Core.Rule;
using SuperTraderService.Share.Abstract;
using SuperTraderService.SharePriceDetail.DTOs;
using SuperTraderService.Share.Rules.Abstract;
using SuperTrader.Core.Validation;
using SuperTraderService.Share.DTOs.Validation;
using SuperTrader.Core.AOF;
using SuperTraderService.Share.DTOs;
using Data.Repository.Abstract;
using AutoMapper;
using SuperTraderService.Share.Events;

namespace SuperTraderService.Share
{
    public class ServiceShare : IServiceShare
    {
        private readonly IRpShare _rpShare;
        private readonly IMapper _mapper;
        private readonly IRpSharePriceDetail _rpSharePriceDetail;
        private IShareRule _rule { get; }

        public ServiceShare(IShareRule rule,IRpShare rpShare, IMapper mapper,IRpSharePriceDetail rpSharePriceDetail)
        {
            _rule = rule;
            _rpShare = rpShare;
            _mapper = mapper;
            _rpSharePriceDetail = rpSharePriceDetail;
        }

       
        [ValidationAspect(typeof(ShareDtoValidator), Priority = 1)]
        [EventInvokerAspect(typeof(AddShareInvoker))]
        public async Task<IResult> AddShare(ShareDto data)
        {
            var result = await new RuleEnginee().ValidateAsync(
                _rule.IsUserShareHolderAsync(),
                _rule.IsExistInDB(data.Code));

            if (!result.Success) return result;
            var dataShare= _mapper.Map<Data.Entities.Share>(data);

            var entData= await _rpShare.AddAsync(dataShare);
            

            return new SuccessDataResult<ShareDto>(_mapper.Map<SuperTraderService.Share.DTOs.ShareDto>(entData));
        }
        public async Task<IResult> UpdateShareAmount(ShareUpdateDto data)
        {
            var dataShare = _mapper.Map<Data.Entities.Share>(data);
            var entData = await _rpShare.GetAsync(f=>f.Id==data.Id);
            entData.Sold -= data.Amount;
            await _rpShare.UpdateAsync(entData);
            return new SuccessDataResult<ShareUpdateDto>(_mapper.Map<SuperTraderService.Share.DTOs.ShareUpdateDto>(entData));
        }

        public async Task<IDataResult<UpdatePriceDTOs>> GetLastPrice(ShareDto data)
        {
            var dataShare = _mapper.Map<Data.Entities.Share>(data);
            var entData = await _rpSharePriceDetail.GetListAsync(f => f.ShareId == data.Id, o => o.OrderByDescending(g => g.Date), 1);
            return new SuccessDataResult<UpdatePriceDTOs>(_mapper.Map<SuperTraderService.SharePriceDetail.DTOs.UpdatePriceDTOs>(entData.FirstOrDefault()));

        }
    }
}
