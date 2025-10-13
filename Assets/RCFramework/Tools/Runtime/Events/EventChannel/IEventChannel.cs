// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;
using System;

namespace RCFramework.Tools
{
    public interface IEventChannel
    {
        IUnsubscriber Subscribe(Action onEvent);
    }
}
