// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;

namespace RCFramework.Tools
{
    public static class PositionExtensions
    {
        public static T SetPosition<T>(this T selfComponent, Vector3 position) where T : Component
        {
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject SetPosition(this GameObject self, Vector3 position)
        {
            self.transform.position = position;
            return self;
        }

        public static T SetPosition<T>(this T selfComponent, float x, float y, float z) where T : Component
        {
            selfComponent.transform.position = new Vector3(x, y, z);
            return selfComponent;
        }

        public static GameObject SetPosition(this GameObject self, float x, float y, float z)
        {
            self.transform.position = new Vector3(x, y, z);
            return self;
        }

        public static T SetPosition<T>(this T selfComponent, float x, float y) where T : Component
        {
            var position = selfComponent.transform.position;
            position.x = x;
            position.y = y;
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject SetPosition(this GameObject self, float x, float y)
        {
            var position = self.transform.position;
            position.x = x;
            position.y = y;
            self.transform.position = position;
            return self;
        }

        public static T SetPositionIdentity<T>(this T component) where T : Component
        {
            component.transform.position = Vector3.zero;
            return component;
        }

        public static GameObject SetPositionIdentity(this GameObject gameObject)
        {
            gameObject.transform.position = Vector3.zero;
            return gameObject;
        }

        public static T SetPositionX<T>(this T selfComponent, float x) where T : Component
        {
            var position = selfComponent.transform.position;
            position.x = x;
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject SetPositionX(this GameObject self, float x)
        {
            var position = self.transform.position;
            position.x = x;
            self.transform.position = position;
            return self;
        }

        public static T SetPositionX<T>(this T selfComponent, Func<float, float> xSetter) where T : Component
        {
            var position = selfComponent.transform.position;
            position.x = xSetter(position.x);
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject SetPositionX(this GameObject self, Func<float, float> xSetter)
        {
            var position = self.transform.position;
            position.x = xSetter(position.x);
            self.transform.position = position;
            return self;
        }

        public static T SetPositionY<T>(this T selfComponent, float y) where T : Component
        {
            var position = selfComponent.transform.position;
            position.y = y;
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject SetPositionY(this GameObject self, float y)
        {
            var position = self.transform.position;
            position.y = y;
            self.transform.position = position;
            return self;
        }

        public static T SetPositionY<T>(this T selfComponent, Func<float, float> ySetter) where T : Component
        {
            var position = selfComponent.transform.position;
            position.y = ySetter(position.y);
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject SetPositionY(this GameObject self, Func<float, float> ySetter)
        {
            var position = self.transform.position;
            position.y = ySetter(position.y);
            self.transform.position = position;
            return self;
        }

        public static T SetPositionZ<T>(this T selfComponent, float z) where T : Component
        {
            var position = selfComponent.transform.position;
            position.z = z;
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject SetPositionZ(this GameObject self, float z)
        {
            var position = self.transform.position;
            position.z = z;
            self.transform.position = position;
            return self;
        }

        public static T SetPositionZ<T>(this T selfComponent, Func<float, float> zSetter) where T : Component
        {
            var position = selfComponent.transform.position;
            position.z = zSetter(position.z);
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject SetPositionZ(this GameObject self, Func<float, float> zSetter)
        {
            var position = self.transform.position;
            position.z = zSetter(position.z);
            self.transform.position = position;
            return self;
        }

        public static Vector3 GetPosition<T>(this T selfComponent) where T : Component
        {
            return selfComponent.transform.position;
        }

        public static Vector3 GetPosition(this GameObject self)
        {
            return self.transform.position;
        }

        public static Vector3 GetPosition<T>(this T selfComponent, Func<Vector3, Vector3> positionGetter) where T : Component
        {
            return positionGetter(selfComponent.transform.position);
        }

        public static Vector3 GetPosition(this GameObject self, Func<Vector3, Vector3> positionGetter)
        {
            return positionGetter(self.transform.position);
        }

        public static float GetPositionX(this GameObject self)
        {
            return self.transform.position.x;
        }

        public static float GetPositionX(this Component self)
        {
            return self.transform.position.x;
        }

        public static float GetPositionY(this GameObject self)
        {
            return self.transform.position.y;
        }

        public static float GetPositionY(this Component self)
        {
            return self.transform.position.y;
        }

        public static float GetPositionZ(this GameObject self)
        {
            return self.transform.position.z;
        }

        public static float GetPositionZ(this Component self)
        {
            return self.transform.position.z;
        }

        public static T AddPosition<T>(this T selfComponent, Vector3 position) where T : Component
        {
            selfComponent.transform.position += position;
            return selfComponent;
        }

        public static GameObject AddPosition(this GameObject self, Vector3 position)
        {
            self.transform.position += position;
            return self;
        }

        public static T AddPositionX<T>(this T selfComponent, float x) where T : Component
        {
            var position = selfComponent.transform.position;
            position.x += x;
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject AddPositionX(this GameObject self, float x)
        {
            var position = self.transform.position;
            position.x += x;
            self.transform.position = position;
            return self;
        }

        public static T AddPositionY<T>(this T selfComponent, float y) where T : Component
        {
            var position = selfComponent.transform.position;
            position.y += y;
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject AddPositionY(this GameObject self, float y)
        {
            var position = self.transform.position;
            position.y += y;
            self.transform.position = position;
            return self;
        }

        public static T AddPositionZ<T>(this T selfComponent, float z) where T : Component
        {
            var position = selfComponent.transform.position;
            position.z += z;
            selfComponent.transform.position = position;
            return selfComponent;
        }

        public static GameObject AddPositionZ(this GameObject self, float z)
        {
            var position = self.transform.position;
            position.z += z;
            self.transform.position = position;
            return self;
        }

        public static GameObject SetPosition2D(this GameObject self, Vector2 position)
        {
            return self.SetPosition(position.x, position.y);
        }

        public static T SetPosition2D<T>(this T self, Vector2 position) where T : Component
        {
            return self.SetPosition(position.x, position.y);
        }

        public static Vector2 GetPosition2D(this GameObject self)
        {
            return new Vector2(self.transform.position.x, self.transform.position.y);
        }

        public static Vector2 GetPosition2D(this Component self)
        {
            return new Vector2(self.transform.position.x, self.transform.position.y);
        }
    }
}