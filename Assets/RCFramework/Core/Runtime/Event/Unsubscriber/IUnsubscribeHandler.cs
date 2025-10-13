// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

namespace RCFramework.Core
{
    public interface IUnsubscribeHandler
    {
        IUnsubscriber AddUnsubscriber(IUnsubscriber unsubscriber);
        void RemoveUnsubscriber(IUnsubscriber unsubscriber);
        void Unsubscribe();
    }
}