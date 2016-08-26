using System.Collections.Generic;

namespace Domain
{
    public class Name : ValueObject
    {
        private readonly string _name;

        public Name(string name)
        {
            this._name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this._name;
        }

        public static implicit operator string(Name x)
        {
            return x._name;
        }
    }
}