// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Core
{
    public interface IUnsubscriber
    {
        void Unsubscribe();
    }

    public static class IUnsubscriberExtensions
    {
        public static IUnsubscriber UnsubscribeOnCleanup(this IUnsubscriber unsubscriber, ISystem system)
        {
            system.TrackUnsubscriber(unsubscriber);
            return unsubscriber;
        }

        public static IUnsubscriber UnsubscribeOnDestroy(this IUnsubscriber unsubscriber, GameObject gameObject)
        {
            return gameObject.GetOrAddComponent<UnsubscribeOnDestroyHandler>().AddUnsubscriber(unsubscriber);
        }

        public static IUnsubscriber UnsubscribeOnDestroy<T>(this IUnsubscriber unsubscriber, T component) where T : Component
        {
            return unsubscriber.UnsubscribeOnDestroy(component.gameObject);
        }

        public static IUnsubscriber UnsubscribeOnDisable<T>(this IUnsubscriber unsubscriber, T component) where T : Component
        {
            return unsubscriber.UnsubscribeOnDisable(component.gameObject);
        }

        public static IUnsubscriber UnsubscribeOnDisable(this IUnsubscriber unsubscriber, GameObject gameObject)
        {
            return gameObject.GetOrAddComponent<UnsubscribeOnDisableHandler>().AddUnsubscriber(unsubscriber);
        }

        private static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            var component = go.GetComponent<T>();
            if (!component) component = go.AddComponent<T>();
            return component;
        }
    }
}
