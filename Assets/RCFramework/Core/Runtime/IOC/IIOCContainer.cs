// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;

namespace RCFramework.Core
{
    public interface IIOCContainer
    {
        void Register<T>(T instance);
        void Unregister<T>();
        void Unregister<T>(T instance);
        T Resolve<T>();
        IEnumerable<T> GetInstancesByType<T>();
        void Inject(object target);
        void Clear();
    }
}
