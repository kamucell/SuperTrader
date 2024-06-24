using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SuperTrader.Service.Future.Share.DTOs;

namespace SuperTrader.Service.Future.Share.Query
{
    public class GetShareListQuery : IRequest<ShareListDto>
    {
        public int Id { get; set; }
    }
}
