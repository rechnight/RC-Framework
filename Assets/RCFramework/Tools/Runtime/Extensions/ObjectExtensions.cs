// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class ObjectExtensions
    {
        public static T OrNull<T>(this T obj) where T : Object
        {
            return obj ? obj : null;
        }

        public static T Instantiate<T>(this T selfObj) where T : Object
        {
            return Object.Instantiate(selfObj);
        }

        public static T Instantiate<T>(this T selfObj, Vector3 position, Quaternion rotation) where T : Object
        {
            return Object.Instantiate(selfObj, position, rotation);
        }

        public static T Instantiate<T>(this T selfObj, Vector3 position, Quaternion rotation, Transform parent) where T : Object
        {
            return Object.Instantiate(selfObj, position, rotation, parent);
        }

        public static T InstantiateWithParent<T>(this T selfObj, Transform parent, bool worldPositionStays) where T : Object
        {
            return (T)Object.Instantiate((Object)selfObj, parent, worldPositionStays);
        }

        public static T InstantiateWithParent<T>(this T selfObj, Component parent, bool worldPositionStays) where T : Object
        {
            return (T)Object.Instantiate((Object)selfObj, parent.transform, worldPositionStays);
        }

        public static T InstantiateWithParent<T>(this T selfObj, Transform parent) where T : Object
        {
            return Object.Instantiate(selfObj, parent, false);
        }

        public static T InstantiateWithParent<T>(this T selfObj, Component parent) where T : Object
        {
            return Object.Instantiate(selfObj, parent.transform, false);
        }

        public static T Name<T>(this T selfObj, string name) where T : Object
        {
            selfObj.name = name;
            return selfObj;
        }

        public static void DestroySelf<T>(this T selfObj) where T : Object
        {
            Object.Destroy(selfObj);
        }

        public static T DestroySelfAfterDelay<T>(this T selfObj, float afterDelay) where T : Object
        {
            Object.Destroy(selfObj, afterDelay);
            return selfObj;
        }

        public static T DontDestroyOnLoad<T>(this T selfObj) where T : Object
        {
            Object.DontDestroyOnLoad(selfObj);
            return selfObj;
        }
    }
}