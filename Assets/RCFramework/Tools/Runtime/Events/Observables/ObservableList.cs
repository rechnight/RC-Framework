// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using System.Collections;
using System.Collections.Generic;
using RCFramework.Core;

namespace RCFramework.Tools
{
    [Serializable]
    public class ObservableList<T> : IList<T>
    {
        private readonly IList<T> _list;

        private Action<IList<T>> _onListChanged = _ => { };
        private Action<T> _onItemAdded = _ => { };
        private Action<T> _onItemRemoved = _ => { };
        private Action _onCleared = () => { };

        public ObservableList(IList<T> initialList = null)
        {
            _list = initialList ?? new List<T>();
        }

        public T this[int index]
        {
            get => _list[index];
            set
            {
                _list[index] = value;
                _onListChanged.Invoke(_list);
            }
        }

        public int Count => _list.Count;
        public bool IsReadOnly => _list.IsReadOnly;

        public void Add(T item)
        {
            _list.Add(item);
            _onItemAdded?.Invoke(item);
            _onListChanged.Invoke(_list);
        }

        public bool Remove(T item)
        {
            bool result = _list.Remove(item);
            if (result)
            {
                _onItemRemoved?.Invoke(item);
                _onListChanged.Invoke(_list);
            }
            return result;
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
            _onItemAdded.Invoke(item);
            _onListChanged.Invoke(_list);
        }

        public void RemoveAt(int index)
        {
            T item = _list[index];
            _list.RemoveAt(index);
            _onItemRemoved.Invoke(item);
            _onListChanged.Invoke(_list);
        }

        public void Clear()
        {
            _list.Clear();
            _onCleared?.Invoke();
            _onListChanged.Invoke(_list);
        }

        public bool Contains(T item) => _list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        public int IndexOf(T item) => _list.IndexOf(item);

        public IUnsubscriber Subscribe(Action<IList<T>> onListChanged)
        {
            _onListChanged += onListChanged;
            return new Unsubscriber(() => Unsubscribe(onListChanged));
        }

        public IUnsubscriber Subscribe(Action<IList<T>> onListChanged = null, Action<T> onItemAdded = null, Action<T> onItemRemoved = null, Action onCleared = null)
        {
            if (onItemAdded != null) _onItemAdded += onItemAdded;
            if (onItemRemoved != null) _onItemRemoved += onItemRemoved;
            if (onCleared != null) _onCleared += onCleared;
            if (onListChanged != null) _onListChanged += onListChanged;

            return new Unsubscriber(() => Unsubscribe(onListChanged, onItemAdded, onItemRemoved, onCleared));
        }

        public void Unsubscribe(Action<IList<T>> onListChanged = null, Action<T> onItemAdded = null, Action<T> onItemRemoved = null, Action onCleared = null)
        {
            if (onItemAdded != null) _onItemAdded -= onItemAdded;
            if (onItemRemoved != null) _onItemRemoved -= onItemRemoved;
            if (onCleared != null) _onCleared -= onCleared;
            if (onListChanged != null) _onListChanged -= onListChanged;
        }

        public override string ToString()
        {
            return string.Join(", ", _list);
        }
    }
}