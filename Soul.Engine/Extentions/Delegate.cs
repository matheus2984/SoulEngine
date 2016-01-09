using System;

namespace Soul.Engine.Extentions
{
    public static partial class Extentions
    {
        public static void SafeInvoke(this Delegate eventHandler, object sender, EventArgs args)
        {
            if (eventHandler != null)
                eventHandler.DynamicInvoke(sender, args);
        }

        public static void SafeInvoke<T>(this Delegate handler, object sender, T args) where T : EventArgs
        {
            if (handler != null)
                handler.DynamicInvoke(sender, args);
        }
    }
}