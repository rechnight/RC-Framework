// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RCFramework.Tools
{
    public readonly struct AsyncOperationGroup
    {
        public readonly List<AsyncOperation> Operations;

        public float Progress => Operations.Count == 0 ? 0 : Operations.Average(o => o.progress);
        public bool IsDone => Operations.Count == 0 || Operations.All(op => op != null && op.isDone);

        public AsyncOperationGroup(int initialCapacity)
        {
            Operations = new List<AsyncOperation>(initialCapacity);
        }
    }
}