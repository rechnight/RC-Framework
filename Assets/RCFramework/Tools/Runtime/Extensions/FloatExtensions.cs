// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;

namespace RCFramework.Tools
{
    public static class FloatExtensions
    {
        public static float Lerp(this float self, float a, float b)
        {
            return Mathf.Lerp(a, b, self);
        }

        public static float Round(this float self, int digits = 0)
        {
            return (float)Math.Round(self, digits);
        }

        public static float Clamp(this float self, float min, float max)
        {
            return Mathf.Clamp(self, min, max);
        }

        public static float LerpUnclamped(this float self, float target, float t)
        {
            return Mathf.LerpUnclamped(self, target, t);
        }

        public static float MoveTowards(this float self, float target, float maxDelta)
        {
            return Mathf.MoveTowards(self, target, maxDelta);
        }

        public static float Abs(this float self)
        {
            return Mathf.Abs(self);
        }

        public static float Sign(this float self)
        {
            return Mathf.Sign(self);
        }

        public static float Cos(this float self)
        {
            return Mathf.Cos(self);
        }

        public static float Sin(this float self)
        {
            return Mathf.Sin(self);
        }

        public static float CosAngle(this float self)
        {
            return Mathf.Cos(self * Mathf.Deg2Rad);
        }

        public static float SinAngle(this float self)
        {
            return Mathf.Sin(self * Mathf.Deg2Rad);
        }

        public static float Deg2Rad(this float self)
        {
            return self * Mathf.Deg2Rad;
        }

        public static float Rad2Deg(this float self)
        {
            return self * Mathf.Rad2Deg;
        }

        public static Vector2 AngleToDirection2D(this float self)
        {
            return new Vector2(self.CosAngle(), self.SinAngle());
        }
    }
}