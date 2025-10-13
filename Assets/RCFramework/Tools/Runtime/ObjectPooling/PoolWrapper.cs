// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;
using UnityEngine.Pool;

namespace RCFramework.Tools
{
    public class PoolWrapper<T> : IPoolWrapper<T> where T : class, IPoolable<T>
    {
        private readonly IObjectPool<T> _objectPool;

        public PoolWrapper(GameObject prefab)
        {
            _objectPool = new ObjectPool<T>(
                createFunc: () => GameObject.Instantiate(prefab).GetComponent<T>()
            );
        }

        public PoolWrapper(Func<T> onCreate, Action<T> onGet = null, Action<T> onRelease = null,
            Action<T> onDestroy = null, bool collectionCheck = true, int defaultCapacity = 10, int maxSize = 100)
        {
            _objectPool = new ObjectPool<T>(
                createFunc: () => onCreate(),
                actionOnGet: obj => onGet?.Invoke(obj),
                actionOnRelease: obj => onRelease?.Invoke(obj),
                actionOnDestroy: obj => onDestroy?.Invoke(obj),
                collectionCheck: collectionCheck,
                defaultCapacity: defaultCapacity,
                maxSize: maxSize
            );
        }

        T IPoolWrapper<T>.Get()
        {
            var obj = _objectPool.Get();
            obj.Initialize(((IPoolWrapper<T>)this).Release);
            return obj;
        }

        void IPoolWrapper<T>.Release(T obj)
        {
            _objectPool.Release(obj);
        }

        void IPoolWrapper<T>.Clear()
        {
            _objectPool.Clear();
        }
    }
}
