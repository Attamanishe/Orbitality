using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Pool
{
    public class PrefabsPool<T> where T : MonoBehaviour, IPoolable
    {
        private T _origin;
        private Transform _inactiveTransform;
        private Stack<T> _pool = new Stack<T>();

        public PrefabsPool(T origin)
        {
            _origin = origin;

            _inactiveTransform = new GameObject().transform;
            _inactiveTransform.gameObject.SetActive(false);
            _inactiveTransform.gameObject.name = _origin.name;
        }

        public T Get(Transform parent)
        {
            T obj = _pool.Count > 0 ? _pool.Pop() : GameObject.Instantiate(_origin, parent);
            obj.transform.SetParent(parent);
            obj.OnNew();
            return obj;
        }

        public void Release(T obj)
        {
            obj.Dispose();
            obj.transform.SetParent(_inactiveTransform);
            _pool.Push(obj);
        }
    }
}