using System;
using System.Collections.Generic;

namespace Domain
{
    public class Room
    {
        public Reservations Reservations;

        public Room(Name name)
        {
            this.Reservations = new Reservations();
            this.Name = name;
        }

        public Name Name { get; }

        public Result Book(User user, TimeSlot slot)
        {
            return this.Reservations.Reserver(user, slot);
        }

        public void Unbook(DateTime startDate)
        {
            this.Reservations.Unbook(startDate);
        }

        public IEnumerable<TimeSlot> GetAvailableTimeSlot(DateTime modelStart)
        {
            return this.Reservations.GetAvailableTimeSlot(modelStart);
        }
    }
}