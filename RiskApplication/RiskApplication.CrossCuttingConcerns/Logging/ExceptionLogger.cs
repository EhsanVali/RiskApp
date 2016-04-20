using System;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace RiskApplication.CrossCuttingConcerns.Logging
{
    public class ExceptionLogger : IInterceptor
    {
        readonly ILogger _log;

        public ExceptionLogger(ILogger log)
        {
            _log = log;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                var message = $"Method '{invocation.Method.Name}' of class '{invocation.TargetType.Name}' failed.";
                _log.Error(message, e);
                throw;
            }
        }
    }
}