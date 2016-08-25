using System.Web.Http;
using System.Web.Http.Dispatcher;
using Owin;

namespace ApiHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Services.Replace(typeof(IAssembliesResolver), new TestAssemblyResolver());
            config.MapHttpAttributeRoutes();
            appBuilder.UseWebApi(config);
        }
    }
}