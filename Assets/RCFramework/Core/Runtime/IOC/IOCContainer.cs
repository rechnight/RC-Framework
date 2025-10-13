// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

namespace RCFramework.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAttribute : PropertyAttribute { }

    public class IOCContainer : IIOCContainer
    {
        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        void IIOCContainer.Register<T>(T instance)
        {
            var type = typeof(T);
            if (_instances.ContainsKey(type))
            {
                throw new Exception($"Type {type} already registered.");
            }
            _instances[type] = instance;
        }

        void IIOCContainer.Unregister<T>()
        {
            _instances.Remove(typeof(T));
        }

        void IIOCContainer.Unregister<T>(T instance)
        {
            _instances.Remove(instance.GetType());
        }

        T IIOCContainer.Resolve<T>()
        {
            if (_instances.TryGetValue(typeof(T), out var instance))
            {
                return (T)instance;
            }
            throw new Exception($"Type {typeof(T)} not registered.");
        }

        public IEnumerable<T> GetInstancesByType<T>()
        {
            foreach (var kvp in _instances)
            {
                if (kvp.Value is T instance)
                {
                    yield return instance;
                }
            }
        }

        void IIOCContainer.Inject(object target)
        {
            var fields = target.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                         .Where(field => Attribute.IsDefined(field, typeof(InjectAttribute)));

            foreach (var field in fields)
            {
                var dependency = Resolve(field.FieldType);
                field.SetValue(target, dependency);
            }
        }

        void IIOCContainer.Clear()
        {
            _instances.Clear();
        }

        private object Resolve(Type type)
        {
            if (_instances.TryGetValue(type, out var resolvedInstance))
            {
                return resolvedInstance;
            }
            return null;
        }
    }
}