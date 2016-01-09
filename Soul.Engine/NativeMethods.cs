using System;
using System.Runtime.InteropServices;

namespace Soul.Engine
{
    public static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
    }
}