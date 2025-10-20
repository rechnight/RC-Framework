// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;

namespace RCFramework.Tools
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var item in sequence)
            {
                action(item);
            }
        }

        public static int CountEnumerable(this IEnumerable enumerable)
        {
            int count = 0;
            if (enumerable != null)
            {
                foreach (object _ in enumerable)
                {
                    count++;
                }
            }
            return count;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        public static bool IsNotNullAndEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !IsNullOrEmpty(enumerable);
        }
    }
}