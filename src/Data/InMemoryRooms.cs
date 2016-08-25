using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Data
{
    public class InMemoryRooms : IRooms
    {
        private readonly IEnumerable<Room> _rooms;

        public InMemoryRooms(IEnumerable<Room> rooms)
        {
            this._rooms = rooms.ToArray();
        }

        public IEnumerable<Room> GetAvailableRooms()
        {
            return this._rooms;
        }
    }
}
