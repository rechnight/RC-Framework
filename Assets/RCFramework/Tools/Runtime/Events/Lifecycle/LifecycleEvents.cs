// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public class LifecycleEvents : MonoBehaviour, ILifecycleEvents
    {
        public EventChannel UpdateEvent { get; } = new EventChannel();
        public EventChannel FixedUpdateEvent { get; } = new EventChannel();
        public EventChannel GUIEvent { get; } = new EventChannel();
        public EventChannel<bool> ApplicationFocusEvent { get; } = new EventChannel<bool>();
        public EventChannel<bool> ApplicationPauseEvent { get; } = new EventChannel<bool>();
        public EventChannel ApplicationQuitEvent { get; } = new EventChannel();

        private LifecycleEvents() { } // Prevent accidental "new"

        public static ILifecycleEvents GetOrCreate(Component component)
        {
            var existing = FindFirstObjectByType<LifecycleEvents>();
            if (existing != null)
            {
                existing.SetParent(component);
                return existing;
            }

            return new GameObject(nameof(LifecycleEvents))
                .SetParent(component)
                .AddComponent<LifecycleEvents>();
        }

        private void Update() => UpdateEvent?.Raise();
        private void FixedUpdate() => FixedUpdateEvent?.Raise();
        private void OnGUI() => GUIEvent?.Raise();
        private void OnApplicationFocus(bool focus) => ApplicationFocusEvent?.Raise(focus);
        private void OnApplicationPause(bool pause) => ApplicationPauseEvent?.Raise(pause);
        private void OnApplicationQuit() => ApplicationQuitEvent?.Raise();
    }

}

