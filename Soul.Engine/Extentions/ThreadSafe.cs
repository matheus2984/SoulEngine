using System.Collections.Generic;

namespace Soul.Engine.Extentions
{
    public static partial class Extentions
    {
        public static void ThreadSafeAdd<T, T2>(this Dictionary<T, T2> dictionary, T key, T2 value)
        {
            lock (dictionary)
            {
                if (dictionary.ContainsKey(key))
                    dictionary[key] = value;
                else
                    dictionary.Add(key, value);
            }
        }

        public static void ThreadSafeRemove<T, T2>(this Dictionary<T, T2> dictionary, T key)
        {
            lock (dictionary)
            {
                dictionary.Remove(key);
            }
        }

        public static T2[] ThreadSafeValueArray<T, T2>(this Dictionary<T, T2> dictionary)
        {
            lock (dictionary)
            {
                var values = new T2[dictionary.Count];
                dictionary.Values.CopyTo(values, 0);
                return values;
            }
        }
    }
}