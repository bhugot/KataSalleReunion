using System.Collections.Generic;

namespace Domain
{
    public interface IRooms
    {
        IEnumerable<Room> GetAvailableRooms();
        Room GetRoom(Name name);
    }
}