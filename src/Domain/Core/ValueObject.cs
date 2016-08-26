using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public abstract class ValueObject
    {
        /// <summary>
        ///     When overriden in a derived class, returns all components of a value objects which constitute its identity.
        /// </summary>
        /// <returns>An ordered list of equality components.</returns>
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (this.GetType() != obj.GetType()) return false;
            var vo = (ValueObject) obj;
            return this.GetEqualityComponents().SequenceEqual(vo.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(this.GetEqualityComponents());
        }

        public static bool operator ==(ValueObject valueObject, ValueObject valueObject2)
        {
            return Equals(valueObject, valueObject2);
        }

        public static bool operator !=(ValueObject valueObject, ValueObject valueObject2)
        {
            return !Equals(valueObject, valueObject2);
        }
    }
}