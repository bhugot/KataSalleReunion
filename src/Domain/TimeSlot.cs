using System;
using System.Collections.Generic;

namespace Domain
{
    public class TimeSlot : ValueObject
    {
        private readonly DateTime _endHour;
        private readonly DateTime _startHour;
        private readonly int _duration;

        public TimeSlot(DateTime startHour, DateTime endHour)
        {
            if (startHour.Date != endHour.Date && endHour != startHour.Date.AddDays(1)) throw new InvalidOperationException("the slot is not on same date");
            if (startHour > endHour)
                throw new InvalidOperationException("the slot start hour can't be higher than end hour");

            this._startHour = startHour;
            this._endHour = endHour;
            this._duration = (endHour - startHour).Hours;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this._startHour;
            yield return this._endHour;
        }

        public DateTime GetDate()
        {
            return this._startHour.Date.Date;
        }

        public Result ValidateNotInConflict(TimeSlot slot)
        {
            if (slot._startHour >= this._endHour) return Result.Success();
            if (slot._endHour <= this._startHour) return Result.Success();
            return Result.Failed(
                $"the slot is already booked from {slot._startHour.Hour} to {slot._endHour.Hour}");
        }

        public bool Contains(DateTime date)
        {
            return (date >= this._startHour) && (date < this._endHour);
        }

        public TimeSlot Increment()
        {
            return new TimeSlot(this._startHour, this._endHour.AddHours(1));
        }

        public TimeSlot NextSlot()
        {
            return new TimeSlot(this._endHour, this._endHour.AddHours(1));
        }


        public int StartHour()
        {
            return this._startHour.Hour;
        }

        public int EndHour()
        {
            return this._endHour.Hour == 0 ? 24 : this._endHour.Hour;
        }

        public TimeSlot ChangeEnd(int i)
        {
            return new TimeSlot(this._startHour, this._startHour.Date.AddHours(i));
        }

        public IEnumerable<int> Hours()
        {
            for (int i = 0; i < this._duration; i++)
            {
                yield return this._startHour.Hour + i;
            }
        }

        public static TimeSlot ForOneHour(DateTime startHour)
        {
            return new TimeSlot(startHour, startHour.AddHours(1));
        }
    }
}