using MediatR;
using SuperTrader.Service.Future.Share.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTrader.Service.Future.Share.Query.GetShareList
{
    public class GetShareListQueryRequestHandler : IRequestHandler<GetShareListQuery, ShareListDto>
    {
        public Task<ShareListDto> Handle(GetShareListQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}
