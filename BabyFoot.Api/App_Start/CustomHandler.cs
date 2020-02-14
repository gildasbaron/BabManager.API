using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BabyFoot.Common.Context;

namespace BabyFoot.Api
{
    public class CustomHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var notIdentifiedUser = 
                string.IsNullOrEmpty(request.GetRequestContext().Principal.Identity.Name) 
                    ? "not_identified_user_" + DateTime.Now.Ticks
                    : request.GetRequestContext().Principal.Identity.Name;

            var scope = request.GetDependencyScope();
            var requestContext = (IRequestContextInfo)scope.GetService(typeof(IRequestContextInfo));
            var applicationContext = (IApplicationContext)scope.GetService(typeof(IApplicationContext));

            applicationContext.IncrementCounter();
           
            requestContext.RequestId = $"request{applicationContext.RequestCounter}";
            requestContext.User = notIdentifiedUser;

            //let other handlers process the request
            return  base.SendAsync(request, cancellationToken);
        }
    }
}