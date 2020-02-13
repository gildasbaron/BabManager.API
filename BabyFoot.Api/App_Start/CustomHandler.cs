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
            //let other handlers process the request
            return  base.SendAsync(request, cancellationToken);
        }
    }
}