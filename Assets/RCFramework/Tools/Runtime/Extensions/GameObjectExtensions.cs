// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class GameObjectExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
        }

        public static GameObject Show(this GameObject gameObject)
        {
            gameObject.SetActive(true);
            return gameObject;
        }

        public static GameObject Hide(this GameObject gameObject)
        {
            gameObject.SetActive(false);
            return gameObject;
        }

        public static GameObject SetLayer(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            return gameObject;
        }

        public static GameObject SetLayer(this GameObject gameObject, string layerName)
        {
            gameObject.layer = LayerMask.NameToLayer(layerName);
            return gameObject;
        }

        public static bool IsInLayerMask(this GameObject gameObject, LayerMask layerMask)
        {
            var objLayerMask = 1 << gameObject.layer;
            return (layerMask.value & objLayerMask) == objLayerMask;
        }
    }
}