// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;

namespace RCFramework.Core
{
    public class UnsubscribeHandler : IUnsubscribeHandler
    {
        private readonly HashSet<IUnsubscriber> _unsubscribers = new HashSet<IUnsubscriber>();

        public IUnsubscriber AddUnsubscriber(IUnsubscriber unsubscriber)
        {
            _unsubscribers.Add(unsubscriber);
            return unsubscriber;
        }

        public void RemoveUnsubscriber(IUnsubscriber unsubscriber)
        {
            _unsubscribers.Remove(unsubscriber);
        }

        public void Unsubscribe()
        {
            foreach (var unsubscriber in _unsubscribers)
            {
                unsubscriber.Unsubscribe();
            }

            _unsubscribers.Clear();
        }
    }
}