using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    internal static class HashCodeHelper
    {
        public static int CombineHashCodes(IEnumerable<object> objs)
        {
            unchecked
            {
                return objs.Aggregate(17, (current, obj) => current*23 + (obj != null ? obj.GetHashCode() : 0));
            }
        }
    }
}