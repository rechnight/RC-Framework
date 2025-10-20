// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class RotationExtensions
    {
        public static Quaternion GetRotation<T>(this T component) where T : Component
        {
            return component.transform.rotation;
        }

        public static Quaternion GetRotation(this GameObject gameObject)
        {
            return gameObject.transform.rotation;
        }

        public static T SetRotation<T>(this T component, Quaternion rotation) where T : Component
        {
            component.transform.rotation = rotation;
            return component;
        }

        public static GameObject SetRotation(this GameObject self, Quaternion rotation)
        {
            self.transform.rotation = rotation;
            return self;
        }

        public static T ResetRotation<T>(this T selfComponent) where T : Component
        {
            selfComponent.transform.rotation = Quaternion.identity;
            return selfComponent;
        }

        public static GameObject ResetRotation(this GameObject gameObject)
        {
            gameObject.transform.rotation = Quaternion.identity;
            return gameObject;
        }
    }
}