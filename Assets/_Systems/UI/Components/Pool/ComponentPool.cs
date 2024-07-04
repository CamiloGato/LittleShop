using System.Collections.Generic;
using UnityEngine;

namespace UI.Components.Pool
{
    public class ComponentPool<T> where T : BaseComponent
    {
        private readonly Queue<T> _pool = new Queue<T>();
        private readonly HashSet<T> _activePool = new HashSet<T>();
        private readonly T _prefab;
        private readonly Transform _parentTransform;

        public IEnumerator<T> ActivePool => _activePool.GetEnumerator();
        
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
            T component = _pool.Count > 0 
                ? _pool.Dequeue()
                : Object.Instantiate(_prefab, _parentTransform);

            _activePool.Add(component);
            component.gameObject.SetActive(true);
            return component;
        }

        public void ReturnToPool(T component)
        {
            if (_activePool.Remove(component))
            {
                component.gameObject.SetActive(false);
                _pool.Enqueue(component);
            }
        }

        public void Clear(bool destroy = false)
        {
            if (destroy)
            {
                while (_pool.Count > 0)
                {
                    T component = _pool.Dequeue();
                    Object.Destroy(component.gameObject);
                }

                foreach (T component in _activePool)
                {
                    Object.Destroy(component.gameObject);
                }

                _activePool.Clear();
            }
            else
            {
                List<T> activeComponents = new List<T>(_activePool);
                foreach (T component in activeComponents)
                {
                    ReturnToPool(component);
                }
            }
        }
    }
}