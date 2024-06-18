using SuperTrader.Core.Results;
using SuperTraderService.Transaction.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperTraderService.Transaction.DTOs;
using AutoMapper;
using Data.Repository.Abstract;

namespace SuperTraderService.Transaction
{
    public  class ServiceTransaction : IServiceTransaction
    {
        private readonly IRpTransaction _rpTransaction;
        private readonly IMapper _mapper;

        public ServiceTransaction(IRpTransaction rpTransaction, IMapper mapper)
        {
            _rpTransaction = rpTransaction;
            _mapper = mapper;
        }
        public async Task<IResult> AddTransaction(TransactionDto data)
        {
            var dtItem = _mapper.Map<Data.Entities.Transaction>(data);
            var itm =await _rpTransaction.AddAsync(dtItem);
            return new SuccessDataResult<TransactionDto>(_mapper.Map<TransactionDto>(itm));
        }
    }
}
