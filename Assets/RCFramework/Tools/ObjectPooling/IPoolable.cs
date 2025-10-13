// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Tools
{
    public interface IPoolable<T>
    {
        void Initialize(Action<T> returnAction);
        void ReturnToPool();
    }
}
