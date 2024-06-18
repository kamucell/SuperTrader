using SuperTrader.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraderService.Portfolio.Events
{
    public class AddShareToPortfolio : IEventInvoker
    {

        public AddShareToPortfolio()
        {
            BeforeEvents = new List<IEvent>
            {
               
            };
            AfterEvents = new List<IEvent>
            {
                 
                new SendMessage()
            };
        }
    }
}
