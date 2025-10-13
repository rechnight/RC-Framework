// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using System.Collections.Generic;

namespace RCFramework.Tools
{
    public interface IStateNode
    {
        IState State { get; }
        HashSet<ITransition> Transitions { get; }
        void AddTransition(IState to, IPredicate condition);
    }

    public interface IStateNode<T> where T: Enum
    {
        IState State { get; }
        T StateKey { get; }
        HashSet<ITransition<T>> Transitions { get; }
        void AddTransition(T to, IPredicate condition);
    }
}