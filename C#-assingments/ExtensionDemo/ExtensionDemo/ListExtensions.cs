using System;
using System.Collections.Generic;

namespace ExtensionDemo
{
    public static class ListExtensions
    {
        // 1️⃣ Print all elements
        public static void PrintAll<T>(this List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        // 2️⃣ Sum all integers
        public static int SumAll(this List<int> list)
        {
            int sum = 0;
            foreach (int n in list)
                sum += n;

            return sum;
        }

        // 3️⃣ Add only if not exists
        public static void AddIfNotExists<T>(this List<T> list, T value)
        {
            if (!list.Contains(value))
            {
                list.Add(value);
            }
        }
    }
}
