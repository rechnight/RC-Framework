// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Core
{
    public class EventBinding<T> : IEventBinding where T : IEvent
    {
        private Action _onEvent = () => { };
        private Action<T> _onArgsEvent = (T _) => { };

        private readonly Action<EventBinding<T>> _unsubscribeAction = (EventBinding<T> _) => { };

        public Action OnEvent { get => _onEvent; set => _onEvent = value; }
        public Action<T> OnArgsEvent { get => _onArgsEvent; set => _onArgsEvent = value; }

        public EventBinding(Action onEvent, Action<EventBinding<T>> unsubscribeAction = null)
        {
            _onEvent = onEvent;
            _unsubscribeAction = unsubscribeAction;
        }
        public EventBinding(Action<T> onArgsEvent, Action<EventBinding<T>> unsubscribeAction = null)
        {
            _onArgsEvent = onArgsEvent;
            _unsubscribeAction = unsubscribeAction;
        }

        public void Add(Action onEvent)
        {
            _onEvent += onEvent;
        }
        public void Remove(Action onEvent)
        {
            _onEvent -= onEvent;
        }

        public void Add(Action<T> onArgsEvent)
        {
            _onArgsEvent += onArgsEvent;
        }
        public void Remove(Action<T> onEvent)
        {
            _onArgsEvent -= onEvent;
        }

        public void Unsubscribe()
        {
            _unsubscribeAction?.Invoke(this);
        }
    }
}