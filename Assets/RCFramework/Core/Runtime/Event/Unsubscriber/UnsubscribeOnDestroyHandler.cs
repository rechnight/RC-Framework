// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Core
{
    public class UnsubscribeOnDestroyHandler : MonoBehaviour, IUnsubscribeHandler
    {
        private readonly UnsubscribeHandler _handler = new();

        public IUnsubscriber AddUnsubscriber(IUnsubscriber unsubscriber) => _handler.AddUnsubscriber(unsubscriber);
        public void RemoveUnsubscriber(IUnsubscriber unsubscriber) => _handler.RemoveUnsubscriber(unsubscriber);
        public void Unsubscribe() => _handler.Unsubscribe();

        private void OnDestroy() => Unsubscribe();
    }
}