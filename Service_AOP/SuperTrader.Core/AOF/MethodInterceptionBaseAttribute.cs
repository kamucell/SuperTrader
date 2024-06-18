using System;

namespace SuperTrader.Core.AOF
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, Castle.DynamicProxy.IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(Castle.DynamicProxy.IInvocation invocation)
        {

        }
    }
}
