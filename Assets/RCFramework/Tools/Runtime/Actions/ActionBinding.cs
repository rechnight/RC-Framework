// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Tools
{
    public class ActionBinding<T> : IActionBinding where T : IAction
    {
        private Action _onPreReaction = () => { };
        private Action<T> _onArgsPreReaction = (T _) => { };
        private Action _onPostReaction = () => { };
        private Action<T> _onArgsPostReaction = (T _) => { };

        private readonly Action<ActionBinding<T>> _unsubscribeAction = (ActionBinding<T> _) => { };

        public Action OnPreReaction { get => _onPreReaction; set => _onPreReaction = value; }
        public Action<T> OnArgsPreReaction { get => _onArgsPreReaction; set => _onArgsPreReaction = value; }
        public Action OnPostReaction { get => _onPostReaction; set => _onPostReaction = value; }
        public Action<T> OnArgsPostReaction { get => _onArgsPostReaction; set => _onArgsPostReaction = value; }

        public ActionBinding(Action onReaction, ReactionTiming timing, Action<ActionBinding<T>> unsubscribeAction = null)
        {
            switch (timing)
            {
                case ReactionTiming.Pre:
                    _onPreReaction = onReaction;
                    break;
                case ReactionTiming.Post:
                    _onPostReaction = onReaction;
                    break;
            }
            _unsubscribeAction = unsubscribeAction;
        }

        public ActionBinding(Action<T> onReaction, ReactionTiming timing, Action<ActionBinding<T>> unsubscribeAction = null)
        {
            switch (timing)
            {
                case ReactionTiming.Pre:
                    _onArgsPreReaction = onReaction;
                    break;
                case ReactionTiming.Post:
                    _onArgsPostReaction = onReaction;
                    break;
            }
            _unsubscribeAction = unsubscribeAction;
        }

        public void Invoke(IAction action, ReactionTiming timing)
        {
            var typedAction = (T)action;

            switch (timing)
            {
                case ReactionTiming.Pre:
                    _onPreReaction?.Invoke();
                    _onArgsPreReaction?.Invoke(typedAction);
                    break;
                case ReactionTiming.Post:
                    _onPostReaction?.Invoke();
                    _onArgsPostReaction?.Invoke(typedAction);
                    break;
            }
        }

        public void Add(Action onReaction, ReactionTiming timing)
        {
            switch (timing)
            {
                case ReactionTiming.Pre:
                    _onPreReaction += onReaction;
                    break;
                case ReactionTiming.Post:
                    _onPostReaction += onReaction;
                    break;
            }
        }
        public void Remove(Action onReaction, ReactionTiming timing)
        {
            switch (timing)
            {
                case ReactionTiming.Pre:
                    _onPreReaction -= onReaction;
                    break;
                case ReactionTiming.Post:
                    _onPostReaction -= onReaction;
                    break;
            }
        }

        public void Add(Action<T> onReaction, ReactionTiming timing)
        {
            switch (timing)
            {
                case ReactionTiming.Pre:
                    _onArgsPreReaction += onReaction;
                    break;
                case ReactionTiming.Post:
                    _onArgsPostReaction += onReaction;
                    break;
            }
        }
        public void Remove(Action<T> onReaction, ReactionTiming timing)
        {
            switch (timing)
            {
                case ReactionTiming.Pre:
                    _onArgsPreReaction -= onReaction;
                    break;
                case ReactionTiming.Post:
                    _onArgsPostReaction -= onReaction;
                    break;
            }
        }

        public void Unsubscribe()
        {
            _unsubscribeAction?.Invoke(this);
        }
    }
}