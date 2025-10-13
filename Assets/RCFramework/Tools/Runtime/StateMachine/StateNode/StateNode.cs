// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;
using System;

namespace RCFramework.Tools
{
    public class StateNode : IStateNode
    {
        public IState State { get; }
        public HashSet<ITransition> Transitions { get; }

        public StateNode(IState state)
        {
            State = state;
            Transitions = new HashSet<ITransition>();
        }

        public void AddTransition(IState to, IPredicate condition)
        {
            Transitions.Add(new Transition(to, condition));
        }
    }

    public class StateNode<T> : IStateNode<T> where T: Enum
    {
        public IState State { get; }
        public T StateKey { get; }
        public HashSet<ITransition<T>> Transitions { get; }

        public StateNode(IState state, T key)
        {
            State = state;
            StateKey = key;
            Transitions = new HashSet<ITransition<T>>();
        }

        public void AddTransition(T to, IPredicate condition)
        {
            Transitions.Add(new Transition<T>(to, condition));
        }
    }
}