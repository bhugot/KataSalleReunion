using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Models;
using Data;
using Domain;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;

namespace Specs
{
    public class RoomsContext
    {
        private IEnumerable<RoomViewModel> _resultRooms;
        private IEnumerable<SlotViewModel> _resultSlots;
        private IRooms _rooms;
        private TestServer _testServer;

        public HttpStatusCode ResponseStatusCode { get; private set; }

        public void InitializeRooms(IEnumerable<Room> rooms)
        {
            this._rooms = new InMemoryRooms(rooms);
            Startup.Factory = () => this._rooms;
            this._testServer = TestServer.Create<Startup>();
        }

        public async Task CallRooms()
        {
            using (var client = new HttpClient(this._testServer.Handler))
            {
                var response = await client.GetAsync("http://testserver/api/rooms").ConfigureAwait(false);

                this.ResponseStatusCode = response.StatusCode;
                var responseContent = await this.ReadContentAsString(response).ConfigureAwait(false);

                this._resultRooms = JsonConvert.DeserializeObject<IEnumerable<RoomViewModel>>(responseContent);
            }
        }

        public async Task<string> ReadContentAsString(HttpResponseMessage response)
        {
            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return stringContent;
        }

        internal IEnumerable<RoomViewModel> GetReturnedRooms()
        {
            return this._resultRooms;
        }


        public async Task BookRoom(string room, string user, DateTime startTime, DateTime endTime)
        {
            var reservation = new ReservationViewModel
            {
                Room = room,
                UserName = user,
                Start = startTime,
                End = endTime
            };
            using (var client = new HttpClient(this._testServer.Handler))
            {
                var model = JsonConvert.SerializeObject(reservation);
                var objectContent = new StringContent(model, Encoding.UTF8, "application/json");

                var response =
                    await client.PostAsync("http://testserver/api/rooms/booking", objectContent).ConfigureAwait(false);
                this.ResponseStatusCode = response.StatusCode;

                var responseContent = await this.ReadContentAsString(response).ConfigureAwait(false);
                if (response.StatusCode != HttpStatusCode.OK)
                    this._resultSlots = JsonConvert.DeserializeObject<IEnumerable<SlotViewModel>>(responseContent);
            }
        }

        public async Task UnbookRoom(string room, string user, DateTime startTime)
        {
            var unbook = new UnbookViewModel
            {
                Room = room,
                UserName = user,
                Start = startTime
            };
            using (var client = new HttpClient(this._testServer.Handler))
            {
                var uri = $"http://testserver/api/rooms/unbook/{room}/{user}/{startTime:O}";
                var response = await client.DeleteAsync(uri).ConfigureAwait(false);
                this.ResponseStatusCode = response.StatusCode;
            }
        }

        public IEnumerable<SlotViewModel> AvailableSlots()
        {
            return this._resultSlots;
        }
    }
}