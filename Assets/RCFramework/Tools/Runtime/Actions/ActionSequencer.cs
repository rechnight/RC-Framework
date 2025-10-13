// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RCFramework.Tools
{
    public enum ReactionTiming { Pre, Post }

    public class ActionSequencer : IActionSequencer
    {
        private readonly Dictionary<Type, HashSet<IActionBinding>> _bindings = new();
        private readonly Dictionary<Type, Func<IAction, Awaitable>> _executors = new();

        private List<IAction> _reactions;

        public bool IsExecuting { get; private set; } = false;

        void IActionSequencer.SetExecutor<T>(Func<T, Awaitable> performer)
        {
            _executors[typeof(T)] = (IAction command) => performer((T)command);
        }

        void IActionSequencer.RemoveExecutor<T>()
        {
            _executors.Remove(typeof(T));
        }

        ActionBinding<T> IActionSequencer.Subscribe<T>(Action<T> reaction, ReactionTiming timing)
        {
            var binding = new ActionBinding<T>(reaction, timing, ((IActionSequencer)this).Unsubscribe);
            GetOrCreateBindings<T>().Add(binding);
            return binding;
        }

        ActionBinding<T> IActionSequencer.Subscribe<T>(Action reaction, ReactionTiming timing)
        {
            var binding = new ActionBinding<T>(reaction, timing, ((IActionSequencer)this).Unsubscribe);
            GetOrCreateBindings<T>().Add(binding);
            return binding;
        }

        void IActionSequencer.Unsubscribe<T>(ActionBinding<T> binding)
        {
            RemoveBinding(typeof(T), binding);
        }

        void IActionSequencer.Unsubscribe<T>(Action<T> reaction)
        {
            if (_bindings.TryGetValue(typeof(T), out var bindings))
            {
                var bindingToRemove = bindings.OfType<ActionBinding<T>>()
                    .FirstOrDefault(binding => binding.OnArgsPreReaction == reaction || binding.OnArgsPostReaction == reaction);

                RemoveBinding(typeof(T), bindingToRemove);
            }
        }

        void IActionSequencer.Unsubscribe<T>(Action reaction)
        {
            if (_bindings.TryGetValue(typeof(T), out var bindings))
            {
                var bindingToRemove = bindings.OfType<ActionBinding<T>>()
                    .FirstOrDefault(binding => binding.OnPreReaction == reaction || binding.OnPostReaction == reaction);

                RemoveBinding(typeof(T), bindingToRemove);
            }
        }

        public void AddReaction(IAction action)
        {
            _reactions?.Add(action);
        }

        async Awaitable IActionSequencer.Execute(IAction action)
        {
            if (IsExecuting)
                return;

            IsExecuting = true;
            await ExecuteSequence(action);
            IsExecuting = false;
        }

        void IActionSequencer.Clear()
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