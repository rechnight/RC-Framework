// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Tools
{
    [DisallowMultipleComponent]
    public abstract class HierarchyObject : MonoBehaviour
    {
        public enum Mode { None = 0, RemoveInPlay = 1, RemoveInBuild = 2 }

        [SerializeField] Mode _objectMode = Mode.None;
        public Mode ObjectMode => _objectMode;
    }
}
