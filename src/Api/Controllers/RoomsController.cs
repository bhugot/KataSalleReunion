using System;
using System.Linq;
using System.Web.Http;
using Api.Models;
using Data;
using Domain;

namespace Api.Controllers
{
    [RoutePrefix("api/rooms")]
    public class RoomsController : ApiController
    {
        private readonly IRooms _rooms;

        public RoomsController(IRooms rooms)
        {
            this._rooms = rooms;
        }

        public RoomsController()
            : this(new InMemoryRooms(Enumerable.Range(0, 10).Select(a => new Room($"room{a}"))))
        {
        }

        [Route]
        public IHttpActionResult GetRooms()
        {
            try
            {
                var rooms = this._rooms.GetAvailableRooms().Select(a => new RoomViewModel { Name = a.Name });

                return this.Ok(rooms);
            }
            catch (Exception exception)
            {
                return this.InternalServerError(exception);
            }
            
        }
    }
}