using System.Web.Http;

namespace BabyFoot.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new CustomHandler());
            UnityConfig.RegisterComponents();
        }
    }
}
