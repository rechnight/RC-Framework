// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Tools
{
    public interface IPoolWrapper<T> where T : class, IPoolable<T>
    {
        T Get();
        void Release(T obj);
        void Clear();
    }
}