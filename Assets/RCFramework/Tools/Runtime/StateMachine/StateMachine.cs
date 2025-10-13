// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using System.Collections.Generic;

namespace RCFramework.Tools
{
    public class StateMachine
    {
        private IStateNode _currentNode;
        private readonly Dictionary<Type, IStateNode> _stateNodes = new();
        private readonly HashSet<ITransition> _anyTransitions = new();

        public IState CurrentState => _currentNode.State;

        public void Update()
        {
            var transition = GetTransition();
            if (transition != null)
            {
                ChangeState(transition.To);
            }

            _currentNode.State.OnUpdate();
        }

        public void FixedUpdate()
        {
            _currentNode.State.OnFixedUpdate();
        }

        public void SetInitialState(IState state)
        {
            _currentNode = _stateNodes[state.GetType()];
            _currentNode.State.OnEnter();
        }

        public void ChangeState(IState state)
        {
            if (state == _currentNode.State)
                return;

            var previousState = _currentNode.State;
            var nextState = _stateNodes[state.GetType()].State;

            previousState.OnExit();
            nextState.OnEnter();
            _currentNode = _stateNodes[state.GetType()];
        }

        public void AddTransition(IState from, IState to, IPredicate condition)
        {
            GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        }

        public void AddAnyTransition(IState to, IPredicate condition)
        {
            _anyTransitions.Add(new Transition(GetOrAddNode(to).State, condition));
        }
        
        private ITransition GetTransition()
        {
            foreach (var transition in _anyTransitions)
            {
                if (transition.Condition.Evaluate())
                    return transition;
            }

            foreach (var transition in _currentNode.Transitions)
            {
                if (transition.Condition.Evaluate())
                    return transition;
            }

            return null;
        }

        private IStateNode GetOrAddNode(IState state)
        {
            var node = _stateNodes.GetValueOrDefault(state.GetType());

            if (node == null)
            {
                node = new StateNode(state);
                _stateNodes.Add(state.GetType(), node);
            }

            return node;
        }
    }

    public class StateMachine<T> where T : Enum
    {
        private IStateNode<T> _currentNode;
        private readonly Dictionary<T, IStateNode<T>> _stateNodes = new();
        private readonly HashSet<ITransition<T>> _anyTransitions = new();

        public T CurrentState => _currentNode.StateKey;

        public void Update()
        {
            var transition = GetTransition();
            if (transition != null)
            {
                ChangeState(transition.To);
            }

            _currentNode.State.OnUpdate();
        }

        public void FixedUpdate()
        {
            _currentNode.State.OnFixedUpdate();
        }

        public void SetState(T state)
        {
            _currentNode = _stateNodes[state];
            _currentNode.State.OnEnter();
        }

        public void ChangeState(T state)
        {
            if (state.Equals(_currentNode.StateKey))
                return;

            var previousState = _currentNode.State;
            var nextState = _stateNodes[state].State;

            previousState.OnExit();
            nextState.OnEnter();
            _currentNode = _stateNodes[state];
        }

        public void AddState(IState state, T stateKey)
        {
            _stateNodes.TryAdd(stateKey, new StateNode<T>(state, stateKey));
        }

        public void AddTransition(T from, T to, IPredicate condition)
        {
            GetNode(from).AddTransition(GetNode(to).StateKey, condition);
        }

        public void AddAnyTransition(T to, IPredicate condition)
        {
            _anyTransitions.Add(new Transition<T>(GetNode(to).StateKey, condition));
        }

        public IState GetState(T stateKey) => GetNode(stateKey).State;

        private ITransition<T> GetTransition()
        {
            foreach (var transition in _anyTransitions)
            {
                if (transition.Condition.Evaluate())
                    return transition;
            }

            foreach (var transition in _currentNode.Transitions)
            {
                if (transition.Condition.Evaluate())
                    return transition;
            }

            return null;
        }

        private IStateNode<T> GetNode(T stateKey)
        {
            if (!_stateNodes.TryGetValue(stateKey, out var node))
            {
                throw new Exception($"State {stateKey} is not registered in the state machine.");
            }
            return node;
        }
    }
}