using System.Collections.Generic;

namespace Soul.Engine.Extentions
{
    public static partial class Extentions
    {
        private static readonly Dictionary<int, string> Values = new Dictionary<int, string>
        {
            {0, "0"},
            {1, "1"},
            {2, "2"}
        };

        public static string ToFastString(this int value)
        {
            string str;
            return Values.TryGetValue(value, out str) ? str : value.ToString();
        }
    }
}