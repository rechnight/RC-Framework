// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;
using System;

namespace RCFramework.Tools
{
    public class PoolableObject : MonoBehaviour, IPoolable<PoolableObject>
    {
        private Action<PoolableObject> _returnAction;

        private void OnDisable()
        {
            ReturnToPool();
        }

        public void Initialize(Action<PoolableObject> returnAction)
        {
            _returnAction = returnAction;
        }

        public void ReturnToPool()
        {
            _returnAction?.Invoke(this);
        }
    }
}
