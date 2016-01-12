using System.Collections.Generic;
using System.Linq;

namespace WTManager.Helpers
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable) {
            if (enumerable == null)
                return true;

            return !enumerable.Any();
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection) {
            return new HashSet<T>(collection);
        }
    }
}
