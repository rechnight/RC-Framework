// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class SyncPositionExtensions
    {
        public static GameObject SyncPositionFrom(this GameObject self, GameObject target)
        {
            return self.SetPosition(target.GetPosition());
        }

        public static T SyncPositionFrom<T>(this T selfComponent, T target) where T : Component
        {
            return selfComponent.SetPosition(target.GetPosition());
        }

        public static GameObject SyncLocalPositionFrom(this GameObject self, GameObject target)
        {
            return self.SetLocalPosition(target.GetLocalPosition());
        }

        public static T SyncLocalPositionFrom<T>(this T selfComponent, T target) where T : Component
        {
            return selfComponent.SetLocalPosition(target.GetLocalPosition());
        }
    }
}