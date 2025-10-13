// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Core
{
    public struct Unsubscriber : IUnsubscriber
    {
        private Action _onUnsubscribe;

        public Unsubscriber(Action onUnsubscribe) => _onUnsubscribe = onUnsubscribe;

        public void Unsubscribe()
        {
            _onUnsubscribe.Invoke();
            _onUnsubscribe = null;
        }
    }
}