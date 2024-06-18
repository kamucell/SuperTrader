using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using SuperTrader.Core.Logging;

namespace SuperTrader.Core.AOF
{
    public class ExceptionLogAspect:MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType!=typeof(LoggerServiceBase))
            {
              
            }

            
        }
        protected override void OnException(IInvocation invocation,System.Exception e)
        {
            
        }

        
    }
}
