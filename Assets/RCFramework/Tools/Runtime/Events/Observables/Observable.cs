// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;
using System;
using RCFramework.Core;

namespace RCFramework.Tools
{
    [Serializable]
    public class Observable<T>
    {
        private T _value;

        private Action<T> _onValueChanged = _ => { };

        public T Value
        {
            get => _value;
            set => Set(value);
        }

        public static implicit operator T(Observable<T> property) => property._value;

        public Observable(T defaultValue = default) => _value = defaultValue;

        public void Set(T newValue, bool invokeEvent = true)
        {
            if (EqualityComparer<T>.Default.Equals(_value, newValue))
                return;

            _value = newValue;

            if (invokeEvent)
            {
                _onValueChanged.Invoke(newValue);
            }
        }

        public IUnsubscriber Subscribe(Action<T> onValueChanged)
        {
            _onValueChanged += onValueChanged;
            return new Unsubscriber(() => Unsubscribe(onValueChanged));
        }

        public IUnsubscriber Subscribe(Action onEvent)
        {
            return Subscribe(eventData => onEvent());
        }

        public IUnsubscriber SubscribeWithInitValue(Action<T> onValueChanged)
        {
            onValueChanged(_value);
            return Subscribe(onValueChanged);
        }

        public void Unsubscribe(Action<T> onValueChanged)
        {
            _onValueChanged -= onValueChanged;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
