using System;
using System.Collections.Generic;

namespace KeePassLib.Utility
{
    static class Arrays
    {
        public static void ForEach<T>(
            this IEnumerable<T> source,
            Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }
    }
}
