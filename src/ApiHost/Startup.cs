using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Data;
using Domain;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;

namespace ApiHost
{
    public class Startup
    {
        private static IRooms _rooms;
        private static Func<IRooms> _roomsFactory = () => _rooms;

        static Startup()
        {
            _rooms = new InMemoryRooms(Enumerable.Range(0, 10).Select(a => new Room(new Name($"room{a}"))));
        }

        public void Configuration(IAppBuilder appBuilder)
        {

            var config = new HttpConfiguration();
            config.Services.Replace(typeof(IAssembliesResolver), new TestAssemblyResolver());
            config.Services.Replace(typeof(IHttpControllerActivator),
                            new TestControllerActivator(new DefaultHttpControllerActivator(), _roomsFactory));
            config.MapHttpAttributeRoutes();
            config.EnableSwagger(c => c.SingleApiVersion("1.0", "Meeting Room Booking Api"))
                .EnableSwaggerUi();
            appBuilder.Use<DebugLogMiddleware>();
            appBuilder.UseWebApi(config);
        }
    }

    public class DebugLogMiddleware : OwinMiddleware
    {
        public DebugLogMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            Debug.WriteLine($"Starting query : {context.Request.Method}, {context.Request.Uri}");
            await this.Next.Invoke(context);
            Debug.WriteLine(
                $"Ending query : {context.Request.Method}, {context.Request.Uri}, {context.Response.StatusCode}");
        }
    }
}