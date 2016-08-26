using System.Collections.Generic;

namespace Domain
{
    public class User : ValueObject
    {
        private readonly Name _name;

        public User(Name name)
        {
            this._name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this._name;
        }
    }
}