using System.Collections.Generic;

namespace SuperTrader.Core.Event
{
    public abstract class IEventInvoker
    {
        public IEnumerable<IEvent> BeforeEvents { get; set; }
        public IEnumerable<IEvent> AfterEvents { get; set; }

        public void BeforeInvokeInvoke()
        {
            foreach (var evnt in BeforeEvents ?? new List<IEvent>())
            {
                evnt.Execute();
            }
        }
        public void AfterInvokeInvoke()
        {
            foreach (var evnt in AfterEvents?? new List<IEvent>())
            {
                evnt.Execute();
            }
        }

    }
}
