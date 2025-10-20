// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using RCFramework.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RCFramework.Tools
{
    public enum ReactionTiming { Pre, Post }

    public class ActionSequencer : IUtility
    {
        private readonly Dictionary<Type, HashSet<IActionBinding>> _bindings = new();
        private readonly Dictionary<Type, Func<IAction, Awaitable>> _executors = new();

        private List<IAction> _reactions;

        public bool IsExecuting { get; private set; } = false;

        public void SetExecutor<T>(Func<T, Awaitable> performer) where T : IAction
        {
            _executors[typeof(T)] = (IAction command) => performer((T)command);
        }

        public void RemoveExecutor<T>() where T : IAction
        {
            _executors.Remove(typeof(T));
        }

        public ActionBinding<T> Subscribe<T>(Action<T> reaction, ReactionTiming timing) where T : IAction
        {
            var binding = new ActionBinding<T>(reaction, timing, Unsubscribe);
            GetOrCreateBindings<T>().Add(binding);
            return binding;
        }

        public ActionBinding<T> Subscribe<T>(Action reaction, ReactionTiming timing) where T: IAction
        {
            var binding = new ActionBinding<T>(reaction, timing, Unsubscribe);
            GetOrCreateBindings<T>().Add(binding);
            return binding;
        }

        public void Unsubscribe<T>(ActionBinding<T> binding) where T : IAction
        {
            RemoveBinding(typeof(T), binding);
        }

        public void AddReaction(IAction action)
        {
            _reactions?.Add(action);
        }

        public async Awaitable Execute(IAction action)
        {
            if (IsExecuting)
                return;

            IsExecuting = true;
            await ExecuteSequence(action);
            IsExecuting = false;
        }

        public void Clear()
        {
            _bindings.Clear();
            _executors.Clear();
            IsExecuting = false;
        }

        private async Awaitable ExecuteSequence(IAction action)
        {
            _reactions = action.PreReactions;
            NotifySubscribers(action, ReactionTiming.Pre);
            await ExecuteReactions();

            _reactions = action.ExecuteReactions;
            await ExecuteAction(action);
            await ExecuteReactions();

            _reactions = action.PostReactions;
            NotifySubscribers(action, ReactionTiming.Post);
            await ExecuteReactions();
        }

        private async Awaitable ExecuteAction(IAction command)
        {
            if (_executors.TryGetValue(command.GetType(), out var performer))
            {
                await performer(command);
            }
        }

        private void NotifySubscribers(IAction command, ReactionTiming timing)
        {
            if (_bindings.TryGetValue(command.GetType(), out var bindings))
            {
                foreach (var binding in bindings)
                {
                    binding.Invoke(command, timing);
                }
            }
        }

        private async Awaitable ExecuteReactions()
        {
            if (_reactions.Count == 0)
                return;

            foreach (var reaction in _reactions)
            {
                await ExecuteSequence(reaction);
            }
        }

        private HashSet<IActionBinding> GetOrCreateBindings<T>() where T : IAction
        {
            if (!_bindings.TryGetValue(typeof(T), out var value))
            {
                _bindings[typeof(T)] = value = new HashSet<IActionBinding>();
            }

            return value;
        }

        private void RemoveBinding(Type type, IActionBinding binding)
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
    }
}
