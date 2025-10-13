// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;

namespace RCFramework.Tools
{
    public interface IAction
    {
        List<IAction> PreReactions { get; }
        List<IAction> ExecuteReactions { get; }
        List<IAction> PostReactions { get; }
    }
}
