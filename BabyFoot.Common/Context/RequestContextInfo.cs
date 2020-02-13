using System;

namespace BabyFoot.Common.Context
{
    public class RequestContextInfo : IRequestContextInfo
    {
        public RequestContextInfo()
        {
            ContextId = Guid.NewGuid();
        }

        public string User { get; set; }

        public string RequestId { get; set; }

        public Guid ContextId { get; set; }
    }
}
