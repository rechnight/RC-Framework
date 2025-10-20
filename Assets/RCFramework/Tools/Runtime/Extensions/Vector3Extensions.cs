// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;

namespace RCFramework.Tools
{
    public static class Vector3Extensions
    {
        public static Vector2 ToVector2(this Vector3 self)
        {
            return new Vector2(self.x, self.y);
        }

        public static Vector3 DirectionTo(this Component self, Component to)
        {
            return CalculateDirection(self.transform, to.transform);
        }

        public static Vector3 DirectionTo(this GameObject self, GameObject to)
        {
            return CalculateDirection(self.transform, to.transform);
        }

        public static Vector3 DirectionTo(this Component self, GameObject to)
        {
            return CalculateDirection(self.transform, to.transform);
        }

        public static Vector3 DirectionTo(this GameObject self, Component to)
        {
            return CalculateDirection(self.transform, to.transform);
        }

        public static Vector3 DirectionFrom(this Component self, Component from)
        {
            return CalculateDirection(from.transform, self.transform);
        }

        public static Vector3 DirectionFrom(this GameObject self, GameObject from)
        {
            return CalculateDirection(from.transform, self.transform);
        }

        public static Vector3 DirectionFrom(this Component self, GameObject from)
        {
            return CalculateDirection(from.transform, self.transform);
        }

        public static Vector3 DirectionFrom(this GameObject self, Component from)
        {
            return CalculateDirection(from.transform, self.transform);
        }

        public static Vector3 NormalizedDirectionTo(this Component self, Component to)
        {
            return CalculateDirection(self.transform, to.transform).normalized;
        }

        public static Vector3 NormalizedDirectionTo(this GameObject self, GameObject to)
        {
            return CalculateDirection(self.transform, to.transform).normalized;
        }

        public static Vector3 NormalizedDirectionTo(this Component self, GameObject to)
        {
            return CalculateDirection(self.transform, to.transform).normalized;
        }

        public static Vector3 NormalizedDirectionTo(this GameObject self, Component to)
        {
            return CalculateDirection(self.transform, to.transform).normalized;
        }

        public static Vector3 NormalizedDirectionFrom(this Component self, Component from)
        {
            return CalculateDirection(from.transform, self.transform).normalized;
        }

        public static Vector3 NormalizedDirectionFrom(this GameObject self, GameObject from)
        {
            return CalculateDirection(from.transform, self.transform).normalized;
        }

        public static Vector3 NormalizedDirectionFrom(this Component self, GameObject from)
        {
            return CalculateDirection(from.transform, self.transform).normalized;
        }

        public static Vector3 NormalizedDirectionFrom(this GameObject self, Component from)
        {
            return CalculateDirection(from.transform, self.transform).normalized;
        }

        public static float Distance(this GameObject self, GameObject other)
        {
            return Vector3.Distance(self.transform.position, other.transform.position);
        }

        public static float Distance(this Component self, GameObject other)
        {
            return Vector3.Distance(self.transform.position, other.transform.position);
        }

        public static float Distance(this GameObject self, Component other)
        {
            return Vector3.Distance(self.transform.position, other.transform.position);
        }

        public static float Distance(this Component self, Component other)
        {
            return Vector3.Distance(self.transform.position, other.transform.position);
        }

        public static float LocalDistance(this GameObject self, GameObject other)
        {
            return Vector3.Distance(self.transform.localPosition, other.transform.localPosition);
        }

        public static float LocalDistance(this Component self, GameObject other)
        {
            return Vector3.Distance(self.transform.localPosition, other.transform.localPosition);
        }

        public static float LocalDistance(this GameObject self, Component other)
        {
            return Vector3.Distance(self.transform.localPosition, other.transform.localPosition);
        }

        public static float LocalDistance(this Component self, Component other)
        {
            return Vector3.Distance(self.transform.localPosition, other.transform.localPosition);
        }

        public static Vector3 X(this Vector3 self, float x)
        {
            self.x = x;
            return self;
        }

        public static Vector3 Y(this Vector3 self, float y)
        {
            self.y = y;
            return self;
        }

        public static Vector3 Z(this Vector3 self, float z)
        {
            self.z = z;
            return self;
        }

        private static Vector3 CalculateDirection(Transform from, Transform to)
        {
            if (from == null || to == null)
                throw new ArgumentNullException("Transform cannot be null.");

            return to.position - from.position;
        }
    }
}