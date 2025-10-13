// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;

namespace RCFramework.Tools
{
    public interface ILifecycleEvents : IUtility
    {
        EventChannel UpdateEvent { get; }
        EventChannel FixedUpdateEvent { get; }
        EventChannel GUIEvent { get; }
        EventChannel<bool> ApplicationFocusEvent { get; }
        EventChannel<bool> ApplicationPauseEvent { get; }
        EventChannel ApplicationQuitEvent { get; }
    }
}
