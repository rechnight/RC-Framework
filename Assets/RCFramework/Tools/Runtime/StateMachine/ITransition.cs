// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;

namespace RCFramework.Tools
{
    public interface ITransition
    {
        IState To { get; }
        IPredicate Condition { get; }
    }

    public interface ITransition<T> where T: Enum
    {
        T To { get; }
        IPredicate Condition { get; }
    }
}