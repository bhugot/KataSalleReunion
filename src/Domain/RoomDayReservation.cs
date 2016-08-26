using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class RoomDayReservation
    {
        private readonly DateTime _date;
        private readonly List<TimeSlot> _availableSlots;
        private readonly List<Reservation> _booked;
        public RoomDayReservation(DateTime date)
        {
            this._date = date;
            this._availableSlots = Enumerable.Range(0, 24).Select(s => TimeSlot.ForOneHour(date.AddHours(s))).ToList();
            this._booked = new List<Reservation>();
        }

        public IEnumerable<TimeSlot> GetAvailableSlots()
        {
            return this._availableSlots.AsReadOnly();
        }

        public Result Book(User user, TimeSlot slot)
        {
            foreach (var existing in _booked)
            {
                var result = existing.ValidateSlot(slot);
                if (result.IsInError) return result;
            }
            this.RemoveUsedSlot(slot);

            _booked.Add(new Reservation(user, slot));
            return Result.Success();
        }

        private void RemoveUsedSlot(TimeSlot slot)
        {
            foreach (var oneHourSlot in slot.GetOneHourSlots())
            {
                this._availableSlots.Remove(oneHourSlot);
            }
           
        }

        public void Unbook(DateTime startDate)
        {
            var reservation = this._booked.FirstOrDefault(b => b.Contains(startDate));
            if (reservation == null) return;
            this._booked.Remove(reservation);
            this.MakeAvalaible(reservation.GetOneHourSlots());
        }

        private void MakeAvalaible(IEnumerable<TimeSlot> slots)
        {
            this._availableSlots.InsertRange(slots.First().StartHour() ,slots);
        }
    }
}