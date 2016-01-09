using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Soul.Engine.Extentions
{
    public static partial class Extentions
    {
        public static IEnumerable<string> ParseCommand(this string msg)
        {
            MatchCollection matches = Regex.Matches(msg, @"(""[a-z0-9_\-\.,\+': ]+""|[a-z0-9_\-\.,\+':]+)",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
            for (var i = 0; i < matches.Count; i++)
                yield return matches[i].Groups[1].Value.Trim('"', ' ');
        }
    }
}