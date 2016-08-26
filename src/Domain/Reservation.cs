using System;
using System.Collections.Generic;

namespace Domain
{
    public class Reservation
    {
        private readonly TimeSlot _slot;
        private readonly User _user;

        public Reservation(User user, TimeSlot slot)
        {
            this._user = user;
            this._slot = slot;
        }

        public Result ValidateSlot(TimeSlot slot)
        {
           return this._slot.ValidateNotInConflict(slot);
        }

        public bool Contains(DateTime date)
        {
            return this._slot.Contains(date);
        }

        public IEnumerable<TimeSlot> GetOneHourSlots()
        {
            return this._slot.GetOneHourSlots();
        }
    }
}