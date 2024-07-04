using System.Collections.Generic;
using UnityEngine;

namespace UI.Components.Pool
{
    public class ComponentPool<T> where T : BaseComponent
    {
        private readonly Queue<T> _pool = new Queue<T>();
        private readonly T _prefab;
        private readonly Transform _parentTransform;

        public ComponentPool(T prefab, Transform parentTransform, int initialCount = 10)
        {
            _prefab = prefab;
            _parentTransform = parentTransform;

            for (int i = 0; i < initialCount; i++)
            {
                T instance = Object.Instantiate(_prefab, _parentTransform);
                instance.gameObject.SetActive(false);
                _pool.Enqueue(instance);
            }
        }

        public T Get()
        {
            if (_pool.Count > 0)
            {
                T component = _pool.Dequeue();
                component.gameObject.SetActive(true);
                return component;
            }

            T newInstance = Object.Instantiate(_prefab, _parentTransform);
            newInstance.gameObject.SetActive(true);
            return newInstance;
        }

        public void ReturnToPool(T component)
        {
            component.gameObject.SetActive(false);
            _pool.Enqueue(component);
        }

        public void Clear(bool destroy = false)
        {
            if (destroy)
            {
                foreach (T component in _pool)
                {
                    Object.Destroy(component.gameObject);
                }
            }
            else
            {
                foreach (T component in _pool)
                {
                    ReturnToPool(component);
                }
            }
        }
    }
}