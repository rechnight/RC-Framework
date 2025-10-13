// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using RCFramework.Core;

namespace RCFramework.Tools
{
    public class EventChannel : IEventChannel
    {
        private Action _onEvent = () => { };

        public IUnsubscriber Subscribe(Action onEvent)
        {
            _onEvent += onEvent;
            return new Unsubscriber(() => Unsubscribe(onEvent));
        }

        public void Unsubscribe(Action onEvent)
        {
            _onEvent -= onEvent;
        }

        public void Raise()
        {
            _onEvent?.Invoke();
        }
    }

    public class EventChannel<T> : IEventChannel
    {
        protected Action<T> _onEvent = _ => { };

        public IUnsubscriber Subscribe(Action<T> onEvent)
        {
            _onEvent += onEvent;
            return new Unsubscriber(() => Unsubscribe(onEvent));
        }

        public IUnsubscriber Subscribe(Action onEvent)
        {
            return Subscribe(eventData => onEvent());
        }

        public void Unsubscribe(Action<T> onEvent)
        {
            _onEvent -= onEvent;
        }

        public void Raise(T eventData)
        {
            _onEvent?.Invoke(eventData);
        }
    }

    public class EventChannel<T1, T2> : EventChannel<(T1, T2)>
    {
        public IUnsubscriber Subscribe(Action<T1, T2> onEvent)
        {
            return Subscribe(pair => onEvent(pair.Item1, pair.Item2));
        }

        public void Raise(T1 eventData1, T2 eventData2)
        {
            Raise((eventData1, eventData2));
        }
    }

    public class EventChannel<T1, T2, T3> : EventChannel<(T1, T2, T3)>
    {
        public IUnsubscriber Subscribe(Action<T1, T2, T3> onEvent)
        {
            return Subscribe(trio => onEvent(trio.Item1, trio.Item2, trio.Item3));
        }

        public void Raise(T1 eventData1, T2 eventData2, T3 eventData3)
        {
            Raise((eventData1, eventData2, eventData3));
        }
    }
}