namespace BabyFoot.Common.Context
{
    public interface IApplicationContext
    {
        string Data { get; set; }

        int RequestCounter { get; }
        
        void IncrementCounter();
    }
}
