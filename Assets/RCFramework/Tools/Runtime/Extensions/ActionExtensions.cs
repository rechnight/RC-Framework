// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System;
using UnityEngine;

namespace RCFramework.Tools
{
    public static class ActionExtensions
    {
        public static async Awaitable WaitForInvocationAsync(this Action action)
        {
            var acs = new AwaitableCompletionSource();
            action += Handler;

            void Handler()
            {
                action -= Handler;
                acs.SetResult();
            }

            await acs.Awaitable;
        }
    }
}
