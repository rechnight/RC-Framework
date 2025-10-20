// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class LocalRotationExtensions
    {
        public static Quaternion GetLocalRotation<T>(this T selfComponent) where T : Component
        {
            return selfComponent.transform.localRotation;
        }

        public static Quaternion GetLocalRotation(this GameObject self)
        {
            return self.transform.localRotation;
        }

        public static T SetLocalRotation<T>(this T selfComponent, Quaternion localRotation) where T : Component
        {
            selfComponent.transform.localRotation = localRotation;
            return selfComponent;
        }

        public static GameObject SetLocalRotation(this GameObject self, Quaternion localRotation)
        {
            self.transform.localRotation = localRotation;
            return self;
        }

        public static T ResetLocalRotation<T>(this T selfComponent) where T : Component
        {
            selfComponent.transform.localRotation = Quaternion.identity;
            return selfComponent;
        }

        public static GameObject ResetLocalRotation(this GameObject self)
        {
            self.transform.localRotation = Quaternion.identity;
            return self;
        }
    }
}