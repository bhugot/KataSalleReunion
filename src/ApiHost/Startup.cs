using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;

namespace ApiHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Services.Replace(typeof(IAssembliesResolver), new TestAssemblyResolver());
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