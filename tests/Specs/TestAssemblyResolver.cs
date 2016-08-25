using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Api.Controllers;
using Domain;

namespace Specs
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

    public class TestControllerActivator  : IHttpControllerActivator
    {
        private readonly IHttpControllerActivator _decorated;
        private readonly Func<IRooms> _roomsRepositoryFactory;

        public TestControllerActivator(IHttpControllerActivator  decorated, Func<IRooms> roomsRepositoryFactory)
        {
            this._decorated = decorated;
            this._roomsRepositoryFactory = roomsRepositoryFactory;
        }
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType ==  typeof(RoomsController))
            {
                return new RoomsController(_roomsRepositoryFactory());
            }
            return this._decorated.Create(request, controllerDescriptor, controllerType);
        }
    }
}