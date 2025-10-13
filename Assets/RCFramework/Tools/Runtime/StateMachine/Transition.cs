// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Tools
{
    public class Transition : ITransition
    {
        public IState To { get; }
        public IPredicate Condition { get; }

        public Transition(IState to, IPredicate condition)
        {
            To = to;
            Condition = condition;
        }
    }

    public class Transition<T> : ITransition<T> where T: Enum
    {
        public T To { get; }
        public IPredicate Condition { get; }

        public Transition(T to, IPredicate condition)
        {
            To = to;
            Condition = condition;
        }
    }
}