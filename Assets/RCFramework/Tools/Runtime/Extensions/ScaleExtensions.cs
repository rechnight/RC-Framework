// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class ScaleExtensions
    {
        public static T SetLocalScale<T>(this T selfComponent, Vector3 scale) where T : Component
        {
            selfComponent.transform.localScale = scale;
            return selfComponent;
        }

        public static GameObject SetLocalScale(this GameObject self, Vector3 scale)
        {
            self.transform.localScale = scale;
            return self;
        }

        public static Vector3 GetLocalScale<T>(this T selfComponent) where T : Component
        {
            return selfComponent.transform.localScale;
        }

        public static Vector3 GetLocalScale(this GameObject self)
        {
            return self.transform.localScale;
        }

        public static T SetLocalScale<T>(this T selfComponent, float xyz) where T : Component
        {
            selfComponent.transform.localScale = Vector3.one * xyz;
            return selfComponent;
        }

        public static GameObject SetLocalScale(this GameObject self, float xyz)
        {
            self.transform.localScale = Vector3.one * xyz;
            return self;
        }

        public static T SetLocalScale<T>(this T selfComponent, float x, float y, float z) where T : Component
        {
            var localScale = selfComponent.transform.localScale;
            localScale.x = x;
            localScale.y = y;
            localScale.z = z;
            selfComponent.transform.localScale = localScale;
            return selfComponent;
        }

        public static GameObject SetLocalScale(this GameObject selfComponent, float x, float y, float z)
        {
            var localScale = selfComponent.transform.localScale;
            localScale.x = x;
            localScale.y = y;
            localScale.z = z;
            selfComponent.transform.localScale = localScale;
            return selfComponent;
        }

        public static T SetLocalScale<T>(this T selfComponent, float x, float y) where T : Component
        {
            var localScale = selfComponent.transform.localScale;
            localScale.x = x;
            localScale.y = y;
            selfComponent.transform.localScale = localScale;
            return selfComponent;
        }

        public static GameObject SetLocalScale(this GameObject selfComponent, float x, float y)
        {
            var localScale = selfComponent.transform.localScale;
            localScale.x = x;
            localScale.y = y;
            selfComponent.transform.localScale = localScale;
            return selfComponent;
        }

        public static T SetLocalScaleX<T>(this T selfComponent, float x) where T : Component
        {
            var localScale = selfComponent.transform.localScale;
            localScale.x = x;
            selfComponent.transform.localScale = localScale;
            return selfComponent;
        }

        public static GameObject SetLocalScaleX(this GameObject self, float x)
        {
            var localScale = self.transform.localScale;
            localScale.x = x;
            self.transform.localScale = localScale;
            return self;
        }

        public static float GetLocalScaleX<T>(this T self) where T : Component
        {
            return self.transform.localScale.x;
        }

        public static float GetLocalScaleX(this GameObject self)
        {
            return self.transform.localScale.x;
        }

        public static T SetLocalScaleY<T>(this T self, float y) where T : Component
        {
            var localScale = self.transform.localScale;
            localScale.y = y;
            self.transform.localScale = localScale;
            return self;
        }

        public static GameObject SetLocalScaleY(this GameObject self, float y)
        {
            var localScale = self.transform.localScale;
            localScale.y = y;
            self.transform.localScale = localScale;
            return self;
        }

        public static float GetLocalScaleY<T>(this T self) where T : Component
        {
            return self.transform.localScale.y;
        }

        public static float GetLocalScaleY(this GameObject self)
        {
            return self.transform.localScale.y;
        }

        public static T SetLocalScaleZ<T>(this T selfComponent, float z) where T : Component
        {
            var localScale = selfComponent.transform.localScale;
            localScale.z = z;
            selfComponent.transform.localScale = localScale;
            return selfComponent;
        }

        public static GameObject SetLocalScaleZ(this GameObject selfComponent, float z)
        {
            var localScale = selfComponent.transform.localScale;
            localScale.z = z;
            selfComponent.transform.localScale = localScale;
            return selfComponent;
        }

        public static float GetLocalScaleZ<T>(this T self) where T : Component
        {
            return self.transform.localScale.z;
        }

        public static float GetLocalScaleZ(this GameObject self)
        {
            return self.transform.localScale.z;
        }

        public static T ResetScale<T>(this T selfComponent) where T : Component
        {
            selfComponent.transform.localScale = Vector3.one;
            return selfComponent;
        }

        public static GameObject ResetScale(this GameObject selfComponent)
        {
            selfComponent.transform.localScale = Vector3.one;
            return selfComponent;
        }

        public static Vector3 GetScale<T>(this T component) where T : Component
        {
            return component.transform.lossyScale;
        }

        public static Vector3 GetScale(this GameObject component)
        {
            return component.transform.lossyScale;
        }
    }
}