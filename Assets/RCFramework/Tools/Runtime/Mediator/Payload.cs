// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Tools
{
    public abstract class Payload<TData> : ISender
    {
        public abstract TData Content { get; set; }
        public Payload(TData content)
        {
            Content = content;
        }

        public abstract void Send<T>(T receiver) where T : IRecipient;
    }
}