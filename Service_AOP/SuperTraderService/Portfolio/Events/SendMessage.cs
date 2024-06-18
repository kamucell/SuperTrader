using SuperTrader.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperTrader.Core.Results;

namespace SuperTraderService.Portfolio.Events
{
    public class SendMessage : IEvent

    {
        public async Task<IResult> Execute()
        {
            Task.Delay(100);
            return new SuccessResult();
        }
    }
}
