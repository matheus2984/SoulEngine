using System;

namespace Soul.Engine.Serialization
{
    [AttributeUsage(AttributeTargets.All)]
    public class EncodingAttribute : Attribute
    {
        public EncodingAttribute(string url)
        {
        }
    }
}