using Microsoft.Xna.Framework;

namespace Soul.Engine
{
    public static class GameService
    {
        private static readonly GameServiceContainer Container;

        static GameService()
        {
            Container = new GameServiceContainer();
        }

        public static T GetService<T>()
        {
            return (T) Container.GetService(typeof (T));
        }

        public static void AddService<T>(T service)
        {
            Container.AddService(typeof (T), service);
        }

        public static void RemoveService<T>()
        {
            Container.RemoveService(typeof (T));
        }
    }
}