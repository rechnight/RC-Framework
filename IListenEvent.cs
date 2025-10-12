// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Core
{
    public interface IListenEvent : IGetArchitecture { }

    public static class IListenEventExtensions
    {
        public static EventBinding<T> StartListening<T>(this IListenEvent self, Action<T> onArgsEvent) where T : IEvent
        {
            return self.GetArchitecture().StartListening(onArgsEvent);
        }

        public static EventBinding<T> StartListening<T>(this IListenEvent self, Action onEvent) where T : IEvent
        {
            return self.GetArchitecture().StartListening<T>(onEvent);
        }

        public static void StopListening<T>(this IListenEvent self, EventBinding<T> binding) where T : IEvent
        {
            self.GetArchitecture().StopListening(binding);
        }
    }
}