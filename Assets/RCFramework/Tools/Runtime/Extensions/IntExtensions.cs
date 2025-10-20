// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;

namespace RCFramework.Tools
{
    public static class IntExtensions
    {
        public static int Clamp(this int value, int min, int max)
        {
            return Math.Max(min, Math.Min(max, value));
        }

        public static int MoveTowards(this int self, int target, int maxDelta)
        {
            if (Mathf.Abs(target - self) <= maxDelta)
                return target;

            return self + (int)Mathf.Sign(target - self) * maxDelta;
        }

        public static float Abs(this int self)
        {
            return Mathf.Abs(self);
        }

        public static float Sign(this int self)
        {
            return Mathf.Sign(self);
        }

        public static float Cos(this int self)
        {
            return Mathf.Cos(self);
        }

        public static float Sin(this int self)
        {
            return Mathf.Sin(self);
        }

        public static float CosAngle(this int self)
        {
            return Mathf.Cos(self * Mathf.Deg2Rad);
        }

        public static float SinAngle(this int self)
        {
            return Mathf.Sin(self * Mathf.Deg2Rad);
        }

        public static float Deg2Rad(this int self)
        {
            return self * Mathf.Deg2Rad;
        }

        public static float Rad2Deg(this int self)
        {
            return self * Mathf.Rad2Deg;
        }

        public static Vector2 AngleToDirection2D(this int self)
        {
            return new Vector2(self.CosAngle(), self.SinAngle());
        }
    }
}