// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface ISendEvent : IGetArchitecture { }

    public static class ISendEventExtensions
    {
        public static void SendEvent<T>(this ISendEvent self, T eventData) where T : IEvent
        {
            self.GetArchitecture().SendEvent(eventData);
        }
    }
}