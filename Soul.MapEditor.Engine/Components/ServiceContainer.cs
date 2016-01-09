using System;
using System.Collections.Generic;

namespace Soul.MapEditor.Core.Components
{
    public class ServiceContainer : IServiceProvider
    {
        private readonly Dictionary<Type, object> services;

        public ServiceContainer()
        {
            services = new Dictionary<Type, object>();
        }

        public void AddService<T>(T service)
        {
            services.Add(typeof (T), service);
        }

        public object GetService(Type serviceType)
        {
            object service;
            services.TryGetValue(serviceType, out service);

            return service;
        }
    }
}