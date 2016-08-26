using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Api.Extensions;
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
            : this(new InMemoryRooms(Enumerable.Range(0, 10).Select(a => new Room(new Name($"room{a}")))))
        {
        }

        [Route]
        public IHttpActionResult GetRooms()
        {
            try
            {
                var rooms = this._rooms.GetAvailableRooms().Select(a => new RoomViewModel {Name = a.Name});

                return this.Ok(rooms);
            }
            catch (Exception exception)
            {
                return this.InternalServerError(exception);
            }
        }

        [Route("booking")]
        [HttpPost]
        public IHttpActionResult GetRooms([FromBody] ReservationViewModel model)
        {
            if (!this.ModelState.IsValid)
                return new InvalidModelStateResult(this.ModelState, this);
            // if authentication was setup i would have use following informations instead of passing it in model
            //var name = User.Identity.Name
            try
            {
                var room = this._rooms.GetRoom(new Name(model.Room));
                if (room == null) return this.NotFound();
                var result = room.Book(new User(new Name(model.UserName)), new TimeSlot(model.Start, model.End));
                if (result.IsInError)
                {
                    var slots =
                    room.GetAvailableTimeSlot(model.Start)
                        .Select(
                            a =>
                                new SlotViewModel
                                {
                                    Start = a.StartHour().ToDisplayHour(),
                                    End = a.EndHour().ToDisplayHour()
                                })
                        .ToList();


                    return this.Content(HttpStatusCode.Conflict, slots);
                }
                return this.Ok();
            }
            catch (Exception exception)
            {
                return this.InternalServerError(exception);
            }
        }

        [Route("unbook/{roomName}/{userName}/{startDate}")]
        [HttpDelete]
        public IHttpActionResult DeleteRoom(string roomName, DateTime startDate)
        {
            // I don't have control if reservation is at user name
            try
            {
                var room = this._rooms.GetRoom(new Name(roomName));
                if (room == null) return this.NotFound();
                room.Unbook(startDate);
                return this.Ok(); // I put ok as I don't have api to display reservation
            }
            catch (Exception exception)
            {
                return this.InternalServerError(exception);
            }
        }
    }
}