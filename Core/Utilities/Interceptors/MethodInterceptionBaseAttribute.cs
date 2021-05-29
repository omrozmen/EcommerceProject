using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {
        public int Priorty { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
            
        }
    }
}
