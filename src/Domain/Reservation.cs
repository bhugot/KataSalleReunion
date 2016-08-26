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

        public TimeSlot NextSlot()
        {
            return this._slot.NextSlot();
        }

        public bool CloseTheDay()
        {
            return this._slot.EndHour() == 24;
        }

        public IEnumerable<int> Hours()
        {
            return this._slot.Hours();
        }
    }
}