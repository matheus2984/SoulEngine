using System;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace Soul.Engine.Extentions
{
    public static partial class Extentions
    {
        public static T[] GetCustomAttribute<T>(this ICustomAttributeProvider type) where T : Attribute
        {
            var attribs = type.GetType().GetCustomAttributes(typeof (T), false) as T[];
            Contract.Assume(attribs != null);
            return attribs;
        }
    }
}