// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class LocalEulerAnglesExtensions
    {
        public static Vector3 GetLocalEulerAngles<T>(this T selfComponent) where T : Component
        {
            return selfComponent.transform.localEulerAngles;
        }

        public static Vector3 GetLocalEulerAngles(this GameObject self)
        {
            return self.transform.localEulerAngles;
        }

        public static T SetLocalEulerAngles<T>(this T selfComponent, Vector3 localEulerAngles) where T : Component
        {
            selfComponent.transform.localEulerAngles = localEulerAngles;
            return selfComponent;
        }

        public static GameObject SetLocalEulerAngles(this GameObject self, Vector3 localEulerAngles)
        {
            self.transform.localEulerAngles = localEulerAngles;
            return self;
        }

        public static T SetLocalEulerAnglesZ<T>(this T selfComponent, float z) where T : Component
        {
            var angles = selfComponent.GetLocalEulerAngles();
            angles.z = z;
            selfComponent.SetLocalEulerAngles(angles);
            return selfComponent;
        }

        public static GameObject SetLocalEulerAnglesZ(this GameObject self, float z)
        {
            var angles = self.GetLocalEulerAngles();
            angles.z = z;
            self.SetLocalEulerAngles(angles);
            return self;
        }
    }
}