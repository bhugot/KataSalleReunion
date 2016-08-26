using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Reservations
    {
        private readonly IDictionary<DateTime, List<Reservation>> _reservations;

        public Reservations()
        {
            this._reservations = new Dictionary<DateTime, List<Reservation>>();
        }

        public Result Reserver(User user, TimeSlot slot)
        {
            var date = slot.GetDate();
            List<Reservation> existingReservations;
            if (!this._reservations.TryGetValue(date, out existingReservations))
            {
                this._reservations.Add(date, new List<Reservation> {new Reservation(user, slot)});
                return Result.Success();
            }
            foreach (var existing in existingReservations)
            {
                var result = existing.ValidateSlot(slot);
                if(result.IsInError) return result;
            }
            existingReservations.Add(new Reservation(user, slot));
            return Result.Success();
        }

        public void Unbook(DateTime startDate)
        {
            var date = startDate.Date;
            if (!this._reservations.ContainsKey(date)) return;
            var reservationsOndate = this._reservations[date];
            var reservation = reservationsOndate.FirstOrDefault(a => a.Contains(date));
            if (reservation == null) return;
            reservationsOndate.Remove(reservation);
        }

        public IEnumerable<TimeSlot> GetAvailableTimeSlot(DateTime startDate)
        {
            var date = startDate.Date;
            List<Reservation> reservationsOndate;
            if (!this._reservations.TryGetValue(date, out reservationsOndate) || reservationsOndate.Count == 0)
                return Enumerable.Range(0, 24).Select(s => TimeSlot.ForOneHour(date.AddHours(s)));

            var hours = Enumerable.Range(0, 24)
                .Except(reservationsOndate.SelectMany(r => r.Hours()))
                .Select(s => TimeSlot.ForOneHour(date.AddHours(s)));

            return hours;
        }
    }
}