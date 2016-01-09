using System;

namespace Soul.Engine.Command
{
    public sealed class CommandAttribute : Attribute
    {
        public string[] Triggers { get; private set; }

        public CommandAttribute(params string[] triggers)
        {
            Triggers = triggers;
        }
    }
}