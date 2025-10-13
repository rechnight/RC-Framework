// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;

namespace RCFramework.Tools
{
    public interface IActionBinding : IUnsubscriber
    {
        void Invoke(IAction action, ReactionTiming timing);
    }
}