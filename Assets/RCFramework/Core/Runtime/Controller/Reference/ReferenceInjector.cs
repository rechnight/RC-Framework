// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using System.Reflection;
using UnityEngine;
using System.Collections;

namespace RCFramework.Core
{
    public class ReferenceInjector
    {
        public void Inject(object target)
        {
            if (target is not MonoBehaviour mb)
                throw new Exception($"ReferenceInjector can only inject MonoBehaviours. Target: {target}");

            var type = target.GetType();
            var flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

            foreach (var field in type.GetFields(flags))
            {
                if (field.GetValue(target) != null)
                    continue;

                if (field.GetCustomAttribute<SelfAttribute>() != null)
                {
                    Assign(field, target, mb.GetComponent(field.FieldType));
                }
                else if (field.GetCustomAttribute<ChildrenAttribute>() is ChildrenAttribute childAttr)
                {
                    AssignChild(field, target, mb, childAttr.IncludeInactive);
                }
                else if (field.GetCustomAttribute<ParentAttribute>() is ParentAttribute parentAttr)
                {
                    var comp = mb.GetComponentInParent(field.FieldType);
                    if (comp == null && parentAttr.IncludeInactive)
                        comp = GetComponentInParentRecursive(mb.transform.parent, field.FieldType);
                    Assign(field, target, comp);
                }
            }
        }

        private void Assign(FieldInfo field, object target, object value)
        {
            if (value == null)
            {
                Debug.LogError($"[ReferenceInjector] Missing reference for {field.Name} in {target.GetType().Name}");
                return;
            }
            field.SetValue(target, value);
        }

        private void AssignChild(FieldInfo field, object target, MonoBehaviour mb, bool includeInactive)
        {
            if (!typeof(IEnumerable).IsAssignableFrom(field.FieldType) || field.FieldType == typeof(string))
            {
                var comp = mb.GetComponentInChildren(field.FieldType, includeInactive);
                Assign(field, target, comp);
                return;
            }

            var elementType = field.FieldType.IsArray
                ? field.FieldType.GetElementType()
                : field.FieldType.GetGenericArguments()[0];

            var comps = mb.GetComponentsInChildren(elementType, includeInactive);

            if (field.FieldType.IsArray)
            {
                var array = Array.CreateInstance(elementType, comps.Length);
                Array.Copy(comps, array, comps.Length);
                Assign(field, target, array);
            }
            else if (typeof(IList).IsAssignableFrom(field.FieldType))
            {
                var list = (IList)Activator.CreateInstance(field.FieldType);
                foreach (var c in comps) list.Add(c);
                Assign(field, target, list);
            }
        }

        private Component GetComponentInParentRecursive(Transform parent, Type type)
        {
            while (parent != null)
            {
                var comp = parent.GetComponent(type);
                if (comp != null) return comp;
                parent = parent.parent;
            }
            return null;
        }
    }
}
