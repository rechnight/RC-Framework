// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;

namespace RCFramework.Tools
{
    public static class TransformExtensions
    {
        public static T ResetLocalTransform<T>(this T self) where T : Component
        {
            self.transform.localPosition = Vector3.zero;
            self.transform.localRotation = Quaternion.identity;
            self.transform.localScale = Vector3.one;
            return self;
        }

        public static GameObject ResetLocalTransform(this GameObject self)
        {
            self.transform.localPosition = Vector3.zero;
            self.transform.localRotation = Quaternion.identity;
            self.transform.localScale = Vector3.one;
            return self;
        }

        public static T ResetTransform<T>(this T selfComponent) where T : Component
        {
            selfComponent.transform.position = Vector3.zero;
            selfComponent.transform.rotation = Quaternion.identity;
            selfComponent.transform.localScale = Vector3.one;
            return selfComponent;
        }

        public static GameObject ResetTransform(this GameObject self)
        {
            self.transform.position = Vector3.zero;
            self.transform.rotation = Quaternion.identity;
            self.transform.localScale = Vector3.one;
            return self;
        }

        public static T SetParent<T>(this T self, Component parent) where T : Component
        {
            self.transform.SetParent(parent.transform);
            return self;
        }

        public static GameObject SetParent(this GameObject self, Component parent)
        {
            self.transform.SetParent(parent.transform);
            return self;
        }

        public static T SetAsRootTransform<T>(this T component) where T : Component
        {
            component.transform.SetParent(null);
            return component;
        }

        public static GameObject SetAsRootGameObject(this GameObject gameObject)
        {
            gameObject.transform.SetParent(null);
            return gameObject;
        }

        public static T SetAsLastSibling<T>(this T selfComponent) where T : Component
        {
            selfComponent.transform.SetAsLastSibling();
            return selfComponent;
        }

        public static GameObject SetAsLastSibling(this GameObject self)
        {
            self.transform.SetAsLastSibling();
            return self;
        }

        public static T SetAsFirstSibling<T>(this T selfComponent) where T : Component
        {
            selfComponent.transform.SetAsFirstSibling();
            return selfComponent;
        }

        public static GameObject SetAsFirstSibling(this GameObject selfComponent)
        {
            selfComponent.transform.SetAsFirstSibling();
            return selfComponent;
        }

        public static T SetSiblingIndex<T>(this T selfComponent, int index) where T : Component
        {
            selfComponent.transform.SetSiblingIndex(index);
            return selfComponent;
        }

        public static GameObject SetSiblingIndex(this GameObject selfComponent, int index)
        {
            selfComponent.transform.SetSiblingIndex(index);
            return selfComponent;
        }

        public static T DestroyChildren<T>(this T parent) where T : Component
        {
            parent.transform.ForEveryChild(child => GameObject.Destroy(child.gameObject));
            return parent;
        }

        public static T DestroyChildren<T>(this T parent, Func<Transform, bool> condition) where T : Component
        {
            parent.transform.ForEveryChild(child =>
            {
                if (condition(child))
                {
                    GameObject.Destroy(child.gameObject);
                }
            });
            return parent;
        }

        public static GameObject DestroyChildren(this GameObject gameObject)
        {
            gameObject.transform.ForEveryChild(child => GameObject.Destroy(child.gameObject));
            return gameObject;
        }

        public static void ForEveryChild(this Transform parent, Action<Transform> action)
        {
            for (var i = parent.childCount - 1; i >= 0; i--)
            {
                action(parent.GetChild(i));
            }
        }
    }
}