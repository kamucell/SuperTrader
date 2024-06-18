using SuperTrader.Core.Event;
using SuperTrader.Core.Results;

namespace SuperTraderService.Share.Events
{
    public class AddShareInvoker : IEventInvoker
    {
        public AddShareInvoker(/*ISend send*/)
        {
            BeforeEvents = new List<IEvent>();
            AfterEvents = new List<IResult>
                {
                     //send.Send(new List<ReceiverInfo>(), "")
                };
        }

        public List<IEvent> BeforeEvents { get; set; }
        public List<IResult> AfterEvents { get; set; }
    }
    
}
