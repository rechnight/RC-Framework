// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Core
{
    public interface IEventBus
    {
        EventBinding<T> Subscribe<T>(Action<T> onArgsEvent) where T : IEvent;
        EventBinding<T> Subscribe<T>(Action onEvent) where T : IEvent;
        void Unsubscribe<T>(EventBinding<T> binding) where T : IEvent;
        void Raise<T>(T eventData) where T : IEvent;
        void Clear();
    }
}
