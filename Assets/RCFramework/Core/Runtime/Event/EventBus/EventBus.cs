// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using System.Collections.Generic;
using System.Linq;

namespace RCFramework.Core
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, HashSet<IEventBinding>> _bindings = new();
        private readonly Queue<Action> _deferredOps = new();
        private bool _isRaising = false;

        EventBinding<T> IEventBus.Subscribe<T>(Action<T> onArgsEvent)
        {
            var binding = new EventBinding<T>(onArgsEvent, ((IEventBus)this).Unsubscribe);
            Defer(() => GetOrCreateBindings<T>().Add(binding));
            return binding;
        }

        EventBinding<T> IEventBus.Subscribe<T>(Action onEvent)
        {
            var binding = new EventBinding<T>(onEvent, ((IEventBus)this).Unsubscribe);
            Defer(() => GetOrCreateBindings<T>().Add(binding));
            return binding;
        }

        void IEventBus.Unsubscribe<T>(EventBinding<T> binding)
        {
            Defer(() => RemoveBinding(typeof(T), binding));
        }

        void IEventBus.Raise<T>(T data)
        {
            if (_bindings.TryGetValue(typeof(T), out var list))
            {
                _isRaising = true;

                foreach (var binding in list.OfType<EventBinding<T>>())
                {
                    binding.OnArgsEvent.Invoke(data);
                    binding.OnEvent.Invoke();
                }

                _isRaising = false;
                Flush();
            }
        }

        void IEventBus.Clear()
        {
            _bindings.Clear();
        }

        private HashSet<IEventBinding> GetOrCreateBindings<T>() where T : IEvent
        {
            var type = typeof(T);
            if (!_bindings.TryGetValue(type, out var set))
            {
                _bindings[type] = set = new HashSet<IEventBinding>();
            }
            return set;
        }

        private void RemoveBinding(Type type, IEventBinding binding)
        {
            if (binding == null)
                return;

            if (_bindings.TryGetValue(type, out var list))
            {
                list.Remove(binding);
                if (list.Count == 0)
                {
                    _bindings.Remove(type);
                }
            }
        }

        private void Defer(Action operation)
        {
            if (_isRaising)
                _deferredOps.Enqueue(operation);
            else
                operation();
        }

        private void Flush()
        {
            while (_deferredOps.Count > 0)
            {
                _deferredOps.Dequeue().Invoke();
            }
        }
    }
}