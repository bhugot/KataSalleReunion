using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http.Dispatcher;
using Api.Controllers;

namespace ApiHost
{
    public class TestAssemblyResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            return base.GetAssemblies().Union(this.GetControllersAssembly()).ToArray();
        }

        private IEnumerable<Assembly> GetControllersAssembly()
        {
            yield return typeof(RoomsController).Assembly;
        }
    }
}