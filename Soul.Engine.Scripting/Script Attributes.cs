using System;

namespace Soul.Engine.Scripting
{
    public class OverrideAttribute : Attribute
    {
        public string TypeName { get; private set; }

        public OverrideAttribute(string typeName)
        {
            TypeName = typeName;
        }
    }

    public class RemoveAttribute : Attribute
    {
        public string[] TypeNames { get; private set; }

        public RemoveAttribute(params string[] typeNames)
        {
            TypeNames = typeNames;
        }
    }

    public class OnAttribute : Attribute
    {
        public string Event { get; protected set; }

        public OnAttribute(string evnt)
        {
            Event = evnt;
        }
    }
}