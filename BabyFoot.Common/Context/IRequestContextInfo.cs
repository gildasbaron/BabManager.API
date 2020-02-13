using System;

namespace BabyFoot.Common.Context
{
    public interface IRequestContextInfo
    {
        string User { get; set; }
        
        string RequestId { get; set; }

        Guid ContextId { get; set; }
    }
}
