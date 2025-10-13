// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;
using RCFramework.Core;

namespace RCFramework.Tools
{
    public interface IActionSequencer: IUtility
    {
        void SetExecutor<T>(Func<T, Awaitable> performer) where T : IAction;
        void RemoveExecutor<T>() where T : IAction;
        ActionBinding<T> Subscribe<T>(Action<T> reaction, ReactionTiming timing) where T : IAction;
        ActionBinding<T> Subscribe<T>(Action reaction, ReactionTiming timing) where T : IAction;
        void Unsubscribe<T>(ActionBinding<T> binding) where T : IAction;
        void Unsubscribe<T>(Action<T> reaction) where T : IAction;
        void Unsubscribe<T>(Action reaction) where T : IAction;
        Awaitable Execute(IAction action);
        void Clear();
    }
}