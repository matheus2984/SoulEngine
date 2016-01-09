using System;
using System.Reflection;

namespace Soul.Engine.Common
{
    public class Singleton<T> where T : class
    {
        private static readonly object SyncRoot = new object();
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance != null) return instance;
                lock (SyncRoot)
                {
                    if (instance == null)
                    {
                        ConstructorInfo ci = typeof (T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                            null, Type.EmptyTypes, null);

                        if (ci == null)
                        {
                            throw new Exception("Erro class must contain a private constructor");
                        }
                        instance = (T) ci.Invoke(null);
                    }
                    else
                    {
                        return instance;
                    }
                }
                return instance;
            }
        }
    }
}