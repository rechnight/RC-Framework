// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine;

namespace RCFramework.Core
{
    public abstract class ControllerBase : MonoBehaviour, IController
    {
        protected virtual void Awake()
        {
            this.InjectDependency(this);
        }
    }
}