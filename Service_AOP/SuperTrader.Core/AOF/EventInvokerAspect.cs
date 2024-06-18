using System;
using Castle.DynamicProxy;
using SuperTrader.Core.Event;

namespace SuperTrader.Core.AOF
{
    public class EventInvokerAspect: MethodInterception
    {
        private IEventInvoker _eventInvoker;
        public EventInvokerAspect(Type eventInvoker)
        {
            if (!typeof(IEventInvoker).IsAssignableFrom(eventInvoker))
            {
                throw new System.Exception("WrongInvokerType");
            }

            _eventInvoker = (IEventInvoker) Activator.CreateInstance(eventInvoker);
            
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _eventInvoker.BeforeInvokeInvoke();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            _eventInvoker.AfterInvokeInvoke();
        }
    }
}
