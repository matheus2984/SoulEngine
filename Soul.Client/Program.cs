using System;

namespace Soul.Client
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using (var game = new Soul())
                game.Run();
        }
    }
#endif
}