// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;
using System;
using System.Linq;
using RCFramework.Core;

namespace RCFramework.Tools
{
    public interface IMediator: IUtility { }

    public interface ISender
    {
        public void Send<T>(T recipient) where T : IRecipient;
    }
    public interface IRecipient
    {
        public void Receive(ISender communicator);
    }

    public abstract class Mediator<T> : IMediator where T : class, IRecipient
    {
        private readonly List<T> _entities = new();

        public void Connect(T recipient)
        {
            if (!_entities.Contains(recipient))
            {
                _entities.Add(recipient);
                OnConnect(recipient);
            }
        }

        public void Disconnect(T recipient)
        {
            if (_entities.Contains(recipient))
            {
                _entities.Remove(recipient);
                OnDisconnect(recipient);
            }
        }

        public void Message(T target, ISender message)
        {
            _entities.FirstOrDefault(entity => entity.Equals(target))?.Receive(message);
        }

        public void Broadcast(T source, ISender message, IPredicate predicate = null)
        {
            _entities.Where(target => source != target && SenderConditionMet(predicate) && MediatorConditionMet(target))
                .ForEach(target => target.Receive(message));
        }

        protected abstract bool MediatorConditionMet(T target);
        protected virtual void OnConnect(T entity) { }
        protected virtual void OnDisconnect(T entity) { }

        private bool SenderConditionMet(IPredicate predicate) => predicate == null || predicate.Evaluate();
    }
}
