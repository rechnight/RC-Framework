// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;

namespace RCFramework.Tools
{
    public static class Vector2Extensions
    {
        public static Vector3 ToVector3(this Vector2 self, float z = 0)
        {
            return new Vector3(self.x, self.y, z);
        }

        public static Vector2 Direction2DTo(this Component self, Component to)
        {
            return CalculateDirection2D(self.transform, to.transform);
        }

        public static Vector2 Direction2DTo(this GameObject self, GameObject to)
        {
            return CalculateDirection2D(self.transform, to.transform);
        }

        public static Vector2 Direction2DTo(this Component self, GameObject to)
        {
            return CalculateDirection2D(self.transform, to.transform);
        }

        public static Vector2 Direction2DTo(this GameObject self, Component to)
        {
            return CalculateDirection2D(self.transform, to.transform);
        }

        public static Vector2 Direction2DFrom(this Component self, Component from)
        {
            return CalculateDirection2D(from.transform, self.transform);
        }

        public static Vector2 Direction2DFrom(this GameObject self, GameObject from)
        {
            return CalculateDirection2D(from.transform, self.transform);
        }

        public static Vector2 Direction2DFrom(this Component self, GameObject from)
        {
            return CalculateDirection2D(from.transform, self.transform);
        }

        public static Vector2 Direction2DFrom(this GameObject self, Component from)
        {
            return CalculateDirection2D(from.transform, self.transform);
        }

        public static Vector2 NormalizedDirection2DTo(this Component self, Component to)
        {
            return CalculateDirection2D(self.transform, to.transform).normalized;
        }

        public static Vector2 NormalizedDirection2DTo(this GameObject self, GameObject to)
        {
            return CalculateDirection2D(self.transform, to.transform).normalized;
        }

        public static Vector2 NormalizedDirection2DTo(this Component self, GameObject to)
        {
            return CalculateDirection2D(self.transform, to.transform).normalized;
        }

        public static Vector2 NormalizedDirection2DTo(this GameObject self, Component to)
        {
            return CalculateDirection2D(self.transform, to.transform).normalized;
        }

        public static Vector2 NormalizedDirection2DFrom(this Component self, Component from)
        {
            return CalculateDirection2D(from.transform, self.transform).normalized;
        }

        public static Vector2 NormalizedDirection2DFrom(this GameObject self, GameObject from)
        {
            return CalculateDirection2D(from.transform, self.transform).normalized;
        }

        public static Vector2 NormalizedDirection2DFrom(this Component self, GameObject from)
        {
            return CalculateDirection2D(from.transform, self.transform).normalized;
        }

        public static Vector2 NormalizedDirection2DFrom(this GameObject self, Component from)
        {
            return CalculateDirection2D(from.transform, self.transform).normalized;
        }

        public static float Distance2D(this GameObject self, GameObject other)
        {
            return Vector2.Distance(self.transform.position.ToVector2(), other.transform.position.ToVector2());
        }

        public static float Distance2D(this Component self, GameObject other)
        {
            return Vector2.Distance(self.transform.position.ToVector2(), other.transform.position.ToVector2());
        }

        public static float Distance2D(this GameObject self, Component other)
        {
            return Vector2.Distance(self.transform.position.ToVector2(), other.transform.position.ToVector2());
        }

        public static float Distance2D(this Component self, Component other)
        {
            return Vector2.Distance(self.transform.position.ToVector2(), other.transform.position.ToVector2());
        }

        public static float LocalDistance2D(this GameObject self, GameObject other)
        {
            return Vector2.Distance(self.transform.localPosition.ToVector2(), other.transform.localPosition.ToVector2());
        }

        public static float LocalDistance2D(this Component self, GameObject other)
        {
            return Vector2.Distance(self.transform.localPosition.ToVector2(), other.transform.localPosition.ToVector2());
        }

        public static float LocalDistance2D(this GameObject self, Component other)
        {
            return Vector2.Distance(self.transform.localPosition.ToVector2(), other.transform.localPosition.ToVector2());
        }

        public static float LocalDistance2D(this Component self, Component other)
        {
            return Vector2.Distance(self.transform.localPosition.ToVector2(), other.transform.localPosition.ToVector2());
        }

        public static Vector2 X(this Vector2 self, float x)
        {
            self.x = x;
            return self;
        }

        public static Vector2 Y(this Vector2 self, float y)
        {
            self.y = y;
            return self;
        }

        public static float ToAngle(this Vector2 self)
        {
            return Mathf.Atan2(self.y, self.x).Rad2Deg();
        }

        private static Vector2 CalculateDirection2D(Transform from, Transform to)
        {
            if (from == null || to == null)
                throw new ArgumentNullException("Transform cannot be null.");

            return (to.position - from.position).ToVector2();
        }
    }
}