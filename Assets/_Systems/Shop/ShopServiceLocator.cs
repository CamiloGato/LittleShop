﻿using System;
using System.Collections.Generic;

namespace Shop
{
    public class ShopServiceLocator
    {
        private static ShopServiceLocator _instance;

        public static ShopServiceLocator Instance => _instance ??= new ShopServiceLocator();

        private readonly Dictionary<Type, object> _services = new();

        private ShopServiceLocator() { }

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