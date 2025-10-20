// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    public static class ComponentExtensions
    {
        public static T GetOrAddComponent<T>(this Component component) where T : Component
        {
            return component.gameObject.GetOrAddComponent<T>();
        }

        public static T Show<T>(this T component) where T : Component
        {
            component.gameObject.Show();
            return component;
        }

        public static T Hide<T>(this T component) where T : MonoBehaviour
        {
            component.gameObject.Hide();
            return component;
        }

        public static void DestroyGameObject<T>(this T component) where T : Component
        {
            component.gameObject.DestroySelf();
        }

        public static T DestroyAfterDelay<T>(this T component, float delay) where T : Component
        {
            component.gameObject.DestroySelfAfterDelay(delay);
            return component;
        }

        public static T SetLayer<T>(this T component, int layer) where T : Component
        {
            component.gameObject.layer = layer;
            return component;
        }

        public static T SetLayer<T>(this T component, string layerName) where T : Component
        {
            component.gameObject.layer = LayerMask.NameToLayer(layerName);
            return component;
        }

        public static bool IsInLayerMask<T>(this T component, LayerMask layerMask) where T : Component
        {
            var objLayerMask = 1 << component.gameObject.layer;
            return (layerMask.value & objLayerMask) == objLayerMask;
        }
    }
}