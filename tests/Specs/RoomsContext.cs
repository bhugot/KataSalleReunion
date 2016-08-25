using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private IRooms _rooms;
        private IEnumerable<RoomViewModel> _resultRooms;
        private TestServer _testServer;

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
                string responseContent = await this.ReadContentAsString(response).ConfigureAwait(false);

                this._resultRooms = JsonConvert.DeserializeObject<IEnumerable<RoomViewModel>>(responseContent);
            }
        }

        public async Task<string> ReadContentAsString(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return stringContent;
        }

        internal IEnumerable<RoomViewModel> GetReturnedRooms()
        {
            return this._resultRooms;
        }



    }
}