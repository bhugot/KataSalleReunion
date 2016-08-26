using System;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Domain;
using Owin;

namespace Specs
{
    public class Startup
    {
        public static Func<IRooms> Factory { get; set; }

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Services.Replace(typeof(IAssembliesResolver), new TestAssemblyResolver());
            config.Services.Replace(typeof(IHttpControllerActivator),
                new TestControllerActivator(new DefaultHttpControllerActivator(), Factory));
            config.MapHttpAttributeRoutes();
            appBuilder.UseWebApi(config);
        }
    }
}