// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class EulerAnglesExtensions
    {
        public static Vector3 GetEulerAngles<T>(this T selfComponent) where T : Component
        {
            return selfComponent.transform.eulerAngles;
        }

        public static Vector3 GetEulerAngles(this GameObject self)
        {
            return self.transform.eulerAngles;
        }

        public static T SetEulerAngles<T>(this T selfComponent, Vector3 eulerAngles) where T : Component
        {
            selfComponent.transform.eulerAngles = eulerAngles;
            return selfComponent;
        }

        public static GameObject SetEulerAngles(this GameObject self, Vector3 eulerAngles)
        {
            self.transform.eulerAngles = eulerAngles;
            return self;
        }

        public static T SetEulerAnglesZ<T>(this T selfComponent, float z) where T : Component
        {
            var angles = selfComponent.GetEulerAngles();
            angles.z = z;
            selfComponent.SetEulerAngles(angles);
            return selfComponent;
        }

        public static GameObject SetEulerAnglesZ(this GameObject self, float z)
        {
            var angles = self.GetEulerAngles();
            angles.z = z;
            self.SetEulerAngles(angles);
            return self;
        }
    }
}