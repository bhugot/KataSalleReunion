using System;
using System.Collections.Generic;

namespace Domain
{
    public class Reservations
    {
        private readonly IDictionary<DateTime, RoomDayReservation> _reservations;

        public Reservations()
        {
            this._reservations = new Dictionary<DateTime, RoomDayReservation>();
        }

        public Result Reserver(User user, TimeSlot slot)
        {
            var date = slot.GetDate();
            RoomDayReservation existingReservations;
            if (!this._reservations.TryGetValue(date, out existingReservations))
            {
                existingReservations = new RoomDayReservation(date);
                
                this._reservations.Add(date, existingReservations);
                
            }
            return existingReservations.Book(user, slot);
            
        }

        public void Unbook(DateTime startDate)
        {
            var date = startDate.Date;
            if (!this._reservations.ContainsKey(date)) return;
            var reservationsOndate = this._reservations[date];
            reservationsOndate.Unbook(startDate);
            
        }

        public IEnumerable<TimeSlot> GetAvailableTimeSlot(DateTime startDate)
        {
            var date = startDate.Date;
            RoomDayReservation reservationsOndate;
            if (!this._reservations.TryGetValue(date, out reservationsOndate))
            {
                reservationsOndate = new RoomDayReservation(date);
                
            }
            return reservationsOndate.GetAvailableSlots();
        }
    }
}