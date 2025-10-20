// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class LocalPositionExtensions
    {
        public static T SetLocalPosition<T>(this T selfComponent, Vector3 localPos) where T : Component
        {
            selfComponent.transform.localPosition = localPos;
            return selfComponent;
        }

        public static GameObject SetLocalPosition(this GameObject self, Vector3 localPos)
        {
            self.transform.localPosition = localPos;
            return self;
        }

        public static T SetLocalPosition<T>(this T selfComponent, float x, float y, float z) where T : Component
        {
            selfComponent.transform.localPosition = new Vector3(x, y, z);
            return selfComponent;
        }

        public static GameObject SetLocalPosition(this GameObject self, float x, float y, float z)
        {
            self.transform.localPosition = new Vector3(x, y, z);
            return self;
        }

        public static T SetLocalPosition<T>(this T selfComponent, float x, float y) where T : Component
        {
            var localPosition = selfComponent.transform.localPosition;
            localPosition.x = x;
            localPosition.y = y;
            selfComponent.transform.localPosition = localPosition;
            return selfComponent;
        }

        public static GameObject SetLocalPosition(this GameObject self, float x, float y)
        {
            var localPosition = self.transform.localPosition;
            localPosition.x = x;
            localPosition.y = y;
            self.transform.localPosition = localPosition;
            return self;
        }

        public static T SetLocalPositionX<T>(this T selfComponent, float x) where T : Component
        {
            var localPosition = selfComponent.transform.localPosition;
            localPosition.x = x;
            selfComponent.transform.localPosition = localPosition;
            return selfComponent;
        }

        public static GameObject SetLocalPositionX(this GameObject self, float x)
        {
            var localPosition = self.transform.localPosition;
            localPosition.x = x;
            self.transform.localPosition = localPosition;
            return self;
        }

        public static T SetLocalPositionY<T>(this T selfComponent, float y) where T : Component
        {
            var localPosition = selfComponent.transform.localPosition;
            localPosition.y = y;
            selfComponent.transform.localPosition = localPosition;
            return selfComponent;
        }

        public static GameObject SetLocalPositionY(this GameObject self, float y)
        {
            var localPosition = self.transform.localPosition;
            localPosition.y = y;
            self.transform.localPosition = localPosition;
            return self;
        }

        public static T SetLocalPositionZ<T>(this T selfComponent, float z) where T : Component
        {
            var localPosition = selfComponent.transform.localPosition;
            localPosition.z = z;
            selfComponent.transform.localPosition = localPosition;
            return selfComponent;
        }

        public static GameObject SetLocalPositionZ(this GameObject self, float z)
        {
            var localPosition = self.transform.localPosition;
            localPosition.z = z;
            self.transform.localPosition = localPosition;
            return self;
        }

        public static T SetLocalPositionIdentity<T>(this T selfComponent) where T : Component
        {
            selfComponent.transform.localPosition = Vector3.zero;
            return selfComponent;
        }

        public static GameObject SetLocalPositionIdentity(this GameObject self)
        {
            self.transform.localPosition = Vector3.zero;
            return self;
        }

        public static Vector3 GetLocalPosition<T>(this T selfComponent) where T : Component
        {
            return selfComponent.transform.localPosition;
        }

        public static Vector3 GetLocalPosition(this GameObject self)
        {
            return self.transform.localPosition;
        }

        public static float GetLocalPositionX(this GameObject self)
        {
            return self.transform.localPosition.x;
        }

        public static float GetLocalPositionX(this Component self)
        {
            return self.transform.localPosition.x;
        }

        public static float GetLocalPositionY(this GameObject self)
        {
            return self.transform.localPosition.y;
        }

        public static float GetLocalPositionY(this Component self)
        {
            return self.transform.localPosition.y;
        }

        public static float GetLocalPositionZ(this GameObject self)
        {
            return self.transform.localPosition.z;
        }

        public static float GetLocalPositionZ(this Component self)
        {
            return self.transform.localPosition.z;
        }

        public static GameObject SetLocalPosition2D(this GameObject self, Vector2 position)
        {
            return self.SetLocalPosition(position.x, position.y);
        }

        public static T SetLocalPosition2D<T>(this T self, Vector2 position) where T : Component
        {
            return self.SetLocalPosition(position.x, position.y);
        }

        public static Vector2 GetLocalPosition2D(this GameObject self)
        {
            return new Vector2(self.transform.localPosition.x, self.transform.localPosition.y);
        }

        public static Vector2 GetLocalPosition2D(this Component self)
        {
            return new Vector2(self.transform.localPosition.x, self.transform.localPosition.y);
        }
    }
}