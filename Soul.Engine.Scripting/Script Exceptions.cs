using System;

namespace Soul.Engine.Scripting
{
    public class XException : Exception
    {
        public XException(string message) : base(message)
        {
        }
    }
}