using System;
using System.Collections.Generic;

namespace Shop
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance;

        public static ServiceLocator Instance => _instance ??= new ServiceLocator();

        private readonly Dictionary<Type, object> _services = new();

        private ServiceLocator() { }

        public void Register<T>(T service)
        {
            _services[typeof(T)] = service;
        }

        public T Get<T>()
        {
            if (!_services.ContainsKey(typeof(T)))
            {
                throw new Exception($"Service {typeof(T)} not found");
            }
            return (T)_services[typeof(T)];
        }
    }
}