using System;

namespace Soul.Engine.Common
{
    public static class Static<T> where T : class, new()
    {
        private static readonly Lazy<T> Lazy = new Lazy<T>();

        public static T Value
        {
            get { return Lazy.Value; }
        }
    }
}