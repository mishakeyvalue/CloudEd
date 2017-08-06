using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudEd.BLL.Helpers
{
    public static class CollectionHelpers
    {
        public static T RandomElement<T>(this IEnumerable<T> collection)
        {
            var r = new Random(DateTime.Now.Millisecond);
            return collection.ElementAt(r.Next(0, collection.Count()));
        }

        public static IEnumerable<T> ToEnumerableOfOne<T>(this T item)
        {
            if (item != null)
                yield return item;
        }
    }
}
