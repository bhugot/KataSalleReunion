using System.Collections.Generic;

namespace Domain
{
    public interface IRooms
    {
        IEnumerable<Room> GetAvailableRooms();
    }
}