using System;
using UnityEngine;
using System.Reflection;

namespace Comon
{
    public class Singleton<T> : IDisposable where T : Singleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Construct<T>();
                }

                return _instance;
            }
        }

        protected Singleton()
        {
        }

        public static T Construct<T>()
        {
            Type t = typeof(T);

            ConstructorInfo ci =
                t.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);

            return (T) ci.Invoke(null);
        }

        public virtual void Dispose()
        {
            _instance = null;
        }
    }

    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            Instance = this as T;
        }

        protected virtual void OnDestroy()
        {
            Instance = null;
        }
    }
}